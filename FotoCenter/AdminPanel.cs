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
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddUserForm addUser = new AddUserForm();
            addUser.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ManageUsersForm manageUser = new ManageUsersForm();
            manageUser.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoginForm loginuser = new LoginForm();
            loginuser.Show();
            this.Close();
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {

        }
    }
}
