namespace TNBase.Forms.Scanning
{
    partial class MagazinesScanOutForm
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("1111");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "2222"}, -1, System.Drawing.Color.Empty, System.Drawing.Color.LightBlue, null);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("3333");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new string[] {
            "4444"}, -1, System.Drawing.Color.Empty, System.Drawing.Color.LightBlue, null);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MagazinesScanOutForm));
            this.lstScanned = new System.Windows.Forms.ListView();
            this.ScannedWallets = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnFinish = new System.Windows.Forms.Button();
            this.txtScannerInput = new System.Windows.Forms.TextBox();
            this.ScanInputLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lstToScan = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstScanned
            // 
            this.lstScanned.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ScannedWallets});
            this.lstScanned.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstScanned.FullRowSelect = true;
            this.lstScanned.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstScanned.HideSelection = false;
            this.lstScanned.Location = new System.Drawing.Point(272, 155);
            this.lstScanned.MultiSelect = false;
            this.lstScanned.Name = "lstScanned";
            this.lstScanned.Size = new System.Drawing.Size(215, 354);
            this.lstScanned.TabIndex = 3;
            this.lstScanned.UseCompatibleStateImageBehavior = false;
            this.lstScanned.View = System.Windows.Forms.View.Details;
            this.lstScanned.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lstScanned_KeyPress);
            // 
            // ScannedWallets
            // 
            this.ScannedWallets.Text = "Scanned Out Wallets";
            this.ScannedWallets.Width = 180;
            // 
            // btnFinish
            // 
            this.btnFinish.BackColor = System.Drawing.Color.LimeGreen;
            this.btnFinish.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinish.Location = new System.Drawing.Point(321, 524);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(154, 55);
            this.btnFinish.TabIndex = 4;
            this.btnFinish.Text = "Finish";
            this.btnFinish.UseVisualStyleBackColor = false;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // txtScannerInput
            // 
            this.txtScannerInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScannerInput.Location = new System.Drawing.Point(12, 41);
            this.txtScannerInput.Name = "txtScannerInput";
            this.txtScannerInput.Size = new System.Drawing.Size(310, 40);
            this.txtScannerInput.TabIndex = 1;
            this.txtScannerInput.TextChanged += new System.EventHandler(this.txtScannerInput_TextChanged);
            this.txtScannerInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtScannerInput_KeyDown);
            // 
            // ScanInputLabel
            // 
            this.ScanInputLabel.AutoSize = true;
            this.ScanInputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScanInputLabel.Location = new System.Drawing.Point(7, 9);
            this.ScanInputLabel.Name = "ScanInputLabel";
            this.ScanInputLabel.Size = new System.Drawing.Size(238, 29);
            this.ScanInputLabel.TabIndex = 103;
            this.ScanInputLabel.Text = "Please scan a wallet!";
            this.ScanInputLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.label1.Location = new System.Drawing.Point(233, 299);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 40);
            this.label1.TabIndex = 105;
            this.label1.Text = ">";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblStatus.Location = new System.Drawing.Point(12, 84);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(60, 24);
            this.lblStatus.TabIndex = 106;
            this.lblStatus.Text = "Status";
            // 
            // lstToScan
            // 
            this.lstToScan.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lstToScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstToScan.FullRowSelect = true;
            this.lstToScan.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstToScan.HideSelection = false;
            listViewItem2.StateImageIndex = 0;
            listViewItem4.ToolTipText = "fghj";
            this.lstToScan.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4});
            this.lstToScan.LabelWrap = false;
            this.lstToScan.Location = new System.Drawing.Point(12, 155);
            this.lstToScan.MultiSelect = false;
            this.lstToScan.Name = "lstToScan";
            this.lstToScan.ShowGroups = false;
            this.lstToScan.Size = new System.Drawing.Size(215, 354);
            this.lstToScan.TabIndex = 2;
            this.lstToScan.UseCompatibleStateImageBehavior = false;
            this.lstToScan.View = System.Windows.Forms.View.Details;
            this.lstToScan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lstToScan_KeyPress);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Wallets To Scan";
            this.columnHeader1.Width = 180;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 25);
            this.label2.TabIndex = 108;
            this.label2.Text = "Wallets to scan:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(267, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 25);
            this.label3.TabIndex = 109;
            this.label3.Text = "Scanned wallets:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ScanOutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 591);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstToScan);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstScanned);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.txtScannerInput);
            this.Controls.Add(this.ScanInputLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ScanOutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scan";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMagazineScanIn_FormClosing);
            this.Load += new System.EventHandler(this.ScanOutForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ListView lstScanned;
        internal System.Windows.Forms.ColumnHeader ScannedWallets;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.TextBox txtScannerInput;
        internal System.Windows.Forms.Label ScanInputLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStatus;
        internal System.Windows.Forms.ListView lstToScan;
        internal System.Windows.Forms.ColumnHeader columnHeader1;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label3;
    }
}