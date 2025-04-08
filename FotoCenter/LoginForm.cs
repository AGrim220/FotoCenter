using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FotoCenter
{
    public partial class LoginForm : Form
    {
        private string server = "localhost";
        private string database = "PhotoCenter";
        private string user = "root";
        private string password = "1234";
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string login = log.Text.Trim();
            string password = pass.Text.Trim();

            string connectionString = $"Server={server};Database={database};User ID={user};Password={this.password};";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT role, is_blocked FROM Users WHERE login = @login AND password = @password";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string role = reader["role"].ToString();
                            bool isBlocked = Convert.ToBoolean(reader["is_blocked"]);

                            if (isBlocked)
                            {
                                MessageBox.Show("Вы заблокированы. Обратитесь к администратору.");
                                return;
                            }

                            MessageBox.Show($"Вы успешно авторизовались как {role}");

                            if (role == "Администратор")
                            {
                                AdminPanel adminPanel = new AdminPanel();
                                adminPanel.Show();
                            }
                            else
                            {
                                MainFormMenu mainForm = new MainFormMenu();
                                mainForm.Show();
                            }

                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Неверный логин или пароль");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка подключения к базе данных: " + ex.Message);
                }
            }
        }
    }
}
