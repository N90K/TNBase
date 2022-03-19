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
	partial class FormResumeSending : System.Windows.Forms.Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormResumeSending));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCancelStop = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.lstData = new System.Windows.Forms.ListView();
            this.Wallet = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Forename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Surname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StopSending = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ResumeSending = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(23, 253);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(242, 52);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCancelStop
            // 
            this.btnCancelStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCancelStop.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCancelStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelStop.Location = new System.Drawing.Point(553, 253);
            this.btnCancelStop.Name = "btnCancelStop";
            this.btnCancelStop.Size = new System.Drawing.Size(242, 52);
            this.btnCancelStop.TabIndex = 9;
            this.btnCancelStop.Text = "Cancel a Stop";
            this.btnCancelStop.UseVisualStyleBackColor = false;
            this.btnCancelStop.Click += new System.EventHandler(this.btnCancelStop_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(288, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(232, 33);
            this.Label1.TabIndex = 7;
            this.Label1.Text = "Select a Listener";
            // 
            // lstData
            // 
            this.lstData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Wallet,
            this.Title,
            this.Forename,
            this.Surname,
            this.StopSending,
            this.ResumeSending});
            this.lstData.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstData.FullRowSelect = true;
            this.lstData.GridLines = true;
            this.lstData.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstData.HideSelection = false;
            this.lstData.Location = new System.Drawing.Point(12, 54);
            this.lstData.MultiSelect = false;
            this.lstData.Name = "lstData";
            this.lstData.Size = new System.Drawing.Size(802, 180);
            this.lstData.TabIndex = 6;
            this.lstData.UseCompatibleStateImageBehavior = false;
            this.lstData.View = System.Windows.Forms.View.Details;
            // 
            // Wallet
            // 
            this.Wallet.Text = "Wallet";
            this.Wallet.Width = 70;
            // 
            // Title
            // 
            this.Title.Text = "Title";
            this.Title.Width = 55;
            // 
            // Forename
            // 
            this.Forename.Text = "Forename";
            this.Forename.Width = 100;
            // 
            // Surname
            // 
            this.Surname.Text = "Surname";
            this.Surname.Width = 95;
            // 
            // StopSending
            // 
            this.StopSending.Text = "Stop Sending On...";
            this.StopSending.Width = 230;
            // 
            // ResumeSending
            // 
            this.ResumeSending.Text = "Resume Sending On...";
            this.ResumeSending.Width = 230;
            // 
            // FormResumeSending
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 324);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCancelStop);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.lstData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormResumeSending";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

		}
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCancelStop;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.ListView lstData;
		internal System.Windows.Forms.ColumnHeader Wallet;
		internal System.Windows.Forms.ColumnHeader Title;
		internal System.Windows.Forms.ColumnHeader Forename;
		internal System.Windows.Forms.ColumnHeader Surname;
		internal System.Windows.Forms.ColumnHeader StopSending;
		internal System.Windows.Forms.ColumnHeader ResumeSending;
	}
}
