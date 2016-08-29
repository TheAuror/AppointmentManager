using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppointmentManager.PresentationLayer.Properties;

namespace AppointmentManager.PresentationLayer
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Activated(object sender, EventArgs e)
        {
            usernameTextBox.Focus();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                if (usernameTextBox.Text == Resources.adminUsername &&
                    passwordTextBox.Text == Resources.adminPassword)
                {
                }
                else
                {
                    MessageBox.Show(Resources.LoginForm_ErrorMessage_WrongUsernameOrPassword,
                        Resources.LoginForm_ErrorMessage_Title,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            usernameTextBox.Text = Resources.adminUsername;
            passwordTextBox.Text = Resources.adminPassword;
        }
    }
}
