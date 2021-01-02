﻿using System;
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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmAdmin admin = new frmAdmin();
            admin.UpdateUsersList();
            admin.ShowDialog();
        }
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            string rights;
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "192.168.0.30";
            builder.UserID = "SA";
            builder.Password = "CYrulis2002";
            builder.InitialCatalog = "attendanceDB";

            if (cmbRights.Text == "Administrator")
            {
                rights = "a";
            }
            else if (cmbRights.Text == "Secretary")
            {
                rights = "s";
            }
            else
            {
                rights = "t";
            }
            string cmd;
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {

                if (txtLastName.Text != null)
                    cmd = "Insert into Users (UserName, UserPassword, UserRole, FirstName, LastName, IsLoggedIn) Values('" + txtNewUsername.Text + "', '" + txtNewPassword.Text + "', '" + rights + "', '" + txtFirstName.Text + "', '" + txtLastName.Text + "', '0');";
                else
                    cmd = "Insert into Users (UserName, UserPassword, UserRole, FirstName, IsLoggedIn) Values('" + txtNewUsername.Text + "', '" + txtNewPassword.Text + "', '" + rights + "', '" + txtFirstName.Text + "', '0');";
                String sql = cmd;
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            MessageBox.Show("User added successfuly.");

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
