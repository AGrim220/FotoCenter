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
    public partial class AddUserForm : Form
    {
        private string server = "localhost";
        private string database = "PhotoCenter";
        private string user = "root";
        private string password = "1234";
        public AddUserForm()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void AddUserForm_Load(object sender, EventArgs e)
        {

        }
        private void LoadUsers()
        {
            string connectionString = $"Server={server};Database={database};User ID={user};Password={password};";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT user_id, login, role, is_blocked FROM Users";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dataGridViewUsers.DataSource = table;

                    // Скрываем столбец user_id
                    dataGridViewUsers.Columns["user_id"].Visible = false;

                    // Переименовываем заголовки столбцов
                    dataGridViewUsers.Columns["login"].HeaderText = "Логин";
                    dataGridViewUsers.Columns["role"].HeaderText = "Роль";
                    dataGridViewUsers.Columns["is_blocked"].HeaderText = "Заблокирован";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки данных: " + ex.Message);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text;
            string password = txtPassword.Text;
            string role = cmbRole.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            string connectionString = $"Server={server};Database={database};User ID={user};Password={this.password};";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Проверка наличия пользователя
                    string checkQuery = "SELECT COUNT(*) FROM Users WHERE login = @login";
                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, connection);
                    checkCmd.Parameters.AddWithValue("@login", login);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("Пользователь с таким логином уже существует");
                        return;
                    }

                    // Добавление нового пользователя
                    string insertQuery = "INSERT INTO Users (login, password, role) VALUES (@login, @password, @role)";
                    MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection);
                    insertCmd.Parameters.AddWithValue("@login", login);
                    insertCmd.Parameters.AddWithValue("@password", password);
                    insertCmd.Parameters.AddWithValue("@role", role);

                    insertCmd.ExecuteNonQuery();
                    MessageBox.Show("Пользователь успешно добавлен");
                    LoadUsers(); // Обновляем список пользователей

                    // Очистка текстовых полей и комбобокса
                    txtLogin.Clear();
                    txtPassword.Clear();
                    cmbRole.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminPanel adminPanel = new AdminPanel();
            adminPanel.Show();
            this.Close();
        }
    }
}
