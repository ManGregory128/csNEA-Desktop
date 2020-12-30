using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.IO;
using System.Data.SqlClient;

namespace testForm
{
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Register register = new Register();
            register.ShowDialog();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            MessageBox.Show("Goodbye!");
            frmLogin logIn = new frmLogin();
            logIn.ShowDialog();
        }

        private void usersPage_Click(object sender, EventArgs e)
        {

        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            //reload all lists
            UpdateUsersList();
            UpdateLessonsList();
            UpdateGroupsList();
        }

        private void lstStudents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabStudents_Click(object sender, EventArgs e)
        {

        }

        private void lstUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnFeedPost_Click(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("Type your feed post below:", "Posting to the Feed", "", 0, 0);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tabGroups_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            MessageBox.Show("WARNING: This will override the current schedule of the user (if any exists).");
            uploadSchDiag.ShowDialog();
            int[,] schedule = new int[7, 5];
            string scheduleFile = uploadSchDiag.FileName;
            StreamReader reader = new StreamReader(scheduleFile);

            int i = 0;
            while (!reader.EndOfStream && i < 7)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                for (int j = 0; j < 5; j++)
                {
                    schedule[i, j] = int.Parse(values[j]);
                }
                i++;
            }
            UploadSchedule(schedule);
        }
        private void UploadSchedule(int[,] sc)
        {
            try
            {
                string selectedUser = lstUsers.SelectedItems[0].Text;
            }
            catch
            {
                MessageBox.Show("You have not selected a user from the list!");
            }

        }
        private void UpdateUsersList()
        {
            lstUsers.Items.Clear();
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "192.168.0.30";
            builder.UserID = "SA";
            builder.Password = "CYrulis2002";
            builder.InitialCatalog = "attendanceDB";

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {

                String sql = "SELECT UserName, FirstName, LastName, UserRole, IsLoggedIn FROM dbo.Users";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                            ListViewItem user = new ListViewItem(reader.GetString(0));
                            user.SubItems.Add(reader.GetString(1));
                            if (!reader.IsDBNull(2))
                            {
                                user.SubItems.Add(reader.GetString(2));
                            }
                            user.SubItems.Add(reader.GetString(3));
                            user.SubItems.Add(reader.GetBoolean(4).ToString());
                            lstUsers.Items.Add(user);
                        }
                        reader.Close();
                    }
                    connection.Close();
                }
            }
        }

        private void UpdateLessonsList()
        {
            lstLessons.Items.Clear();
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "192.168.0.30";
            builder.UserID = "SA";
            builder.Password = "CYrulis2002";
            builder.InitialCatalog = "attendanceDB";

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                String sql = "SELECT LessonID, LessonName FROM dbo.Lessons";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                            int x = (byte)reader[0];
                            ListViewItem lesson = new ListViewItem(x.ToString());
                            lesson.SubItems.Add(reader.GetString(1));
                            lstLessons.Items.Add(lesson);
                        }
                        reader.Close();
                    }
                    connection.Close();
                }
            }
        }

        private void btnAddLesson_Click(object sender, EventArgs e)
        {
            int id;
            if (!int.TryParse(txtLessonID.Text, out id) || txtLesson.Text == null)
            {
                MessageBox.Show("The Lesson ID must be an Integer and the Name must not be Null.");
            }
            else
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "192.168.0.30";
                builder.UserID = "SA";
                builder.Password = "CYrulis2002";
                builder.InitialCatalog = "attendanceDB";
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    String sql = "Insert into Lessons (LessonID, LessonName) Values(" + txtLessonID.Text + ", '" + txtLesson.Text + "');";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                MessageBox.Show("Lesson added successfuly.");
                UpdateLessonsList();
            }
        }

        private void tabLessons_Click(object sender, EventArgs e)
        {
            //maybe refresh list here
        }

        private void btnDelLesson_Click(object sender, EventArgs e)
        {
            if (lstLessons.Items.Count > 0)
            {
                string lessonToDelete = lstLessons.SelectedItems[0].Text;
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "192.168.0.30";
                builder.UserID = "SA";
                builder.Password = "CYrulis2002";
                builder.InitialCatalog = "attendanceDB";
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    String sql = "DELETE FROM Lessons WHERE LessonID=" + lessonToDelete + ";";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                MessageBox.Show("Lesson removed successfuly.");
                UpdateLessonsList();
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            string username = lstUsers.SelectedItems[0].Text;
            string input = Interaction.InputBox("Type the new password below:", "Changing Password for " + username, "", 0, 0);
            string confirm = Interaction.InputBox("Repeat the new password below:", "Changing Password for " + username, "", 0, 0);
            if (input == confirm)
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "192.168.0.30";
                builder.UserID = "SA";
                builder.Password = "CYrulis2002";
                builder.InitialCatalog = "attendanceDB";
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    String sql = "UPDATE Users SET UserPassword='" + input + "' WHERE UserName='" + username + "';";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                MessageBox.Show("Password for " + username + " changed successfuly.");
            }
            else
                MessageBox.Show("Passwords Do Not Match!");
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            if (txtGroup.Text == null)
            {
                MessageBox.Show("The Group ID must not be Null.");
            }
            else
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "192.168.0.30";
                builder.UserID = "SA";
                builder.Password = "CYrulis2002";
                builder.InitialCatalog = "attendanceDB";
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    String sql = "Insert into Groups (GroupID) Values('" + txtGroup.Text + "');";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                MessageBox.Show("Group added successfuly.");
                UpdateGroupsList();
            }
        }
        private void UpdateGroupsList()
        {
            lstGroups.Items.Clear();
            cmbInitialGroup.Items.Clear();
            cmbFinalGroup.Items.Clear();
            cmbGroups.Items.Clear();
            cmbAbsentGroups.Items.Clear();
            cmbMentors.Items.Clear();
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "192.168.0.30";
            builder.UserID = "SA";
            builder.Password = "CYrulis2002";
            builder.InitialCatalog = "attendanceDB";

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                String sql = "SELECT GroupID, TeacherRep FROM dbo.Groups";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ListViewItem group = new ListViewItem(reader.GetString(0));
                            cmbGroups.Items.Add(reader.GetString(0));
                            cmbInitialGroup.Items.Add(reader.GetString(0));
                            cmbMentors.Items.Add(reader.GetString(0));
                            cmbAbsentGroups.Items.Add(reader.GetString(0));
                            cmbFinalGroup.Items.Add(reader.GetString(0));
                            if (!reader.IsDBNull(1))
                            {
                                group.SubItems.Add(reader.GetString(1));
                            }
                            lstGroups.Items.Add(group);
                        }
                        reader.Close();
                    }
                    connection.Close();
                }
            }
        }

        private void btnMentorSet_Click(object sender, EventArgs e)
        {
            string group = cmbMentors.Text;
            string userSelected = lstUsers.SelectedItems[0].Text;
            if (group != null)
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "192.168.0.30";
                builder.UserID = "SA";
                builder.Password = "CYrulis2002";
                builder.InitialCatalog = "attendanceDB";
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    String sql = "UPDATE Groups SET TeacherRep = '" + userSelected + "' WHERE GroupID='" + group + "';";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                MessageBox.Show("Group properties saved successfuly.");
                UpdateGroupsList(); //maybe
            }
        }

        private void btnUploadStudents_Click(object sender, EventArgs e)
        {
            uploadStudentsDiag.ShowDialog();
            
            string studentsFile = uploadSchDiag.FileName;
            StreamReader reader = new StreamReader(studentsFile);
           
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                for (int j = 0; j < 5; j++)
                {
                    //schedule[i, j] = int.Parse(values[j]);
                }
            }
        }
    }
}
