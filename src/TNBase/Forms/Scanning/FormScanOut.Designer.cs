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
	[Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
	partial class FormScanOut : System.Windows.Forms.Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormScanOut));
            this.lstScanned = new System.Windows.Forms.ListView();
            this.Wallet = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnFinished = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtScannerInput = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
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
            this.lstScanned.Location = new System.Drawing.Point(18, 62);
            this.lstScanned.MultiSelect = false;
            this.lstScanned.Name = "lstScanned";
            this.lstScanned.Size = new System.Drawing.Size(311, 266);
            this.lstScanned.TabIndex = 106;
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
            // btnFinished
            // 
            this.btnFinished.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnFinished.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinished.Location = new System.Drawing.Point(451, 259);
            this.btnFinished.Name = "btnFinished";
            this.btnFinished.Size = new System.Drawing.Size(220, 69);
            this.btnFinished.TabIndex = 105;
            this.btnFinished.TabStop = false;
            this.btnFinished.Text = "Finished";
            this.btnFinished.UseVisualStyleBackColor = false;
            this.btnFinished.Click += new System.EventHandler(this.btnFinished_Click);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(403, 159);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(303, 66);
            this.Label3.TabIndex = 104;
            this.Label3.Text = "Click the Finish button\r\nwhen you are done.";
            // 
            // txtScannerInput
            // 
            this.txtScannerInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScannerInput.Location = new System.Drawing.Point(403, 93);
            this.txtScannerInput.Name = "txtScannerInput";
            this.txtScannerInput.Size = new System.Drawing.Size(314, 40);
            this.txtScannerInput.TabIndex = 101;
            this.txtScannerInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtScannerInput_KeyDown);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(390, 56);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(337, 33);
            this.Label2.TabIndex = 103;
            this.Label2.Text = "Please scan out a wallet!";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(12, 18);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(241, 33);
            this.Label1.TabIndex = 102;
            this.Label1.Text = "Scanned Wallets:";
            // 
            // formScanOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 354);
            this.Controls.Add(this.btnFinished);
            this.Controls.Add(this.lstScanned);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.txtScannerInput);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formScanOut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		internal System.Windows.Forms.ListView lstScanned;
		internal System.Windows.Forms.ColumnHeader Wallet;
		internal System.Windows.Forms.ColumnHeader Quantity;
        private System.Windows.Forms.Button btnFinished;
		internal System.Windows.Forms.Label Label3;
        private System.Windows.Forms.TextBox txtScannerInput;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Label Label1;
	}
}
