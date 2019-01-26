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
	partial class FormHistory : System.Windows.Forms.Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHistory));
            this.Label2 = new System.Windows.Forms.Label();
            this.lstWeekStats = new System.Windows.Forms.ListView();
            this.WeekNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ScannedIn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ScannedOut = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Stopped = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fieldDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Total = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Label1 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.lstYearStats = new System.Windows.Forms.ListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnDone = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.lblYear = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(352, 9);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(214, 33);
            this.Label2.TabIndex = 51;
            this.Label2.Text = "Past Statistics";
            // 
            // lstWeekStats
            // 
            this.lstWeekStats.AllowColumnReorder = true;
            this.lstWeekStats.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.WeekNumber,
            this.ScannedIn,
            this.ScannedOut,
            this.Stopped,
            this.fieldDate,
            this.Total});
            this.lstWeekStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstWeekStats.FullRowSelect = true;
            this.lstWeekStats.GridLines = true;
            this.lstWeekStats.HideSelection = false;
            this.lstWeekStats.Location = new System.Drawing.Point(12, 73);
            this.lstWeekStats.MultiSelect = false;
            this.lstWeekStats.Name = "lstWeekStats";
            this.lstWeekStats.Size = new System.Drawing.Size(880, 235);
            this.lstWeekStats.TabIndex = 52;
            this.lstWeekStats.UseCompatibleStateImageBehavior = false;
            this.lstWeekStats.View = System.Windows.Forms.View.Details;
            // 
            // WeekNumber
            // 
            this.WeekNumber.Text = "Week Number";
            this.WeekNumber.Width = 130;
            // 
            // ScannedIn
            // 
            this.ScannedIn.Text = "Scanned In";
            this.ScannedIn.Width = 120;
            // 
            // ScannedOut
            // 
            this.ScannedOut.Text = "Scanned Out";
            this.ScannedOut.Width = 120;
            // 
            // Stopped
            // 
            this.Stopped.Text = "Stopped";
            this.Stopped.Width = 120;
            // 
            // fieldDate
            // 
            this.fieldDate.Text = "Date";
            this.fieldDate.Width = 150;
            // 
            // Total
            // 
            this.Total.Text = "Total";
            this.Total.Width = 120;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(12, 45);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(193, 25);
            this.Label1.TabIndex = 53;
            this.Label1.Text = "Weekly Statistics";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(12, 325);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(166, 25);
            this.Label3.TabIndex = 54;
            this.Label3.Text = "Year Statistics";
            // 
            // lstYearStats
            // 
            this.lstYearStats.AllowColumnReorder = true;
            this.lstYearStats.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2,
            this.ColumnHeader3,
            this.ColumnHeader4,
            this.ColumnHeader5,
            this.ColumnHeader6});
            this.lstYearStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstYearStats.FullRowSelect = true;
            this.lstYearStats.GridLines = true;
            this.lstYearStats.HideSelection = false;
            this.lstYearStats.Location = new System.Drawing.Point(12, 353);
            this.lstYearStats.MultiSelect = false;
            this.lstYearStats.Name = "lstYearStats";
            this.lstYearStats.Size = new System.Drawing.Size(880, 71);
            this.lstYearStats.TabIndex = 55;
            this.lstYearStats.UseCompatibleStateImageBehavior = false;
            this.lstYearStats.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Start Listeners";
            this.ColumnHeader1.Width = 130;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "End Listeners";
            this.ColumnHeader2.Width = 120;
            // 
            // ColumnHeader3
            // 
            this.ColumnHeader3.Text = "Total Sent";
            this.ColumnHeader3.Width = 110;
            // 
            // ColumnHeader4
            // 
            this.ColumnHeader4.Text = "Magazines Sent";
            this.ColumnHeader4.Width = 150;
            // 
            // ColumnHeader5
            // 
            this.ColumnHeader5.Text = "USB Player Total";
            this.ColumnHeader5.Width = 150;
            // 
            // ColumnHeader6
            // 
            this.ColumnHeader6.Text = "New Listeners";
            this.ColumnHeader6.Width = 150;
            // 
            // btnDone
            // 
            this.btnDone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDone.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDone.Location = new System.Drawing.Point(704, 456);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(188, 58);
            this.btnDone.TabIndex = 58;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = false;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.BackColor = System.Drawing.Color.White;
            this.btnPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.Location = new System.Drawing.Point(100, 456);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(78, 58);
            this.btnPrevious.TabIndex = 63;
            this.btnPrevious.Text = "<";
            this.btnPrevious.UseVisualStyleBackColor = false;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnLast
            // 
            this.btnLast.BackColor = System.Drawing.Color.White;
            this.btnLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLast.Location = new System.Drawing.Point(408, 456);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(78, 58);
            this.btnLast.TabIndex = 65;
            this.btnLast.Text = ">>";
            this.btnLast.UseVisualStyleBackColor = false;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.White;
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(324, 456);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(78, 58);
            this.btnNext.TabIndex = 64;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.BackColor = System.Drawing.Color.White;
            this.btnFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFirst.Location = new System.Drawing.Point(16, 456);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(78, 58);
            this.btnFirst.TabIndex = 62;
            this.btnFirst.Text = "<<";
            this.btnFirst.UseVisualStyleBackColor = false;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYear.Location = new System.Drawing.Point(207, 467);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(89, 37);
            this.lblYear.TabIndex = 66;
            this.lblYear.Text = "????";
            // 
            // formHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 523);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.lstYearStats);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.lstWeekStats);
            this.Controls.Add(this.Label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formHistory";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.ListView lstWeekStats;
		internal System.Windows.Forms.ColumnHeader WeekNumber;
		internal System.Windows.Forms.ColumnHeader ScannedIn;
		internal System.Windows.Forms.ColumnHeader ScannedOut;
		internal System.Windows.Forms.ColumnHeader Stopped;
		internal System.Windows.Forms.ColumnHeader fieldDate;
		internal System.Windows.Forms.ColumnHeader Total;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.ListView lstYearStats;
		internal System.Windows.Forms.ColumnHeader ColumnHeader1;
		internal System.Windows.Forms.ColumnHeader ColumnHeader2;
		internal System.Windows.Forms.ColumnHeader ColumnHeader3;
		internal System.Windows.Forms.ColumnHeader ColumnHeader4;
		internal System.Windows.Forms.ColumnHeader ColumnHeader5;
		internal System.Windows.Forms.ColumnHeader ColumnHeader6;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnFirst;
		internal System.Windows.Forms.Label lblYear;
	}
}
