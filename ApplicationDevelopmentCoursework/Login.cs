using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationDevelopmentCoursework
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Loginbutton_Click(object sender, EventArgs e)
        {
            string user, password;
            user = Username.Text;
            password = Password.Text;
            if (user == "" || password == "")
            {
                MessageBox.Show("The fields Username and Password must be left blank.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                foreach (Control C in Controls)
                {
                    if (C is TextBox)
                    {
                        C.Text = "";
                    }
                }
            }
            else if (user == "admin" && password == "admin")
            {
                Admin admin = new Admin();
                admin.Show();
                this.Hide();
            }
            else if (user == "staff" && password == "staff")
            {
                Visitors Adm = new Visitors();
                Adm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login Failed. Plese Try Again.");
            }
        }

        private void Username_TextChanged(object sender, EventArgs e)
        {

        }

        private void Password_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
