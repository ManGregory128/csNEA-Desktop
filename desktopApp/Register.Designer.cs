namespace csNEA
{
    partial class Register
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            btnBack = new System.Windows.Forms.Button();
            txtNewUsername = new System.Windows.Forms.TextBox();
            txtNewPassword = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            btnAddUser = new System.Windows.Forms.Button();
            cmbRights = new System.Windows.Forms.ComboBox();
            label3 = new System.Windows.Forms.Label();
            txtFirstName = new System.Windows.Forms.TextBox();
            txtLastName = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // btnBack
            // 
            btnBack.Location = new System.Drawing.Point(18, 314);
            btnBack.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnBack.Name = "btnBack";
            btnBack.Size = new System.Drawing.Size(88, 27);
            btnBack.TabIndex = 0;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // txtNewUsername
            // 
            txtNewUsername.Location = new System.Drawing.Point(190, 89);
            txtNewUsername.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtNewUsername.Name = "txtNewUsername";
            txtNewUsername.Size = new System.Drawing.Size(116, 23);
            txtNewUsername.TabIndex = 1;
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new System.Drawing.Point(190, 121);
            txtNewPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new System.Drawing.Size(116, 23);
            txtNewPassword.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(86, 93);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(90, 15);
            label1.TabIndex = 3;
            label1.Text = "New Username:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(86, 124);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(87, 15);
            label2.TabIndex = 4;
            label2.Text = "New Password:";
            // 
            // btnAddUser
            // 
            btnAddUser.Location = new System.Drawing.Point(153, 263);
            btnAddUser.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new System.Drawing.Size(88, 27);
            btnAddUser.TabIndex = 5;
            btnAddUser.Text = "Add User";
            btnAddUser.UseVisualStyleBackColor = true;
            btnAddUser.Click += btnAddUser_Click;
            // 
            // cmbRights
            // 
            cmbRights.FormattingEnabled = true;
            cmbRights.Items.AddRange(new object[] { "Administrator", "Secretary", "Teacher" });
            cmbRights.Location = new System.Drawing.Point(190, 213);
            cmbRights.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cmbRights.Name = "cmbRights";
            cmbRights.Size = new System.Drawing.Size(116, 23);
            cmbRights.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(74, 216);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(99, 15);
            label3.TabIndex = 7;
            label3.Text = "User Rights Level:";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new System.Drawing.Point(190, 151);
            txtFirstName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new System.Drawing.Size(116, 23);
            txtFirstName.TabIndex = 8;
            // 
            // txtLastName
            // 
            txtLastName.Location = new System.Drawing.Point(190, 181);
            txtLastName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new System.Drawing.Size(116, 23);
            txtLastName.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(111, 154);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(67, 15);
            label4.TabIndex = 10;
            label4.Text = "First Name:";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(54, 184);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(123, 15);
            label5.TabIndex = 11;
            label5.Text = "Last Name (Optional):";
            // 
            // Register
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(405, 362);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Controls.Add(label3);
            Controls.Add(cmbRights);
            Controls.Add(btnAddUser);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtNewPassword);
            Controls.Add(txtNewUsername);
            Controls.Add(btnBack);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "Register";
            Padding = new System.Windows.Forms.Padding(4, 74, 4, 3);
            Text = "Add new user";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox txtNewUsername;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.ComboBox cmbRights;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}