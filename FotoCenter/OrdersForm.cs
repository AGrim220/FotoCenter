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
    public partial class OrdersForm : Form
    {
        private string server = "localhost";
        private string database = "PhotoCenter";
        private string user = "root";
        private string password = "1234";
        public OrdersForm()
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
        private void OrdersForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                string startDate = dtpStartDate.Value.ToString("yyyy-MM-dd");
                string endDate = dtpEndDate.Value.ToString("yyyy-MM-dd");

                string query = $@"
            SELECT
                order_id AS 'ID заказа',
                client_id AS 'ID клиента',
                branch_id AS 'ID филиала',
                order_date AS 'Дата заказа',
                type AS 'Тип заказа',
                status AS 'Статус',
                total_cost AS 'Стоимость',
                photo_count AS 'Количество фотографий',
                film_count AS 'Количество пленок'
            FROM Orders
            WHERE order_date BETWEEN '{startDate}' AND '{endDate}';
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
