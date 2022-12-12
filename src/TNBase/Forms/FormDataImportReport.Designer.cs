namespace TNBase.Forms
{
    partial class FormDataImportReport
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
            this.ErrorListView = new System.Windows.Forms.ListView();
            this.rowNumber = new System.Windows.Forms.ColumnHeader();
            this.Error = new System.Windows.Forms.ColumnHeader();
            this.ImportStatusLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ImportedCountLabel = new System.Windows.Forms.Label();
            this.FailedCountLabel = new System.Windows.Forms.Label();
            this.TotalCountLabel = new System.Windows.Forms.Label();
            this.GetFailedRecordsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ErrorListView
            // 
            this.ErrorListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ErrorListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.rowNumber,
            this.Error});
            this.ErrorListView.FullRowSelect = true;
            this.ErrorListView.HideSelection = false;
            this.ErrorListView.Location = new System.Drawing.Point(12, 248);
            this.ErrorListView.Name = "ErrorListView";
            this.ErrorListView.Size = new System.Drawing.Size(1588, 569);
            this.ErrorListView.TabIndex = 1;
            this.ErrorListView.UseCompatibleStateImageBehavior = false;
            this.ErrorListView.View = System.Windows.Forms.View.Details;
            // 
            // rowNumber
            // 
            this.rowNumber.Text = "Row Number";
            this.rowNumber.Width = 180;
            // 
            // Error
            // 
            this.Error.Text = "Error Message";
            this.Error.Width = 1370;
            // 
            // ImportStatusLabel
            // 
            this.ImportStatusLabel.AutoSize = true;
            this.ImportStatusLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ImportStatusLabel.ForeColor = System.Drawing.Color.Green;
            this.ImportStatusLabel.Location = new System.Drawing.Point(33, 36);
            this.ImportStatusLabel.Name = "ImportStatusLabel";
            this.ImportStatusLabel.Size = new System.Drawing.Size(298, 65);
            this.ImportStatusLabel.TabIndex = 0;
            this.ImportStatusLabel.Text = "ImportStatus";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(1176, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 50);
            this.label1.TabIndex = 2;
            this.label1.Text = "Imported:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(1234, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 50);
            this.label2.TabIndex = 3;
            this.label2.Text = "Failed:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(1251, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 50);
            this.label3.TabIndex = 4;
            this.label3.Text = "Total:";
            // 
            // ImportedCountLabel
            // 
            this.ImportedCountLabel.AutoSize = true;
            this.ImportedCountLabel.Font = new System.Drawing.Font("Segoe UI", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ImportedCountLabel.Location = new System.Drawing.Point(1365, 48);
            this.ImportedCountLabel.Name = "ImportedCountLabel";
            this.ImportedCountLabel.Size = new System.Drawing.Size(182, 50);
            this.ImportedCountLabel.TabIndex = 5;
            this.ImportedCountLabel.Text = "12345678";
            // 
            // FailedCountLabel
            // 
            this.FailedCountLabel.AutoSize = true;
            this.FailedCountLabel.Font = new System.Drawing.Font("Segoe UI", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FailedCountLabel.Location = new System.Drawing.Point(1365, 98);
            this.FailedCountLabel.Name = "FailedCountLabel";
            this.FailedCountLabel.Size = new System.Drawing.Size(182, 50);
            this.FailedCountLabel.TabIndex = 6;
            this.FailedCountLabel.Text = "12345678";
            // 
            // TotalCountLabel
            // 
            this.TotalCountLabel.AutoSize = true;
            this.TotalCountLabel.Font = new System.Drawing.Font("Segoe UI", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TotalCountLabel.Location = new System.Drawing.Point(1365, 148);
            this.TotalCountLabel.Name = "TotalCountLabel";
            this.TotalCountLabel.Size = new System.Drawing.Size(182, 50);
            this.TotalCountLabel.TabIndex = 7;
            this.TotalCountLabel.Text = "12345678";
            // 
            // GetFailedRecordsButton
            // 
            this.GetFailedRecordsButton.Enabled = false;
            this.GetFailedRecordsButton.Font = new System.Drawing.Font("Segoe UI", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GetFailedRecordsButton.Location = new System.Drawing.Point(33, 148);
            this.GetFailedRecordsButton.Name = "GetFailedRecordsButton";
            this.GetFailedRecordsButton.Size = new System.Drawing.Size(463, 72);
            this.GetFailedRecordsButton.TabIndex = 8;
            this.GetFailedRecordsButton.Text = "Get Failed Records";
            this.GetFailedRecordsButton.UseVisualStyleBackColor = true;
            this.GetFailedRecordsButton.Click += new System.EventHandler(this.GetFailedRecordsButton_Click);
            // 
            // FormDataImportReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1612, 829);
            this.Controls.Add(this.GetFailedRecordsButton);
            this.Controls.Add(this.TotalCountLabel);
            this.Controls.Add(this.FailedCountLabel);
            this.Controls.Add(this.ImportedCountLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ErrorListView);
            this.Controls.Add(this.ImportStatusLabel);
            this.Name = "FormDataImportReport";
            this.Text = "FormDataImportReport";
            this.Load += new System.EventHandler(this.FormDataImportReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView ErrorListView;
        private System.Windows.Forms.Label ImportStatusLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label ImportedCountLabel;
        private System.Windows.Forms.Label FailedCountLabel;
        private System.Windows.Forms.Label TotalCountLabel;
        private System.Windows.Forms.Button GetFailedRecordsButton;
        private System.Windows.Forms.ColumnHeader rowNumber;
        private System.Windows.Forms.ColumnHeader Error;
    }
}