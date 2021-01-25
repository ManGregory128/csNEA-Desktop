using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csNEA
{
    public partial class FormSecretary : Form
    {
        public FormSecretary()
        {
            
            InitializeComponent();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            MessageBox.Show("Goodbye!");
            frmLogin logIn = new frmLogin();
            logIn.ShowDialog();
        }

        private void FormSecretary_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Good Morning, " + frmLogin.passUser + "!";           
        }
    }
}
