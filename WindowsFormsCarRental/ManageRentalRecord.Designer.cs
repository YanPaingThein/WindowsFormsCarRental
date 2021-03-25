
namespace WindowsFormsCarRental
{
    partial class ManageRentalRecord
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
            this.bthDeleteRecord = new System.Windows.Forms.Button();
            this.btnEditRecord = new System.Windows.Forms.Button();
            this.btnAddRecord = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.gvRecordList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gvRecordList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRefreshList
            // 
            this.btnRefreshList.Location = new System.Drawing.Point(575, 322);
            this.btnRefreshList.Name = "btnRefreshList";
            this.btnRefreshList.Size = new System.Drawing.Size(123, 38);
            this.btnRefreshList.TabIndex = 11;
            this.btnRefreshList.Text = "Refresh List";
            this.btnRefreshList.UseVisualStyleBackColor = true;
            this.btnRefreshList.Click += new System.EventHandler(this.btnRefreshList_Click);
            // 
            // bthDeleteRecord
            // 
            this.bthDeleteRecord.Location = new System.Drawing.Point(397, 322);
            this.bthDeleteRecord.Name = "bthDeleteRecord";
            this.bthDeleteRecord.Size = new System.Drawing.Size(123, 38);
            this.bthDeleteRecord.TabIndex = 10;
            this.bthDeleteRecord.Text = "Delete Record";
            this.bthDeleteRecord.UseVisualStyleBackColor = true;
            this.bthDeleteRecord.Click += new System.EventHandler(this.bthDeleteRecord_Click);
            // 
            // btnEditRecord
            // 
            this.btnEditRecord.Location = new System.Drawing.Point(212, 322);
            this.btnEditRecord.Name = "btnEditRecord";
            this.btnEditRecord.Size = new System.Drawing.Size(123, 38);
            this.btnEditRecord.TabIndex = 9;
            this.btnEditRecord.Text = "Edit Record";
            this.btnEditRecord.UseVisualStyleBackColor = true;
            this.btnEditRecord.Click += new System.EventHandler(this.btnEditRecord_Click);
            // 
            // btnAddRecord
            // 
            this.btnAddRecord.Location = new System.Drawing.Point(23, 322);
            this.btnAddRecord.Name = "btnAddRecord";
            this.btnAddRecord.Size = new System.Drawing.Size(123, 38);
            this.btnAddRecord.TabIndex = 8;
            this.btnAddRecord.Text = "Add New Record";
            this.btnAddRecord.UseVisualStyleBackColor = true;
            this.btnAddRecord.Click += new System.EventHandler(this.btnAddRecord_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label1.Location = new System.Drawing.Point(119, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(489, 54);
            this.label1.TabIndex = 7;
            this.label1.Text = "Manage Record Listing";
            // 
            // gvRecordList
            // 
            this.gvRecordList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvRecordList.Location = new System.Drawing.Point(23, 66);
            this.gvRecordList.Name = "gvRecordList";
            this.gvRecordList.Size = new System.Drawing.Size(675, 239);
            this.gvRecordList.TabIndex = 6;
            // 
            // ManageRenatlRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 372);
            this.Controls.Add(this.btnRefreshList);
            this.Controls.Add(this.bthDeleteRecord);
            this.Controls.Add(this.btnEditRecord);
            this.Controls.Add(this.btnAddRecord);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gvRecordList);
            this.Name = "ManageRenatlRecord";
            this.Text = "Manage Renatl Record";
            this.Load += new System.EventHandler(this.ManageRenatlRecord_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvRecordList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRefreshList;
        private System.Windows.Forms.Button bthDeleteRecord;
        private System.Windows.Forms.Button btnEditRecord;
        private System.Windows.Forms.Button btnAddRecord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gvRecordList;
    }
}