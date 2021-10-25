using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;
namespace TNBase
{
	partial class FormScanIn : System.Windows.Forms.Form
	{

		//Form overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]
		protected override void Dispose(bool disposing)
		{
			try {
				if (disposing && components != null) {
					components.Dispose();
				}
			} finally {
				base.Dispose(disposing);
			}
		}

		//Required by the Windows Form Designer

		private System.ComponentModel.IContainer components;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.  
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormScanIn));
            this.lstScanned = new System.Windows.Forms.ListView();
            this.Wallet = new System.Windows.Forms.ColumnHeader();
            this.Quantity = new System.Windows.Forms.ColumnHeader();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtScannerInput = new System.Windows.Forms.TextBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnFinished = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstScanned
            // 
            this.lstScanned.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Wallet,
            this.Quantity});
            this.lstScanned.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstScanned.FullRowSelect = true;
            this.lstScanned.GridLines = true;
            this.lstScanned.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstScanned.HideSelection = false;
            this.lstScanned.Location = new System.Drawing.Point(21, 61);
            this.lstScanned.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lstScanned.MultiSelect = false;
            this.lstScanned.Name = "lstScanned";
            this.lstScanned.Size = new System.Drawing.Size(362, 422);
            this.lstScanned.TabIndex = 100;
            this.lstScanned.TabStop = false;
            this.lstScanned.UseCompatibleStateImageBehavior = false;
            this.lstScanned.View = System.Windows.Forms.View.Details;
            // 
            // Wallet
            // 
            this.Wallet.Text = "Wallet";
            this.Wallet.Width = 140;
            // 
            // Quantity
            // 
            this.Quantity.Text = "Quantity";
            this.Quantity.Width = 140;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Label1.Location = new System.Drawing.Point(14, 10);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(241, 33);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Scanned Wallets:";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Label2.Location = new System.Drawing.Point(463, 51);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(320, 33);
            this.Label2.TabIndex = 2;
            this.Label2.Text = "Please scan in a wallet!";
            // 
            // txtScannerInput
            // 
            this.txtScannerInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtScannerInput.Location = new System.Drawing.Point(470, 97);
            this.txtScannerInput.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtScannerInput.Name = "txtScannerInput";
            this.txtScannerInput.Size = new System.Drawing.Size(366, 40);
            this.txtScannerInput.TabIndex = 1;
            this.txtScannerInput.TextChanged += new System.EventHandler(this.TxtScannerInput_TextChanged);
            this.txtScannerInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtScannerInput_KeyDown);
            // 
            // lblInfo
            // 
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblInfo.ForeColor = System.Drawing.Color.Red;
            this.lblInfo.Location = new System.Drawing.Point(470, 151);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(477, 249);
            this.lblInfo.TabIndex = 4;
            this.lblInfo.Text = "Info";
            // 
            // btnFinished
            // 
            this.btnFinished.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnFinished.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFinished.Location = new System.Drawing.Point(690, 403);
            this.btnFinished.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnFinished.Name = "btnFinished";
            this.btnFinished.Size = new System.Drawing.Size(257, 80);
            this.btnFinished.TabIndex = 6;
            this.btnFinished.TabStop = false;
            this.btnFinished.Text = "Finished";
            this.btnFinished.UseVisualStyleBackColor = false;
            this.btnFinished.Click += new System.EventHandler(this.BtnFinished_Click);
            // 
            // FormScanIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 495);
            this.Controls.Add(this.lstScanned);
            this.Controls.Add(this.btnFinished);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.txtScannerInput);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormScanIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormScanIn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		internal System.Windows.Forms.ListView lstScanned;
		internal System.Windows.Forms.ColumnHeader Wallet;
		internal System.Windows.Forms.ColumnHeader Quantity;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Label Label2;
        private System.Windows.Forms.TextBox txtScannerInput;
		internal System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnFinished;

		public FormScanIn()
		{
			FormClosing += FormScanIn_FormClosing;
			InitializeComponent();
		}
	}
}
