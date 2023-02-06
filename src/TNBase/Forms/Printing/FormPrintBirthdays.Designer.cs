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
	partial class FormPrintBirthdays : System.Windows.Forms.Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrintBirthdays));
            this.printBirthdayDoc = new System.Drawing.Printing.PrintDocument();
            this.printPreview = new TNBase.PrintPreviewDialogSelectPrinter();
            this.pnlPrinting = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblPrinting = new System.Windows.Forms.Label();
            this.pnlParams = new System.Windows.Forms.Panel();
            this.btnCancel2 = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblFrom = new System.Windows.Forms.Label();
            this.pnlPrinting.SuspendLayout();
            this.pnlParams.SuspendLayout();
            this.SuspendLayout();
            // 
            // printBirthdayDoc
            // 
            this.printBirthdayDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printBirthdayDoc_PrintPage);
            // 
            // printPreview
            // 
            this.printPreview.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreview.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreview.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreview.Enabled = true;
            this.printPreview.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreview.Icon")));
            this.printPreview.Name = "PrintPreviewDialogSelectPrinter1";
            this.printPreview.Visible = false;
            // 
            // pnlPrinting
            // 
            this.pnlPrinting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPrinting.Controls.Add(this.btnCancel);
            this.pnlPrinting.Controls.Add(this.lblPrinting);
            this.pnlPrinting.Location = new System.Drawing.Point(0, 0);
            this.pnlPrinting.Name = "pnlPrinting";
            this.pnlPrinting.Size = new System.Drawing.Size(481, 126);
            this.pnlPrinting.TabIndex = 2;
            this.pnlPrinting.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.Location = new System.Drawing.Point(242, 74);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(127, 46);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // lblPrinting
            // 
            this.lblPrinting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrinting.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPrinting.Location = new System.Drawing.Point(12, 15);
            this.lblPrinting.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrinting.Name = "lblPrinting";
            this.lblPrinting.Size = new System.Drawing.Size(456, 59);
            this.lblPrinting.TabIndex = 2;
            this.lblPrinting.Text = "Printing Listener birthdays for {0} to {1}...";
            // 
            // pnlParams
            // 
            this.pnlParams.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlParams.Controls.Add(this.btnCancel2);
            this.pnlParams.Controls.Add(this.btnPrint);
            this.pnlParams.Controls.Add(this.dtpTo);
            this.pnlParams.Controls.Add(this.lblTo);
            this.pnlParams.Controls.Add(this.dtpFrom);
            this.pnlParams.Controls.Add(this.lblFrom);
            this.pnlParams.Location = new System.Drawing.Point(3, 7);
            this.pnlParams.Name = "pnlParams";
            this.pnlParams.Size = new System.Drawing.Size(475, 122);
            this.pnlParams.TabIndex = 4;
            // 
            // btnCancel2
            // 
            this.btnCancel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCancel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancel2.Location = new System.Drawing.Point(242, 74);
            this.btnCancel2.Name = "btnCancel2";
            this.btnCancel2.Size = new System.Drawing.Size(131, 37);
            this.btnCancel2.TabIndex = 5;
            this.btnCancel2.Text = "Cancel";
            this.btnCancel2.UseVisualStyleBackColor = false;
            this.btnCancel2.Click += new System.EventHandler(this.btnCancel2_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnPrint.Location = new System.Drawing.Point(76, 74);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(131, 37);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "ddd dd MMMM yyyy";
            this.dtpTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(157, 39);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(274, 29);
            this.dtpTo.TabIndex = 3;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTo.Location = new System.Drawing.Point(9, 43);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(74, 24);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "To date";
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "ddd dd MMMM yyyy";
            this.dtpFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(157, 4);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(274, 29);
            this.dtpFrom.TabIndex = 1;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFrom.Location = new System.Drawing.Point(9, 8);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(96, 24);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "From date";
            // 
            // FormPrintBirthdays
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 130);
            this.Controls.Add(this.pnlParams);
            this.Controls.Add(this.pnlPrinting);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPrintBirthdays";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Upcoming birthdays";
            this.Load += new System.EventHandler(this.formPrintBirthdays_Load);
            this.pnlPrinting.ResumeLayout(false);
            this.pnlParams.ResumeLayout(false);
            this.pnlParams.PerformLayout();
            this.ResumeLayout(false);

		}
        private System.Drawing.Printing.PrintDocument printBirthdayDoc;
        internal TNBase.PrintPreviewDialogSelectPrinter printPreview;
        private Panel pnlPrinting;
        private Button btnCancel;
        internal Label lblPrinting;
        private Panel pnlParams;
        private DateTimePicker dtpTo;
        private Label lblTo;
        private DateTimePicker dtpFrom;
        private Label lblFrom;
        private Button btnPrint;
        private Button btnCancel2;
    }
}
