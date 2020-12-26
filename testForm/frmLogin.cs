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

namespace testForm
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

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            bool success = false;            
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = txtDatabase.Text;
            builder.UserID = "SA";
            builder.Password = "CYrulis2002";
            builder.InitialCatalog = "attendanceDB";

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
                            Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
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
                        listOfUsers.Clear();
                        FormSecretary sec = new FormSecretary();
                        sec.ShowDialog();
                    }
                    else if (listOfUsers[i].accessRights == "a")
                    {
                        listOfUsers.Clear();
                        //MessageBox.Show("Hi Admin ;)");
                        this.Visible = false;
                        frmAdmin frmAdmin = new frmAdmin();
                        frmAdmin.ShowDialog();
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
    }

    class User
    {
        public string username;
        public string password;
        public string accessRights;
    }
}
