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
        public static SqlConnectionStringBuilder builder { get; set; }
        public frmAdmin()
        {
            InitializeComponent();
        }
        public static void SetDBinfo(string input)
        {           
            builder = new SqlConnectionStringBuilder
            {
                DataSource = input,
                UserID = "SA",
                Password = "CYrulis2002",
                InitialCatalog = "attendanceDB"
            };
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
                //create teachings
            }
            catch
            {
                MessageBox.Show("You have not selected a user from the list!");
            }

        }
        public void UpdateUsersList()
        {
            lstUsers.Items.Clear();           

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
        public void UpdateGroupsList()
        {
            lstGroups.Items.Clear();
            cmbInitialGroup.Items.Clear();
            cmbFinalGroup.Items.Clear();
            cmbGroups.Items.Clear();
            cmbAbsentGroups.Items.Clear();
            cmbMentors.Items.Clear();           

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
            List<Student> students = new List<Student>();
            Student tempStudent;
            uploadStudentsDiag.ShowDialog();
            try
            {
                string studentsFile = uploadStudentsDiag.FileName;
                StreamReader reader = new StreamReader(studentsFile);
                students.Clear();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    tempStudent = new Student(values[0], values[1], values[2], values[3], values[4], values[5], values[6], int.Parse(values[7]), int.Parse(values[8]), int.Parse(values[9]));
                    students.Add(tempStudent);
                }
                UploadStudents(students);
                MessageBox.Show("Students Uploaded Successfuly.");
            }
            catch
            {
                MessageBox.Show("You have not selected an appropriate file.");
            }
        }
        private void UploadStudents(List<Student> students)
        {
            for (int i = 0; i < students.Count; i++)
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    String sql = "Insert into Students (FirstName, LastName, StudentGroup, MotherName, MotherPhone, FatherName, FatherPhone, ThirdName, ThirdRole, ThirdPhone) " +
                        "Values('" + students[i].FirstName + "', '" + students[i].LastName + "', '" + students[i].Group + "', '" + students[i].MothersName + "', " + students[i].MotherPhone.ToString() + ", '" + students[i].FathersName + "', " + students[i].FatherPhone.ToString() + ", '" + students[i].ThirdName + "', '" + students[i].ThirdRole + "', " + students[i].ThirdPhone.ToString() + ");";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
        }
        private void btnStudentManualAdd_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            RegisterStudent registerStudent = new RegisterStudent();
            registerStudent.ShowDialog();
        }

        private void btnDisGroup_Click(object sender, EventArgs e)
        {
            lstStudents.Items.Clear();
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                String sql = "SELECT StudentID, FirstName, LastName, StudentGroup, MotherName, MotherPhone, FatherName, FatherPhone, ThirdName, ThirdRole, ThirdPhone FROM dbo.Students WHERE StudentGroup='" + cmbGroups.Text + "';";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ListViewItem student = new ListViewItem(reader.GetInt32(0).ToString()); //ID
                            student.SubItems.Add(reader.GetString(1)); //FirstName
                            student.SubItems.Add(reader.GetString(2)); //LastName
                            student.SubItems.Add(reader.GetString(3)); //Group
                            student.SubItems.Add(reader.GetString(4)); //Mother's Name
                            student.SubItems.Add(reader.GetInt32(5).ToString()); //Mother's Phone Number
                            if (!reader.IsDBNull(6))
                                student.SubItems.Add(reader.GetString(6)); //Father's Name
                            student.SubItems.Add(reader.GetInt32(7).ToString()); //Father's Phone Number
                            student.SubItems.Add(reader.GetString(8)); //Backup Contact's Name
                            student.SubItems.Add(reader.GetString(9)); //Backup Contact's Role
                            student.SubItems.Add(reader.GetInt32(10).ToString()); //Backup Contact's Phone Number
                            //if (!reader.IsDBNull(1))

                            lstStudents.Items.Add(student);
                        }
                        reader.Close();
                    }
                    connection.Close();
                }
            }
        }

        private void btnShowAllStudents_Click(object sender, EventArgs e)
        {
            lstStudents.Items.Clear();

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                String sql = "SELECT StudentID, FirstName, LastName, StudentGroup, MotherName, MotherPhone, FatherName, FatherPhone, ThirdName, ThirdRole, ThirdPhone FROM dbo.Students;";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ListViewItem student = new ListViewItem(reader.GetInt32(0).ToString()); //ID
                            student.SubItems.Add(reader.GetString(1)); //FirstName
                            student.SubItems.Add(reader.GetString(2)); //LastName
                            student.SubItems.Add(reader.GetString(3)); //Group
                            student.SubItems.Add(reader.GetString(4)); //Mother's Name
                            student.SubItems.Add(reader.GetInt32(5).ToString()); //Mother's Phone Number
                            if (!reader.IsDBNull(6))
                                student.SubItems.Add(reader.GetString(6)); //Father's Name
                            student.SubItems.Add(reader.GetInt32(7).ToString()); //Father's Phone Number
                            student.SubItems.Add(reader.GetString(8)); //Backup Contact's Name
                            student.SubItems.Add(reader.GetString(9)); //Backup Contact's Role
                            student.SubItems.Add(reader.GetInt32(10).ToString()); //Backup Contact's Phone Number
                            //if (!reader.IsDBNull(1))

                            lstStudents.Items.Add(student);
                        }
                        reader.Close();
                    }
                    connection.Close();
                }
            }
        }
    }
}
