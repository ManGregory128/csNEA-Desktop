using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using csNEA.Properties;
using Windows.UI.WindowManagement;
using Microsoft.Extensions.Configuration;

namespace csNEA
{

    public partial class frmLogin : Form
    {
        List<User> listOfUsers = new List<User>() { };
        User tempUser = new User();
        public static string passUser;
        public static char passRights;
        ConfigurationBuilder appConfig = new ConfigurationBuilder();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            if (Settings.Default.DBpassword != String.Empty)
            {
                chckRetainDBPass.Checked = true;
                txtDBPassword.Text = Settings.Default.DBpassword;
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            bool success = false;
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = Settings.Default.DBaddress;
            builder.UserID = "SA";
            builder.Password = Settings.Default.DBpassword;
            builder.InitialCatalog = cmbSchool.Text;

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {

                String sql = "SELECT UserName, UserPassword, UserRole FROM dbo.Users";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                            AddUser(reader.GetString(0), reader.GetString(1), reader.GetString(2));
                        }
                        reader.Close();
                    }
                    connection.Close();
                }
            }
            for (int i = 0; i < listOfUsers.Count; i++)
            {
                if (txtUser.Text == listOfUsers[i].username && txtPassword.Text == listOfUsers[i].password)
                {
                    success = true;
                    passUser = listOfUsers[i].username;

                    this.Visible = false;
                    if (listOfUsers[i].accessRights == "s")
                    {
                        passRights = 's';
                        listOfUsers.Clear();
                        this.Visible = false;
                        frmAdmin admin = new frmAdmin();
                        frmAdmin.SetDBinfo(Settings.Default.DBaddress, txtDBPassword.Text);
                        admin.ShowDialog();
                    }
                    else if (listOfUsers[i].accessRights == "a")
                    {
                        frmAdmin.currentUser = listOfUsers[i].username;
                        passRights = 'a';
                        listOfUsers.Clear();
                        this.Visible = false;
                        frmAdmin admin = new frmAdmin();
                        frmAdmin.SetDBinfo(Settings.Default.DBaddress, txtDBPassword.Text);
                        admin.ShowDialog();
                    }
                    else
                    {
                        listOfUsers.Clear();
                    }
                }
            }
            if (success == false)
            {
                MessageBox.Show("Login Failed");
                listOfUsers.Clear();
            }

        }
        private void AddUser(string username, string password, string rights)
        {
            tempUser = new User();
            tempUser.username = username;
            tempUser.password = password;
            tempUser.accessRights = rights;
            listOfUsers.Add(tempUser);
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = false;
            base.OnFormClosing(e);
            Application.Exit();
        }

        private void btnConnectDB_Click(object sender, EventArgs e)
        {
            if (chckRetainDBPass.Checked)
            {
                Settings.Default.DBpassword = txtDBPassword.Text;
                Settings.Default.Save();
            }
            string connectionString = "Server=" + Settings.Default.DBaddress + ";User Id=SA;Password=" + txtDBPassword.Text + ";";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT name from sys.databases", con))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                switch (dr[0].ToString())
                                {
                                    case "master":
                                        break;
                                    case "model":
                                        break;
                                    case "tempdb":
                                        break;
                                    case "msdb":
                                        break;
                                    default:
                                        cmbSchool.Items.Add(dr[0]);
                                        break;
                                }
                            }
                        }
                    }
                    btnConnect.Enabled = true;
                    cmbSchool.Enabled = true;
                }
                catch { MessageBox.Show("Login Failed"); }
            }
        }
    }

    class User
    {
        public string username;
        public string password;
        public string accessRights;
    }
}
