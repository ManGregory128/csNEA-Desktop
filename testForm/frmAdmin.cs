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
    }
}
