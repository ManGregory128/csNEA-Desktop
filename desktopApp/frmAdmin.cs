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
using CsvHelper;
using System.Globalization;

namespace csNEA
{
    public partial class frmAdmin : Form
    {
        public static SqlConnectionStringBuilder builder { get; set; }
        public static string currentUser { get; set; }
        public frmAdmin()
        {
            InitializeComponent();
        }

        public static void SetDBinfo(string input, string password)
        {
            builder = new SqlConnectionStringBuilder
            {
                DataSource = input,
                UserID = "SA",
                Password = password,
                InitialCatalog = "kiti"
            };
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Register register = new Register();
            Register.SetDBinfo(builder);
            register.ShowDialog();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            //MessageBox.Show("Goodbye!");
            frmLogin logIn = new frmLogin();
            logIn.ShowDialog();
        }

        private void usersPage_Click(object sender, EventArgs e)
        {

        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            //reload all lists
            if (frmLogin.passRights == 'a')
            {
                UpdateUsersList();
                UpdateLessonsList();
                UpdateSemList();
            }

            UpdateGroupsList();
        }

        private void adminTabs_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (frmLogin.passRights == 's' && (adminTabs.SelectedTab == usersPage || adminTabs.SelectedTab == tabLessons || adminTabs.SelectedTab == datesPage))
            {
                MessageBox.Show("Unable to load tab. You have insufficient access privileges.");
                adminTabs.SelectedTab = tabAbsences;
            }

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = false;
            base.OnFormClosing(e);
            Application.Exit();
        }

