using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrkTravel
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            DatabaseHandler databaseHandler = new DatabaseHandler();
            LoginDetails myDetails = databaseHandler.Login(txt_username.Text, txt_password.Text);

            if (myDetails.loginAuth)
            {
                Home home = new Home();
                home.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(myDetails.loginAuth + " with username: " + myDetails.username);
            }
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            Register reg = new Register(this);
            reg.Show();
            this.Hide();
        }
    }
}
