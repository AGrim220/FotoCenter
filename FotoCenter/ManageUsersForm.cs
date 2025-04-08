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
    public partial class ManageUsersForm : Form
    {
        private string server = "localhost";
        private string database = "PhotoCenter";
        private string user = "root";
        private string password = "1234";
        public ManageUsersForm()
        {
            InitializeComponent();
            LoadUsers();
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
        private void ManageUsersForm_Load(object sender, EventArgs e)
        {

        }

        private void btnUnblockUser_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.SelectedRows.Count > 0)
            {
                int userId = Convert.ToInt32(dataGridViewUsers.SelectedRows[0].Cells["user_id"].Value);

                string connectionString = $"Server={server};Database={database};User ID={user};Password={password};";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        string query = "UPDATE Users SET is_blocked = FALSE WHERE user_id = @userId";
                        MySqlCommand cmd = new MySqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@userId", userId);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Пользователь разблокирован");
                        LoadUsers(); // Обновляем список пользователей
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите пользователя для разблокировки");
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.SelectedRows.Count > 0)
            {
                int userId = Convert.ToInt32(dataGridViewUsers.SelectedRows[0].Cells["user_id"].Value);

                string connectionString = $"Server={server};Database={database};User ID={user};Password={password};";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        string query = "UPDATE Users SET is_blocked = TRUE WHERE user_id = @userId";
                        MySqlCommand cmd = new MySqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@userId", userId);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Пользователь заблокирован");
                        LoadUsers(); // Обновляем список пользователей
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите пользователя для блокировки");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.SelectedRows.Count > 0)
            {
                int userId = Convert.ToInt32(dataGridViewUsers.SelectedRows[0].Cells["user_id"].Value);
                string newLogin = txtLogin.Text;
                string newPassword = txtPassword.Text;
                string newRole = cmbRole.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(newLogin) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(newRole))
                {
                    MessageBox.Show("Заполните все поля");
                    return;
                }

                string connectionString = $"Server={server};Database={database};User ID={user};Password={password};";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        // Проверка уникальности логина
                        string checkQuery = "SELECT COUNT(*) FROM Users WHERE login = @login AND user_id != @userId";
                        MySqlCommand checkCmd = new MySqlCommand(checkQuery, connection);
                        checkCmd.Parameters.AddWithValue("@login", newLogin);
                        checkCmd.Parameters.AddWithValue("@userId", userId);
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("Пользователь с таким логином уже существует");
                            return;
                        }

                        string query = "UPDATE Users SET login = @login, password = @password, role = @role WHERE user_id = @userId";
                        MySqlCommand cmd = new MySqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@login", newLogin);
                        cmd.Parameters.AddWithValue("@password", newPassword);
                        cmd.Parameters.AddWithValue("@role", newRole);
                        cmd.Parameters.AddWithValue("@userId", userId);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Данные пользователя успешно изменены");
                        LoadUsers(); // Обновляем список пользователей
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
            else
            {
                MessageBox.Show("Выберите пользователя для редактирования");
            }
        
         }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminPanel adminPanel = new AdminPanel();
            adminPanel.Show();
            this.Close();
        }
    }
    
}
