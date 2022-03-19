namespace TNBase.Forms.Scanning
{
    partial class MagazinesScanInForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MagazinesScanInForm));
            this.lstScanned = new System.Windows.Forms.ListView();
            this.Wallet = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnFinish = new System.Windows.Forms.Button();
            this.txtScannerInput = new System.Windows.Forms.TextBox();
            this.ScanInputLabel = new System.Windows.Forms.Label();
            this.ListLabel = new System.Windows.Forms.Label();
            this.btnScanOut = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstScanned
            // 
            this.lstScanned.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Wallet,
            this.Quantity});
            this.lstScanned.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstScanned.FullRowSelect = true;
            this.lstScanned.GridLines = true;
            this.lstScanned.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstScanned.HideSelection = false;
            this.lstScanned.Location = new System.Drawing.Point(12, 55);
            this.lstScanned.MultiSelect = false;
            this.lstScanned.Name = "lstScanned";
            this.lstScanned.Size = new System.Drawing.Size(369, 383);
            this.lstScanned.TabIndex = 5;
            this.lstScanned.UseCompatibleStateImageBehavior = false;
            this.lstScanned.View = System.Windows.Forms.View.Details;
            this.lstScanned.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lstScanned_KeyPress);
            // 
            // Wallet
            // 
            this.Wallet.Text = "Wallet";
            this.Wallet.Width = 209;
            // 
            // Quantity
            // 
            this.Quantity.Text = "Quantity";
            this.Quantity.Width = 140;
            // 
            // btnFinish
            // 
            this.btnFinish.BackColor = System.Drawing.Color.LimeGreen;
            this.btnFinish.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinish.Location = new System.Drawing.Point(634, 314);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(154, 55);
            this.btnFinish.TabIndex = 3;
            this.btnFinish.Text = "Finish";
            this.btnFinish.UseVisualStyleBackColor = false;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // txtScannerInput
            // 
            this.txtScannerInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScannerInput.Location = new System.Drawing.Point(430, 146);
            this.txtScannerInput.Name = "txtScannerInput";
            this.txtScannerInput.Size = new System.Drawing.Size(314, 40);
            this.txtScannerInput.TabIndex = 1;
            this.txtScannerInput.TextChanged += new System.EventHandler(this.txtScannerInput_TextChanged);
            this.txtScannerInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtScannerInput_KeyDown);
            // 
            // ScanInputLabel
            // 
            this.ScanInputLabel.AutoSize = true;
            this.ScanInputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScanInputLabel.Location = new System.Drawing.Point(424, 110);
            this.ScanInputLabel.Name = "ScanInputLabel";
            this.ScanInputLabel.Size = new System.Drawing.Size(289, 33);
            this.ScanInputLabel.TabIndex = 103;
            this.ScanInputLabel.Text = "Please scan a wallet!";
            this.ScanInputLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ListLabel
            // 
            this.ListLabel.AutoSize = true;
            this.ListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListLabel.Location = new System.Drawing.Point(6, 11);
            this.ListLabel.Name = "ListLabel";
            this.ListLabel.Size = new System.Drawing.Size(241, 33);
            this.ListLabel.TabIndex = 102;
            this.ListLabel.Text = "Scanned Wallets:";
            // 
            // btnScanOut
            // 
            this.btnScanOut.BackColor = System.Drawing.Color.LimeGreen;
            this.btnScanOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScanOut.Location = new System.Drawing.Point(472, 375);
            this.btnScanOut.Name = "btnScanOut";
            this.btnScanOut.Size = new System.Drawing.Size(315, 55);
            this.btnScanOut.TabIndex = 2;
            this.btnScanOut.Text = "Finish and Scan Out";
            this.btnScanOut.UseVisualStyleBackColor = false;
            this.btnScanOut.Click += new System.EventHandler(this.btnScanOut_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(589, 12);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(199, 42);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.Text = "Remove Scanned";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblStatus.Location = new System.Drawing.Point(426, 189);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(318, 56);
            this.lblStatus.TabIndex = 107;
            this.lblStatus.Text = "Status";
            // 
            // MagazinesScanInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnScanOut);
            this.Controls.Add(this.lstScanned);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.txtScannerInput);
            this.Controls.Add(this.ScanInputLabel);
            this.Controls.Add(this.ListLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MagazinesScanInForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scan";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMagazineScanIn_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ListView lstScanned;
        internal System.Windows.Forms.ColumnHeader Wallet;
        internal System.Windows.Forms.ColumnHeader Quantity;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.TextBox txtScannerInput;
        internal System.Windows.Forms.Label ScanInputLabel;
        internal System.Windows.Forms.Label ListLabel;
        private System.Windows.Forms.Button btnScanOut;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label lblStatus;
    }
}