        private void btnFeedPost_Click(object sender, EventArgs e)
        {
            DateTime rightNow = DateTime.Now;
            string input = Interaction.InputBox("Type your feed post below:", "Posting to the Feed", "", 0, 0);
            if (input == "")
            {
                MessageBox.Show("The post will not be uploaded."); //include test in word document
            }
            else
            {
                String sql = "Insert into Feed (Author, DateTimePosted, Post) " +
                "Values('" + currentUser + "', '" + rightNow.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + input + "');";
                ExecuteSQLInsert(sql);

                MessageBox.Show("Post Uploaded Successfully.");
            }
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
            string[,] schGroups = new string[7, 5];
            string scheduleFile = uploadSchDiag.FileName;
            try
            {
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
                reader.Close();
                MessageBox.Show("Now select the corresponding Groups file.");
                uploadSchDiag.ShowDialog();
                string groupsFile = uploadSchDiag.FileName;
                reader = new StreamReader(groupsFile);
                i = 0;
                while (!reader.EndOfStream && i < 7)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    for (int j = 0; j < 5; j++)
                    {
                        schGroups[i, j] = values[j];
                    }
                    i++;
                }
                reader.Close();
                UploadSchedule(schedule, schGroups);
            }
            catch
            {
                MessageBox.Show("You have not selected an appropriate file.");
            }
        }
        private void UploadSchedule(int[,] sc, string[,] scGrp)
        {
            int rowsAffected = 0;
            try
            {
                string selectedUser = lstUsers.SelectedItems[0].Text;
                ClearSchedule(selectedUser);
                int m, k; //increments day and period values to match database
                for (int i = 0; i < 5; i++)
                {
                    k = i + 1;
                    for (int j = 0; j < 7; j++)
                    {
                        m = j + 1;
                        using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                        {
                            String sql;
                            if (scGrp[j, i] == "NULL")
                            {
                                sql = "Insert into Teachings (PeriodID, LessonID, TeacherUsername, Day, GroupID) Values(" + m + ", " + sc[j, i] + ", '" + selectedUser + "', " + k + ", NULL);";
                            }
                            else
                            {
                                sql = "Insert into Teachings (PeriodID, LessonID, TeacherUsername, Day, GroupID) Values(" + m + ", " + sc[j, i] + ", '" + selectedUser + "', " + k + ", '" + scGrp[j, i] + "');";
                            }

                            using (SqlCommand command = new SqlCommand(sql, connection))
                            {
                                connection.Open();
                                rowsAffected = rowsAffected + command.ExecuteNonQuery();
                                connection.Close();
                            }
                        }
                    }
                }
                MessageBox.Show(rowsAffected + " teachings were uploaded successfully.");
            }
            catch
            {
                if (rowsAffected == 0)
                    MessageBox.Show("You have not selected a user from the list!");
                else
                    MessageBox.Show("The information provided in the file does not match the registered Lessons. Teachings created for user = " + rowsAffected + ".");
            }
        }
        private void ClearSchedule(string user)
        {
            String sql = "Delete from Teachings WHERE TeacherUsername='" + user + "';";
            ExecuteSQLInsert(sql);
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
                            cmbTeacherRep.Items.Add(reader.GetString(0));
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
                String sql = "Insert into Lessons (LessonID, LessonName) " +
                    "Values(" + txtLessonID.Text + ", '" + txtLesson.Text + "');";

                ExecuteSQLInsert(sql);
                UpdateLessonsList();
            }
        }

        private void tabLessons_Click(object sender, EventArgs e)
        {
            //maybe refresh list here
        }

        private void btnDelLesson_Click(object sender, EventArgs e)
        {
            if (lstLessons.Items.Count > 0 && lstLessons.SelectedItems.Count == 1)
            {
                string lessonToDelete = lstLessons.SelectedItems[0].Text;

                String sql = "DELETE FROM Lessons WHERE LessonID=" + lessonToDelete + ";";
                ExecuteSQLInsert(sql);

                sql = "DELETE FROM Teachings WHERE LessonID =" + lessonToDelete + ";";
                ExecuteSQLInsert(sql);

                MessageBox.Show("Lesson removed successfuly.");
                UpdateLessonsList();
            }
            else
                MessageBox.Show("You need to have a lesson from the list selected first.");
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            string username = lstUsers.SelectedItems[0].Text;
            string input = Interaction.InputBox("Type the new password below:", "Changing Password for " + username, "", 0, 0);
            string confirm = Interaction.InputBox("Repeat the new password below:", "Changing Password for " + username, "", 0, 0);
            if (input == confirm)
            {
                String sql = "UPDATE Users SET UserPassword='" + input + "' WHERE UserName='" + username + "';";
                ExecuteSQLInsert(sql);

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
                if (cmbTeacherRep.SelectedIndex == -1) { MessageBox.Show("You must select a teacher representative."); }
                else
                {
                    String sql = "Insert into Groups (GroupID, TeacherRep) Values('" + txtGroup.Text + "', '" + cmbTeacherRep.Text + "');";
                    ExecuteSQLInsert(sql);

                    UpdateGroupsList();
                }

            }
        }
        public void UpdateGroupsList()
        {
            lstGroups.Items.Clear();
            cmbInitialGroup.Items.Clear();
            cmbFinalGroup.Items.Clear();
            cmbGroups.Items.Clear();
            cmbAbsentGroups.Items.Clear();

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
                    tempStudent = new Student(0, values[0], values[1], values[2], values[3], values[4], values[5], values[6], int.Parse(values[7]), int.Parse(values[8]), int.Parse(values[9]));
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
                String sql = "Insert into Students (FirstName, LastName, StudentGroup, MotherName, MotherPhone, FatherName, FatherPhone, ThirdName, ThirdRole, ThirdPhone) " +
                    "Values('" + students[i].FirstName + "', '" + students[i].LastName + "', '" + students[i].Group + "', '" + students[i].MothersName + "', " + students[i].MotherPhone.ToString() + ", '" + students[i].FathersName + "', " + students[i].FatherPhone.ToString() + ", '" + students[i].ThirdName + "', '" + students[i].ThirdRole + "', " + students[i].ThirdPhone.ToString() + ");";

                ExecuteSQLInsert(sql);
            }
        }
        private void btnStudentManualAdd_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            RegisterStudent registerStudent = new RegisterStudent();
            RegisterStudent.SetDBinfo(builder);
            registerStudent.ShowDialog();
        }

        private void btnDisGroup_Click(object sender, EventArgs e)
        {
            lstStudents.Items.Clear();

            List<Student> students = DataHandler.GetStudents(cmbGroups.Text);
            foreach (Student student in students)
            {
                ListViewItem studentItem = new ListViewItem(student.StudentID.ToString());
                studentItem.SubItems.Add(student.FirstName);
                studentItem.SubItems.Add(student.LastName);
                studentItem.SubItems.Add(student.Group);
                studentItem.SubItems.Add(student.MothersName);
                studentItem.SubItems.Add(student.MotherPhone.ToString());
                studentItem.SubItems.Add(student.FathersName);
                studentItem.SubItems.Add(student.FatherPhone.ToString());
                studentItem.SubItems.Add(student.ThirdName);
                studentItem.SubItems.Add(student.ThirdRole);
                studentItem.SubItems.Add(student.ThirdPhone.ToString());
                lstStudents.Items.Add(studentItem);
            }
        }

        private void btnShowAllStudents_Click(object sender, EventArgs e)
        {
            lstStudents.Items.Clear();

            List<Student> students = DataHandler.GetStudents(String.Empty);
            foreach (Student student in students)
            {
                ListViewItem studentItem = new ListViewItem(student.StudentID.ToString());
                studentItem.SubItems.Add(student.FirstName);
                studentItem.SubItems.Add(student.LastName);
                studentItem.SubItems.Add(student.Group);
                studentItem.SubItems.Add(student.MothersName);
                studentItem.SubItems.Add(student.MotherPhone.ToString());
                studentItem.SubItems.Add(student.FathersName);
                studentItem.SubItems.Add(student.FatherPhone.ToString());
                studentItem.SubItems.Add(student.ThirdName);
                studentItem.SubItems.Add(student.ThirdRole);
                studentItem.SubItems.Add(student.ThirdPhone.ToString());
                lstStudents.Items.Add(studentItem);
            }
        }

        private void btnTransferStudents_Click(object sender, EventArgs e)
        {
            if (cmbFinalGroup.Text == null || cmbInitialGroup.Text == null)
                MessageBox.Show("You must select both groups!");
            else
            {
                String sql = "UPDATE Students SET StudentGroup = '" + cmbFinalGroup.Text + "' WHERE StudentGroup='" + cmbInitialGroup.Text + "';";
                ExecuteSQLInsert(sql);

                lstStudents.Items.Clear();
                MessageBox.Show("Done!");
                cmbInitialGroup.Text = "";
                cmbFinalGroup.Text = "";
            }
        }

        private void btnAddSemester_Click(object sender, EventArgs e)
        {
            bool semPresent = false;
            int semNo;
            if (!int.TryParse(txtSemNo.Text, out semNo))
            {
                MessageBox.Show("The semester ID must be a number.");
            }
            else
            {
                DateTime start = dtInitial.Value.Date;
                DateTime end = dtFinal.Value.Date;
                for (int i = 0; i < lstSemesters.Items.Count; i++) //validation for semester ID input
                {
                    if (lstSemesters.Items[i].Text == txtSemNo.Text)
                    {
                        semPresent = true;
                        break;
                    }
                }
                if (!semPresent)
                {
                    SetSemester(start.ToString("yyyy-MM-dd"), end.ToString("yyyy-MM-dd"), semNo);
                    for (var dt = start; dt <= end; dt = dt.AddDays(1))
                    {
                        UploadDate(dt, semNo);
                    }
                    MessageBox.Show("Semester Created Successfully and Dates were created.");
                    UpdateSemList();
                }
                else
                    MessageBox.Show("This semester ID has already been used, enter a new semester ID.");
            }
        }
        private void SetSemester(string start, string end, int semester)
        {
            String sql = "Insert into Semesters (SemesterNumber, StartDate, EndDate) Values(" + semester + ", '" + start + "', '" + end + "');";

            ExecuteSQLInsert(sql);
        }
        private void UploadDate(DateTime date, int semester)
        {
            string dateString = date.ToString("yyyy-MM-dd");
            string day = date.DayOfWeek.ToString();
            int dayToInt;
            switch (day)
            {
                case "Monday":
                    dayToInt = 1;
                    break;
                case "Tuesday":
                    dayToInt = 2;
                    break;
                case "Wednesday":
                    dayToInt = 3;
                    break;
                case "Thursday":
                    dayToInt = 4;
                    break;
                case "Friday":
                    dayToInt = 5;
                    break;
                case "Saturday":
                    dayToInt = 6;
                    break;
                default:
                    dayToInt = 7;
                    break;
            }
            String sql = "Insert into Dates (Date, SemesterNumber, DayNumber, IsHoliday) Values('" + dateString + "', " + semester + ", " + dayToInt + ", 0);";

            ExecuteSQLInsert(sql);
        }
        private void UpdateSemList()
        {
            lstSemesters.Items.Clear();

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                String sql = "SELECT SemesterNumber, StartDate, EndDate FROM dbo.Semesters";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                            int x = (byte)reader[0];
                            ListViewItem semester = new ListViewItem(x.ToString());
                            semester.SubItems.Add(reader.GetDateTime(1).ToString("yyyy-MMM-dd"));
                            semester.SubItems.Add(reader.GetDateTime(2).ToString("yyyy-MMM-dd"));
                            lstSemesters.Items.Add(semester);
                        }
                        reader.Close();
                    }
                    connection.Close();
                }
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteSem_Click(object sender, EventArgs e)
        {
            DateTime startDate = dtInitial.Value, endDate = dtFinal.Value;
            int semToDelete = int.Parse(lstSemesters.SelectedItems[0].Text);
            String sql;
            string message = "Are you sure you want to remove the semester and all associated data?";
            string title = "Confirmation";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    sql = "SELECT StartDate, EndDate FROM dbo.Semesters WHERE SemesterNumber = " + semToDelete + ";";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                startDate = reader.GetDateTime(0);
                                endDate = reader.GetDateTime(1);
                            }
                            reader.Close();
                        }
                        connection.Close();
                    }
                }
                for (var dt = startDate; dt <= endDate; dt = dt.AddDays(1))
                {
                    DeleteAbsencesFromDate(dt);
                }
                //delete all Absences for these dates
                sql = "DELETE FROM Dates WHERE SemesterNumber=" + semToDelete + ";";
                ExecuteSQLInsert(sql);

                sql = "DELETE FROM Semesters WHERE SemesterNumber=" + semToDelete + ";";
                ExecuteSQLInsert(sql);

                UpdateSemList();
            }
        }
        private void DeleteAbsencesFromDate(DateTime date)
        {
            String sql = "DELETE FROM Attendances WHERE Date='" + date.ToString("yyyy-MM-dd") + "';";
            ExecuteSQLInsert(sql);
        }

        private void btnGroupAbsent_Click(object sender, EventArgs e)
        {
            lstAbsences.Items.Clear();
            string group;
            DateTime selectedDT = dtRegistrar.Value;
            int period = Convert.ToInt32(Math.Round(nmPeriod.Value, 0));
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                String sql;
                if (cmbAbsentGroups.Text != null)
                {
                    sql = "SELECT Attendances.StudentID, Students.FirstName, Students.LastName, Students.StudentGroup, Students.MotherName, Students.MotherPhone, Students.FatherName, Students.FatherPhone, Students.ThirdName, Students.ThirdRole, Students.ThirdPhone FROM Attendances " +
                    "INNER JOIN Students ON Attendances.StudentID = Students.StudentID WHERE Date = '" + selectedDT.ToString("yyyy-MM-dd") + "' AND Period = " + period + " AND IsPresent = 0;";
                }
                else
                {
                    group = cmbAbsentGroups.Text;
                    sql = "SELECT Attendances.StudentID, Students.FirstName, Students.LastName, Students.StudentGroup, Students.MotherName, Students.MotherPhone, Students.FatherName, Students.FatherPhone, Students.ThirdName, Students.ThirdRole, Students.ThirdPhone FROM Attendances " +
                    "INNER JOIN Students ON Attendances.StudentID = Students.StudentID WHERE StudentGroup='" + group + "' AND Date = '" + selectedDT.ToString("yyyy-MM-dd") + "' AND Period = " + period + " AND IsPresent = 0;";
                }

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ListViewItem student = new ListViewItem(reader.GetInt32(0).ToString());
                            student.SubItems.Add(reader.GetString(1));
                            student.SubItems.Add(reader.GetString(2));
                            student.SubItems.Add(reader.GetString(3));
                            student.SubItems.Add(reader.GetString(4)); //Mother's Name
                            student.SubItems.Add(reader.GetInt32(5).ToString()); //Mother's Phone Number                            
                            student.SubItems.Add(reader.GetString(6)); //Father's Name
                            student.SubItems.Add(reader.GetInt32(7).ToString()); //Father's Phone Number
                            student.SubItems.Add(reader.GetString(8)); //Backup Contact's Name
                            if (!reader.IsDBNull(9))
                                student.SubItems.Add(reader.GetString(9)); //Backup Contact's Role
                            student.SubItems.Add(reader.GetInt32(10).ToString()); //Backup Contact's Phone Number
                            lstAbsences.Items.Add(student);
                        }
                        reader.Close();
                    }
                    connection.Close();
                }
            }
        }

        private void btnFlatGen_Click(object sender, EventArgs e)
        {
            string group;
            DateTime selectedDT = dtRegistrar.Value;
            int period = Convert.ToInt32(Math.Round(nmPeriod.Value, 0));
            List<Student> studentsToCsv = new List<Student>();
            Student tempStudent;
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                String sql;
                if (cmbAbsentGroups.Text != null)
                {
                    sql = "SELECT Attendances.StudentID, Students.FirstName, Students.LastName, Students.StudentGroup, Students.MotherName, Students.MotherPhone, Students.FatherName, Students.FatherPhone, Students.ThirdName, Students.ThirdRole, Students.ThirdPhone FROM Attendances " +
                    "INNER JOIN Students ON Attendances.StudentID = Students.StudentID WHERE Date = '" + selectedDT.ToString("yyyy-MM-dd") + "' AND Period = " + period + " AND IsPresent = 0;";
                }
                else
                {
                    group = cmbAbsentGroups.Text;
                    sql = "SELECT Attendances.StudentID, Students.FirstName, Students.LastName, Students.StudentGroup, Students.MotherName, Students.MotherPhone, Students.FatherName, Students.FatherPhone, Students.ThirdName, Students.ThirdRole, Students.ThirdPhone FROM Attendances " +
                    "INNER JOIN Students ON Attendances.StudentID = Students.StudentID WHERE StudentGroup='" + group + "' AND Date = '" + selectedDT.ToString("yyyy-MM-dd") + "' AND Period = " + period + " AND IsPresent = 0;";
                }

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tempStudent = new Student(0, reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(6), reader.GetString(8), reader.GetString(9), reader.GetInt32(5), reader.GetInt32(7), reader.GetInt32(10));
                            studentsToCsv.Add(tempStudent);
                        }
                        reader.Close();
                    }
                    connection.Close();
                }
            }
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    using (var writer = new StreamWriter(fbd.SelectedPath + "\\absences-on-" + selectedDT.ToString("yyyy-MM-dd") + ".csv"))
                    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        csv.WriteRecords(studentsToCsv);
                    }
                }
            }

        }

        private void btnRemoveUser_Click(object sender, EventArgs e)
        {
            //must check if something is selected, then if user is logged in, then if the user is trying to delete themselves
            if (lstUsers.SelectedItems.Count == 1)
            {
                if (frmLogin.passUser == lstUsers.SelectedItems[0].Text)
                {
                    MessageBox.Show("You cannot remove yourself!");
                }
                else
                {
                    if (lstUsers.SelectedItems[0].SubItems[4].Text == "True")
                    {
                        MessageBox.Show("This user is currently logged in. Have them log out first.");
                    }
                    else
                    {
                        string userToDelete = lstUsers.SelectedItems[0].Text;
                        string message = "Are you sure you want to delete user " + userToDelete + "?";
                        string title = "Confirmation";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result = MessageBox.Show(message, title, buttons);
                        if (result == DialogResult.Yes)
                        {
                            String sql;
                            if (lstUsers.SelectedItems[0].SubItems[3].Text == "t")
                            {
                                sql = "UPDATE Groups SET TeacherRep = null WHERE TeacherRep = '" + userToDelete + "';"; //Removes teacher as Representative of any other group.
                                ExecuteSQLInsert(sql);
                                sql = "DELETE FROM dbo.Teachings WHERE TeacherUsername = '" + userToDelete + "';";
                                ExecuteSQLInsert(sql);
                                //absences can remain unaffected.
                            }

                            if (frmLogin.passRights == 'a' || frmLogin.passRights == 's')
                            {
                                sql = "DELETE FROM dbo.Feed WHERE Author = '" + userToDelete + "';";
                                ExecuteSQLInsert(sql);
                            }

                            sql = "DELETE FROM dbo.Users WHERE UserName = '" + userToDelete + "';";
                            ExecuteSQLInsert(sql);

                            UpdateUsersList();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("You have not selected a user.");
            }
        }

        private void ExecuteSQLInsert(String sqlCommand)
        {
            StringBuilder errorMessages = new StringBuilder();
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sqlCommand, connection))
                {
                    try
                    {
                        connection.Open();
                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch (SqlException ex)
                        {
                            for (int i = 0; i < ex.Errors.Count; i++)
                            {
                                errorMessages.Append("Message: " + ex.Errors[i].Message);
                            }
                            if (errorMessages.ToString().Contains("Violation of PRIMARY KEY") && errorMessages.ToString().Contains("dbo.Lessons"))
                                MessageBox.Show("The database already contains a lesson with this ID. Try entering a new ID");
                            else if (errorMessages.ToString().Contains("Violation of PRIMARY KEY") && errorMessages.ToString().Contains("dbo.Group"))
                                MessageBox.Show("This group already exists.");
                            else
                                MessageBox.Show(errorMessages.ToString());
                        }
                        connection.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Could not reach the database. Check your connection.");
                    }
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e) //delete student from Students, Absences
        {
            if (lstStudents.SelectedItems.Count == 1)
            {
                string StudentID = lstStudents.SelectedItems[0].Text;
                string message = "Are you sure you want to delete student with ID " + StudentID + "?";
                string title = "Confirmation";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    String sql = "DELETE FROM dbo.Attendances WHERE StudentID = " + StudentID + ";";
                    ExecuteSQLInsert(sql);

                    sql = "DELETE FROM dbo.Students WHERE StudentID = " + StudentID + ";";
                    ExecuteSQLInsert(sql);

                    lstStudents.SelectedItems[0].Remove();
                }
                else
                {
                    MessageBox.Show("The student will not be deleted.");
                }
            }
            else
                MessageBox.Show("You need to select a student from the list first.");
        }

        private void btnRemoveGrpAndStudents_Click(object sender, EventArgs e)
        {

        }
    }
}
