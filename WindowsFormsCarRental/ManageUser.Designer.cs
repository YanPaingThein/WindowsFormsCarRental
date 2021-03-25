
namespace WindowsFormsCarRental
{
    partial class ManageUser
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
            this.btnRefreshList = new System.Windows.Forms.Button();
            this.bthDeactivateUser = new System.Windows.Forms.Button();
            this.btnResetPassword = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.gvUserList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gvUserList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRefreshList
            // 
            this.btnRefreshList.Location = new System.Drawing.Point(27, 65);
            this.btnRefreshList.Name = "btnRefreshList";
            this.btnRefreshList.Size = new System.Drawing.Size(123, 38);
            this.btnRefreshList.TabIndex = 11;
            this.btnRefreshList.Text = "Refresh List";
            this.btnRefreshList.UseVisualStyleBackColor = true;
            this.btnRefreshList.Click += new System.EventHandler(this.btnRefreshList_Click);
            // 
            // bthDeactivateUser
            // 
            this.bthDeactivateUser.Location = new System.Drawing.Point(382, 365);
            this.bthDeactivateUser.Name = "bthDeactivateUser";
            this.bthDeactivateUser.Size = new System.Drawing.Size(140, 38);
            this.bthDeactivateUser.TabIndex = 10;
            this.bthDeactivateUser.Text = "Deactivate/ Activate User";
            this.bthDeactivateUser.UseVisualStyleBackColor = true;
            this.bthDeactivateUser.Click += new System.EventHandler(this.bthDeactivateUser_Click);
            // 
            // btnResetPassword
            // 
            this.btnResetPassword.Location = new System.Drawing.Point(205, 365);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(123, 38);
            this.btnResetPassword.TabIndex = 9;
            this.btnResetPassword.Text = "Reset Password";
            this.btnResetPassword.UseVisualStyleBackColor = true;
            this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(25, 365);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(123, 38);
            this.btnAddUser.TabIndex = 8;
            this.btnAddUser.Text = "Add New User";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label1.Location = new System.Drawing.Point(151, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 54);
            this.label1.TabIndex = 7;
            this.label1.Text = "Manage User";
            // 
            // gvUserList
            // 
            this.gvUserList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvUserList.Location = new System.Drawing.Point(27, 109);
            this.gvUserList.Name = "gvUserList";
            this.gvUserList.Size = new System.Drawing.Size(495, 239);
            this.gvUserList.TabIndex = 6;
            // 
            // ManageUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 431);
            this.Controls.Add(this.btnRefreshList);
            this.Controls.Add(this.bthDeactivateUser);
            this.Controls.Add(this.btnResetPassword);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gvUserList);
            this.Name = "ManageUser";
            this.Text = "Manage User";
            this.Load += new System.EventHandler(this.ManageUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvUserList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRefreshList;
        private System.Windows.Forms.Button bthDeactivateUser;
        private System.Windows.Forms.Button btnResetPassword;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gvUserList;
    }
}