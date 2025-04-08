using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FotoCenter
{
    public partial class OrdersByTypeForm : Form
    {
        private string server = "localhost";
        private string database = "PhotoCenter";
        private string user = "root";
        private string password = "1234";
        public OrdersByTypeForm()
        {
            InitializeComponent();
            LoadBranches();
        }
        private void LoadBranches()
        {
            string query = "SELECT branch_id, name FROM Branches";
            string connectionString = $"Server={server};Database={database};User ID={user};Password={password};";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    // Заполняем ComboBox названиями филиалов и киосков
                    cmbBranchName.DataSource = table;
                    cmbBranchName.DisplayMember = "name";
                    cmbBranchName.ValueMember = "branch_id";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки филиалов и киосков: " + ex.Message);
                }
            }
        }
        private void ExecuteQuery(string query)
        {
            string connectionString = $"Server={server};Database={database};User ID={user};Password={password};";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridViewResults.DataSource = table;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка выполнения запроса: " + ex.Message);
                }
            }
        }
        private void OrdersByTypeForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int branchId = (int)cmbBranchName.SelectedValue;
            string startDate = dtpStartDate.Value.ToString("yyyy-MM-dd");
            string endDate = dtpEndDate.Value.ToString("yyyy-MM-dd");

            string query = $@"
            SELECT
                O.type AS 'Тип заказа',
                COUNT(*) AS 'Число заказов',
                SUM(CASE WHEN O.type = 'Простой' THEN 1 ELSE 0 END) AS 'Простые заказы',
                SUM(CASE WHEN O.type = 'Срочный' THEN 1 ELSE 0 END) AS 'Срочные заказы'
            FROM Orders O
            WHERE O.branch_id = {branchId}
              AND O.order_date BETWEEN '{startDate}' AND '{endDate}'
            GROUP BY O.type;
        ";
            ExecuteQuery(query);
        }

        private void butt2_Click(object sender, EventArgs e)
        {
            MainFormMenu mainForm = new MainFormMenu();
            mainForm.Show();
            this.Close();
        }
    }
}
