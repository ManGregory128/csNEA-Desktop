namespace csNEA
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            btnConnect = new System.Windows.Forms.Button();
            txtUser = new System.Windows.Forms.TextBox();
            lblUser = new System.Windows.Forms.Label();
            txtPassword = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            chckRetainDBPass = new System.Windows.Forms.CheckBox();
            btnConnectDB = new System.Windows.Forms.Button();
            label3 = new System.Windows.Forms.Label();
            txtDBPassword = new System.Windows.Forms.TextBox();
            cmbSchool = new System.Windows.Forms.ComboBox();
            groupBox2 = new System.Windows.Forms.GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // btnConnect
            // 
            btnConnect.Anchor = System.Windows.Forms.AnchorStyles.Top;
            btnConnect.Enabled = false;
            btnConnect.Location = new System.Drawing.Point(70, 179);
            btnConnect.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new System.Drawing.Size(132, 27);
            btnConnect.TabIndex = 0;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // txtUser
            // 
            txtUser.Anchor = System.Windows.Forms.AnchorStyles.Top;
            txtUser.Location = new System.Drawing.Point(97, 36);
            txtUser.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtUser.Name = "txtUser";
            txtUser.Size = new System.Drawing.Size(116, 23);
            txtUser.TabIndex = 1;
            // 
            // lblUser
            // 
            lblUser.Anchor = System.Windows.Forms.AnchorStyles.Top;
            lblUser.AutoSize = true;
            lblUser.Location = new System.Drawing.Point(22, 39);
            lblUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblUser.Name = "lblUser";
            lblUser.Size = new System.Drawing.Size(63, 15);
            lblUser.TabIndex = 2;
            lblUser.Text = "Username:";
            // 
            // txtPassword
            // 
            txtPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
            txtPassword.Location = new System.Drawing.Point(97, 66);
            txtPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new System.Drawing.Size(116, 23);
            txtPassword.TabIndex = 3;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(22, 69);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(60, 15);
            label1.TabIndex = 4;
            label1.Text = "Password:";
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(25, 165);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(80, 15);
            label2.TabIndex = 6;
            label2.Text = "Select School:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(chckRetainDBPass);
            groupBox1.Controls.Add(btnConnectDB);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtDBPassword);
            groupBox1.Controls.Add(cmbSchool);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new System.Drawing.Point(267, 14);
            groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox1.Size = new System.Drawing.Size(182, 221);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Database Information";
            // 
            // chckRetainDBPass
            // 
            chckRetainDBPass.AutoSize = true;
            chckRetainDBPass.Location = new System.Drawing.Point(17, 82);
            chckRetainDBPass.Name = "chckRetainDBPass";
            chckRetainDBPass.Size = new System.Drawing.Size(155, 19);
            chckRetainDBPass.TabIndex = 13;
            chckRetainDBPass.Text = "Remember DB Password";
            chckRetainDBPass.UseVisualStyleBackColor = true;
            // 
            // btnConnectDB
            // 
            btnConnectDB.Anchor = System.Windows.Forms.AnchorStyles.Top;
            btnConnectDB.Location = new System.Drawing.Point(34, 107);
            btnConnectDB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnConnectDB.Name = "btnConnectDB";
            btnConnectDB.Size = new System.Drawing.Size(121, 40);
            btnConnectDB.TabIndex = 12;
            btnConnectDB.Text = "Establish DB Connection";
            btnConnectDB.UseVisualStyleBackColor = true;
            btnConnectDB.Click += btnConnectDB_Click;
            // 
            // label3
            // 
            label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(25, 27);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(139, 15);
            label3.TabIndex = 9;
            label3.Text = "Enter Local DB Password:";
            // 
            // txtDBPassword
            // 
            txtDBPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
            txtDBPassword.Location = new System.Drawing.Point(25, 45);
            txtDBPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtDBPassword.Name = "txtDBPassword";
            txtDBPassword.PasswordChar = '*';
            txtDBPassword.Size = new System.Drawing.Size(139, 23);
            txtDBPassword.TabIndex = 8;
            // 
            // cmbSchool
            // 
            cmbSchool.Enabled = false;
            cmbSchool.FormattingEnabled = true;
            cmbSchool.Location = new System.Drawing.Point(25, 183);
            cmbSchool.Name = "cmbSchool";
            cmbSchool.Size = new System.Drawing.Size(139, 23);
            cmbSchool.TabIndex = 7;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtPassword);
            groupBox2.Controls.Add(txtUser);
            groupBox2.Controls.Add(lblUser);
            groupBox2.Controls.Add(label1);
            groupBox2.Location = new System.Drawing.Point(14, 14);
            groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox2.Size = new System.Drawing.Size(233, 137);
            groupBox2.TabIndex = 11;
            groupBox2.TabStop = false;
            groupBox2.Text = "User Information";
            // 
            // frmLogin
            // 
            AcceptButton = btnConnect;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(479, 266);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnConnect);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "frmLogin";
            Text = "Login";
            Load += frmLogin_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbSchool;
        private System.Windows.Forms.Button btnConnectDB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDBPassword;
        private System.Windows.Forms.CheckBox chckRetainDBPass;
    }
}

