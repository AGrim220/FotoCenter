using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FotoCenter.LoginForm;

namespace FotoCenter
{
    public partial class MainFormMenu : Form
    {
        public MainFormMenu()
        {
            InitializeComponent();
            InitializeMenuStrip();
        }
        private void InitializeMenuStrip()
        {
        MenuStrip menuStrip = new MenuStrip();
        this.MainMenuStrip = menuStrip;
        this.Controls.Add(menuStrip);

        ToolStripMenuItem branchesMenu = new ToolStripMenuItem("Филиалы и заказы");
        menuStrip.Items.Add(branchesMenu);

        branchesMenu.DropDownItems.Add("1. Пункты приема заказов", null, (s, e) => OpenForm(new BranchesForm()));
        branchesMenu.DropDownItems.Add("2. Заказы за период", null, (s, e) => OpenForm(new OrdersForm()));
        branchesMenu.DropDownItems.Add("3. Заказы по типу и филиалу", null, (s, e) => OpenForm(new OrdersByTypeForm()));
        branchesMenu.DropDownItems.Add("4. Выручка по типу и филиалу", null, (s, e) => OpenForm(new RevenueByTypeForm()));
        branchesMenu.DropDownItems.Add("5. Количество отпечатанных фотографий", null, (s, e) => OpenForm(new PhotoCountForm()));
        branchesMenu.DropDownItems.Add("6. Количество проявленных пленок", null, (s, e) => OpenForm(new FilmCountForm()));

        // Пункт меню "Поставщики"
        ToolStripMenuItem suppliersMenu = new ToolStripMenuItem("Поставщики");
        menuStrip.Items.Add(suppliersMenu);
        suppliersMenu.DropDownItems.Add("7. Перечень поставщиков", null, (s, e) => OpenForm(new SuppliersForm()));

        // Пункт меню "Клиенты"
        ToolStripMenuItem clientsMenu = new ToolStripMenuItem("Клиенты");
        menuStrip.Items.Add(clientsMenu);
        clientsMenu.DropDownItems.Add("8. Список клиентов", null, (s, e) => OpenForm(new ClientsForm()));

        // Пункт меню "Фототовары"
        ToolStripMenuItem productsMenu = new ToolStripMenuItem("Фототовары");
        menuStrip.Items.Add(productsMenu);
        productsMenu.DropDownItems.Add("9. Выручка от фототоваров", null, (s, e) => OpenForm(new RevenueFromProductsForm()));
        productsMenu.DropDownItems.Add("10. Популярные фототовары", null, (s, e) => OpenForm(new PopularProductsForm()));
        productsMenu.DropDownItems.Add("11. Реализованные фототовары", null, (s, e) => OpenForm(new SoldProductsForm()));

        // Пункт меню "Рабочие места"
        ToolStripMenuItem workstationsMenu = new ToolStripMenuItem("Рабочие места");
        menuStrip.Items.Add(workstationsMenu);
        workstationsMenu.DropDownItems.Add("12. Перечень рабочих мест", null, (s, e) => OpenForm(new WorkstationsForm()));

        // Пункт меню "Управление"
        ToolStripMenuItem manageMenu = new ToolStripMenuItem("Управление");
        menuStrip.Items.Add(manageMenu);
        manageMenu.DropDownItems.Add("Сменить пользователя", null, (s, e) => ChangeUser());
        manageMenu.DropDownItems.Add("Выход", null, (s, e) => Application.Exit());
    }

    // Метод для открытия новой формы
    private void OpenForm(Form form)
    {
        form.Show();
            this.Hide();
    }

    // Смена пользователя
    private void ChangeUser()
    {
        LoginForm loginForm = new LoginForm();
        loginForm.Show();
        this.Hide();
    }
    private void MainFormMenu_Load(object sender, EventArgs e)
        {

        }

        private void редактироватьЗаказыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
