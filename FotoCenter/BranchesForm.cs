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
   
    public partial class BranchesForm : Form
    {
        private string server = "localhost";
        private string database = "PhotoCenter";
        private string user = "root";
        private string password = "1234";
        public BranchesForm()
        {
            InitializeComponent();
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
        private void BranchesForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                string query = @"
            SELECT
                branch_id AS 'ID',
                name AS 'Название',
                address AS 'Адрес',
                type AS 'Тип',
                (SELECT COUNT(*) FROM Orders WHERE branch_id = Branches.branch_id) AS 'Число заказов'
            FROM Branches;
        ";
                ExecuteQuery(query);
            }
        }

        private void butt2_Click(object sender, EventArgs e)
        {
            MainFormMenu mainForm = new MainFormMenu();
            mainForm.Show();
            this.Close();
        }
    }
}
