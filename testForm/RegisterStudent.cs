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

namespace testForm
{
    public partial class RegisterStudent : Form
    {
        public static SqlConnectionStringBuilder builder { get; set; }
        public RegisterStudent()
        {
            InitializeComponent();
        }
        public static void SetDBinfo(SqlConnectionStringBuilder input)
        {
            builder = input;
        }
        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            int dump;
            if (txtFirstName.Text == null || txtLastName.Text == null || cmbGroups.Text == null || txtMotherName.Text == null || txtFatherName.Text == null || !int.TryParse(txtMotherPhone.Text, out dump) || !int.TryParse(txtFatherPhone.Text, out dump) || !int.TryParse(txtThirdNo.Text, out dump) || txtThirdName.Text == null)
            {
                MessageBox.Show("Make sure all fields are filled in, and that valid phone numbers are provided without spaces and try again.");
            }
            else
            {                
                try
                {
                    using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                    {
                        String sql;
                        if (txtThirdRole.Text == null)
                        {
                            sql = "Insert into Students (FirstName, LastName, StudentGroup, MotherName, MotherPhone, FatherName, FatherPhone, ThirdName, ThirdRole, ThirdPhone) " +
                            "Values('" + txtFirstName.Text + "', '" + txtLastName.Text + "', '" + cmbGroups.Text + "', '" + txtMotherName.Text + "', " + txtMotherPhone.Text + ", '" + txtFatherName.Text + "', " + txtFatherPhone.Text + ", '" + txtThirdName.Text + "', '" + txtThirdRole.Text + "', " + txtThirdNo.Text + ");";
                        }
                        else
                        {
                            sql = "Insert into Students (FirstName, LastName, StudentGroup, MotherName, MotherPhone, FatherName, FatherPhone, ThirdName, ThirdPhone) " +
                            "Values('" + txtFirstName.Text + "', '" + txtLastName.Text + "', '" + cmbGroups.Text + "', '" + txtMotherName.Text + "', " + txtMotherPhone.Text + ", '" + txtFatherName.Text + "', " + txtFatherPhone.Text + ", '" + txtThirdName.Text + "', " + txtThirdNo.Text + ");";
                        }

                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                    MessageBox.Show("Student added successfuly.");
                }
                catch
                {
                    MessageBox.Show("Information Provided is Incorrect.");
                }
            }            
        }

        private void RegisterStudent_Load(object sender, EventArgs e)
        {
            cmbGroups.Items.Clear();            

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                String sql = "SELECT GroupID FROM dbo.Groups";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbGroups.Items.Add(reader.GetString(0));                          
                        }
                        reader.Close();
                    }
                    connection.Close();
                }
            }
        }

        private void txtFatherName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmAdmin admin = new frmAdmin();
            //update students list not necessary
            admin.Show();
        }
    }
}
