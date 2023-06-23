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
            txtUser = new MaterialSkin.Controls.MaterialTextBox();
            lblUser = new MaterialSkin.Controls.MaterialLabel();
            txtPassword = new MaterialSkin.Controls.MaterialTextBox();
            lblPasswd = new MaterialSkin.Controls.MaterialLabel();
            lblSchool = new MaterialSkin.Controls.MaterialLabel();
            groupBox1 = new System.Windows.Forms.GroupBox();
            chckRetainDBPass = new MaterialSkin.Controls.MaterialCheckbox();
            btnConnectDB = new MaterialSkin.Controls.MaterialButton();
            lblDBPasswd = new MaterialSkin.Controls.MaterialLabel();
            txtDBPassword = new MaterialSkin.Controls.MaterialTextBox();
            cmbSchool = new MaterialSkin.Controls.MaterialComboBox();
            groupBox2 = new System.Windows.Forms.GroupBox();
            btnConnect = new MaterialSkin.Controls.MaterialButton();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // txtUser
            // 
            txtUser.Anchor = System.Windows.Forms.AnchorStyles.Top;
            txtUser.AnimateReadOnly = false;
            txtUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtUser.Depth = 0;
            txtUser.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            txtUser.LeadingIcon = null;
            txtUser.Location = new System.Drawing.Point(25, 58);
            txtUser.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtUser.MaxLength = 50;
            txtUser.MouseState = MaterialSkin.MouseState.OUT;
            txtUser.Multiline = false;
            txtUser.Name = "txtUser";
            txtUser.Size = new System.Drawing.Size(173, 50);
            txtUser.TabIndex = 1;
            txtUser.Text = "";
            txtUser.TrailingIcon = null;
            // 
            // lblUser
            // 
            lblUser.Anchor = System.Windows.Forms.AnchorStyles.Top;
            lblUser.AutoSize = true;
            lblUser.Depth = 0;
            lblUser.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            lblUser.Location = new System.Drawing.Point(25, 36);
            lblUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblUser.MouseState = MaterialSkin.MouseState.HOVER;
            lblUser.Name = "lblUser";
            lblUser.Size = new System.Drawing.Size(76, 19);
            lblUser.TabIndex = 2;
            lblUser.Text = "Username:";
            // 
            // txtPassword
            // 
            txtPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
            txtPassword.AnimateReadOnly = false;
            txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtPassword.Depth = 0;
            txtPassword.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            txtPassword.LeadingIcon = null;
            txtPassword.Location = new System.Drawing.Point(25, 142);
            txtPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtPassword.MaxLength = 50;
            txtPassword.MouseState = MaterialSkin.MouseState.OUT;
            txtPassword.Multiline = false;
            txtPassword.Name = "txtPassword";
            txtPassword.Password = true;
            txtPassword.Size = new System.Drawing.Size(173, 50);
            txtPassword.TabIndex = 3;
            txtPassword.Text = "";
            txtPassword.TrailingIcon = null;
            // 
            // lblPasswd
            // 
            lblPasswd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            lblPasswd.AutoSize = true;
            lblPasswd.Depth = 0;
            lblPasswd.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            lblPasswd.Location = new System.Drawing.Point(25, 120);
            lblPasswd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblPasswd.MouseState = MaterialSkin.MouseState.HOVER;
            lblPasswd.Name = "lblPasswd";
            lblPasswd.Size = new System.Drawing.Size(75, 19);
            lblPasswd.TabIndex = 4;
            lblPasswd.Text = "Password:";
            // 
            // lblSchool
            // 
            lblSchool.Anchor = System.Windows.Forms.AnchorStyles.Top;
            lblSchool.AutoSize = true;
            lblSchool.Depth = 0;
            lblSchool.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            lblSchool.Location = new System.Drawing.Point(55, 222);
            lblSchool.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblSchool.MouseState = MaterialSkin.MouseState.HOVER;
            lblSchool.Name = "lblSchool";
            lblSchool.Size = new System.Drawing.Size(101, 19);
            lblSchool.TabIndex = 6;
            lblSchool.Text = "Select School:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(chckRetainDBPass);
            groupBox1.Controls.Add(btnConnectDB);
            groupBox1.Controls.Add(lblDBPasswd);
            groupBox1.Controls.Add(txtDBPassword);
            groupBox1.Controls.Add(cmbSchool);
            groupBox1.Controls.Add(lblSchool);
            groupBox1.Location = new System.Drawing.Point(316, 75);
            groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox1.Size = new System.Drawing.Size(256, 316);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Database Information";
            // 
            // chckRetainDBPass
            // 
            chckRetainDBPass.AutoSize = true;
            chckRetainDBPass.Depth = 0;
            chckRetainDBPass.Location = new System.Drawing.Point(16, 111);
            chckRetainDBPass.Margin = new System.Windows.Forms.Padding(0);
            chckRetainDBPass.MouseLocation = new System.Drawing.Point(-1, -1);
            chckRetainDBPass.MouseState = MaterialSkin.MouseState.HOVER;
            chckRetainDBPass.Name = "chckRetainDBPass";
            chckRetainDBPass.ReadOnly = false;
            chckRetainDBPass.Ripple = true;
            chckRetainDBPass.Size = new System.Drawing.Size(210, 37);
            chckRetainDBPass.TabIndex = 13;
            chckRetainDBPass.Text = "Remember DB Password";
            chckRetainDBPass.UseVisualStyleBackColor = true;
            // 
            // btnConnectDB
            // 
            btnConnectDB.Anchor = System.Windows.Forms.AnchorStyles.Top;
            btnConnectDB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnConnectDB.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnConnectDB.Depth = 0;
            btnConnectDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnConnectDB.HighEmphasis = true;
            btnConnectDB.Icon = null;
            btnConnectDB.Location = new System.Drawing.Point(55, 165);
            btnConnectDB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnConnectDB.MouseState = MaterialSkin.MouseState.HOVER;
            btnConnectDB.Name = "btnConnectDB";
            btnConnectDB.NoAccentTextColor = System.Drawing.Color.Empty;
            btnConnectDB.Size = new System.Drawing.Size(134, 36);
            btnConnectDB.TabIndex = 12;
            btnConnectDB.Text = "Connect to DB";
            btnConnectDB.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnConnectDB.UseAccentColor = false;
            btnConnectDB.UseVisualStyleBackColor = true;
            btnConnectDB.Click += btnConnectDB_Click;
            // 
            // lblDBPasswd
            // 
            lblDBPasswd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            lblDBPasswd.AutoSize = true;
            lblDBPasswd.Depth = 0;
            lblDBPasswd.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            lblDBPasswd.Location = new System.Drawing.Point(25, 36);
            lblDBPasswd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblDBPasswd.MouseState = MaterialSkin.MouseState.HOVER;
            lblDBPasswd.Name = "lblDBPasswd";
            lblDBPasswd.Size = new System.Drawing.Size(183, 19);
            lblDBPasswd.TabIndex = 9;
            lblDBPasswd.Text = "Enter Local DB Password:";
            // 
            // txtDBPassword
            // 
            txtDBPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
            txtDBPassword.AnimateReadOnly = false;
            txtDBPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtDBPassword.Depth = 0;
            txtDBPassword.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            txtDBPassword.LeadingIcon = null;
            txtDBPassword.Location = new System.Drawing.Point(25, 58);
            txtDBPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtDBPassword.MaxLength = 50;
            txtDBPassword.MouseState = MaterialSkin.MouseState.OUT;
            txtDBPassword.Multiline = false;
            txtDBPassword.Name = "txtDBPassword";
            txtDBPassword.Password = true;
            txtDBPassword.Size = new System.Drawing.Size(210, 50);
            txtDBPassword.TabIndex = 8;
            txtDBPassword.Text = "";
            txtDBPassword.TrailingIcon = null;
            // 
            // cmbSchool
            // 
            cmbSchool.AutoResize = false;
            cmbSchool.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            cmbSchool.Depth = 0;
            cmbSchool.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            cmbSchool.DropDownHeight = 174;
            cmbSchool.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbSchool.DropDownWidth = 121;
            cmbSchool.Enabled = false;
            cmbSchool.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            cmbSchool.ForeColor = System.Drawing.Color.FromArgb(222, 0, 0, 0);
            cmbSchool.FormattingEnabled = true;
            cmbSchool.IntegralHeight = false;
            cmbSchool.ItemHeight = 43;
            cmbSchool.Location = new System.Drawing.Point(55, 240);
            cmbSchool.MaxDropDownItems = 4;
            cmbSchool.MouseState = MaterialSkin.MouseState.OUT;
            cmbSchool.Name = "cmbSchool";
            cmbSchool.Size = new System.Drawing.Size(134, 49);
            cmbSchool.StartIndex = 0;
            cmbSchool.TabIndex = 7;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtPassword);
            groupBox2.Controls.Add(txtUser);
            groupBox2.Controls.Add(lblUser);
            groupBox2.Controls.Add(lblPasswd);
            groupBox2.Location = new System.Drawing.Point(25, 75);
            groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox2.Size = new System.Drawing.Size(248, 225);
            groupBox2.TabIndex = 11;
            groupBox2.TabStop = false;
            groupBox2.Text = "User Information";
            // 
            // btnConnect
            // 
            btnConnect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnConnect.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnConnect.Depth = 0;
            btnConnect.Enabled = false;
            btnConnect.HighEmphasis = true;
            btnConnect.Icon = null;
            btnConnect.Location = new System.Drawing.Point(108, 328);
            btnConnect.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btnConnect.MouseState = MaterialSkin.MouseState.HOVER;
            btnConnect.Name = "btnConnect";
            btnConnect.NoAccentTextColor = System.Drawing.Color.Empty;
            btnConnect.Size = new System.Drawing.Size(68, 36);
            btnConnect.TabIndex = 12;
            btnConnect.Text = "Log In";
            btnConnect.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnConnect.UseAccentColor = false;
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // frmLogin
            // 
            AcceptButton = btnConnect;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(633, 459);
            Controls.Add(btnConnect);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "frmLogin";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Login";
            Load += frmLogin_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MaterialSkin.Controls.MaterialTextBox txtUser;
        private MaterialSkin.Controls.MaterialLabel lblUser;
        private MaterialSkin.Controls.MaterialTextBox txtPassword;
        private MaterialSkin.Controls.MaterialLabel lblPasswd;
        private MaterialSkin.Controls.MaterialLabel lblSchool;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private MaterialSkin.Controls.MaterialComboBox cmbSchool;
        private MaterialSkin.Controls.MaterialButton btnConnectDB;
        private MaterialSkin.Controls.MaterialLabel lblDBPasswd;
        private MaterialSkin.Controls.MaterialTextBox txtDBPassword;
        private MaterialSkin.Controls.MaterialCheckbox chckRetainDBPass;
        private MaterialSkin.Controls.MaterialButton btnConnect;
    }
}

