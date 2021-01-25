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

namespace csNEA
{
    
    public partial class frmLogin : Form
    {        
        List<User> listOfUsers = new List<User>() { };       
        User tempUser = new User();
        public static string passUser;
        
        public frmLogin()
        {                                  
            InitializeComponent();
        }
        
        private void frmLogin_Load(object sender, EventArgs e)
        {
            if (Settings.Default.DBaddress != string.Empty)
            {
                txtDatabase.Text = Settings.Default.DBaddress;
                txtDBPassword.Text = Settings.Default.DBpassword;
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            bool success = false;            
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = txtDatabase.Text;
            builder.UserID = "adminDB";
            builder.Password = txtDBPassword.Text;
            builder.InitialCatalog = "aradippou5";
            
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
                    if (chckRemember.Checked)
                    {
                        Settings.Default.DBaddress = txtDatabase.Text;
                        Settings.Default.DBpassword = txtDBPassword.Text;
                        Settings.Default.Save();
                    }
                    else
                    {
                        Settings.Default.DBaddress = "";
                        Settings.Default.DBpassword = "";
                        Settings.Default.Save();
                    }
                    this.Visible = false;
                    if (listOfUsers[i].accessRights == "s")
                    {
                        listOfUsers.Clear();
                        FormSecretary sec = new FormSecretary();
                        sec.ShowDialog();
                    }
                    else if (listOfUsers[i].accessRights == "a")
                    {
                        frmAdmin.currentUser = listOfUsers[i].username;
                        listOfUsers.Clear();                      
                        this.Visible = false;
                        frmAdmin admin = new frmAdmin();
                        frmAdmin.SetDBinfo(txtDatabase.Text, txtDBPassword.Text);
                        admin.ShowDialog();
                    }
                    else
                    {
                        listOfUsers.Clear();
                        details details = new details();
                        details.ShowDialog();
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
    }

    class User
    {
        public string username;
        public string password;
        public string accessRights;
    }
}
