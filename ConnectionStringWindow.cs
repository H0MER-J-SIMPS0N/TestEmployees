using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestEmployees
{
    public partial class ConnectionStringWindow : Form
    {
        public string ResultConnectionString { get; private set; } = string.Empty;
        public ConnectionStringWindow()
        {
            InitializeComponent();
        }

        private void ConnectionStringWindow_Load(object sender, EventArgs e)
        {
            cbxAuthentication.DataSource = new string[] { "Проверка подлинности Windows", "Проверка подлинности SQL Server" };
        }

        private void cbxAuthentication_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxAuthentication.SelectedItem is null)
            {
                return;
            }
            if(cbxAuthentication.SelectedItem.ToString().Equals("Проверка подлинности Windows"))
            {
                txbLogin.Enabled = false;
                txbPassword.Enabled = false;
            }
            else
            {
                txbLogin.Enabled = true;
                txbPassword.Enabled = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbDatabaseName.Text) || string.IsNullOrEmpty(txbServerName.Text))
            {
                MessageBox.Show("Нужно ввести обязательные поля Имя сервера и Имя базы данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbxAuthentication.SelectedItem.ToString().Equals("Проверка подлинности Windows"))
            {
                ResultConnectionString = new StringBuilder("data source=")
                    .Append(txbServerName.Text)
                    .Append(";initial catalog=")
                    .Append(txbDatabaseName.Text)
                    .Append(";integrated security=True;MultipleActiveResultSets=True;App=TestEmployees")
                    .ToString();
            }
            else if (string.IsNullOrEmpty(txbLogin.Text) || string.IsNullOrEmpty(txbPassword.Text))
            {
                MessageBox.Show("Нужно ввести обязательные поля Логин и Пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                ResultConnectionString = new StringBuilder("data source=")
                    .Append(txbServerName.Text)
                    .Append(";initial catalog=")
                    .Append(txbDatabaseName.Text)
                    .Append(";User ID=")
                    .Append(txbLogin.Text)
                    .Append(";Password=")
                    .Append(txbPassword.Text)
                    .Append(";MultipleActiveResultSets=True;App=TestEmployees")
                    .ToString();
            }
            DialogResult = DialogResult.OK;
        }
    }
}
