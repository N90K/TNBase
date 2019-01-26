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
	partial class FormTest : System.Windows.Forms.Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTest));
            this.btnAddListener = new System.Windows.Forms.Button();
            this.btnCleanDatabase = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabDefault = new System.Windows.Forms.TabPage();
            this.btnClose = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.tabListeners = new System.Windows.Forms.TabPage();
            this.DateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.Button4 = new System.Windows.Forms.Button();
            this.Button2 = new System.Windows.Forms.Button();
            this.btnGetFreeIndex = new System.Windows.Forms.Button();
            this.tabWeeklyStats = new System.Windows.Forms.TabPage();
            this.Button3 = new System.Windows.Forms.Button();
            this.btnClearWeekStats = new System.Windows.Forms.Button();
            this.tabYearlyStats = new System.Windows.Forms.TabPage();
            this.Button1 = new System.Windows.Forms.Button();
            this.btnClearYearlyStats = new System.Windows.Forms.Button();
            this.tabGeneric = new System.Windows.Forms.TabPage();
            this.btnDevTest = new System.Windows.Forms.Button();
            this.btnThrowException = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.txtConvertLog = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRunCommands = new System.Windows.Forms.Button();
            this.lblLinesRead = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabDefault.SuspendLayout();
            this.tabListeners.SuspendLayout();
            this.tabWeeklyStats.SuspendLayout();
            this.tabYearlyStats.SuspendLayout();
            this.tabGeneric.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddListener
            // 
            this.btnAddListener.Location = new System.Drawing.Point(6, 41);
            this.btnAddListener.Name = "btnAddListener";
            this.btnAddListener.Size = new System.Drawing.Size(155, 29);
            this.btnAddListener.TabIndex = 1;
            this.btnAddListener.Text = "Add New Listener";
            this.btnAddListener.UseVisualStyleBackColor = true;
            this.btnAddListener.Click += new System.EventHandler(this.btnAddListener_Click);
            // 
            // btnCleanDatabase
            // 
            this.btnCleanDatabase.Location = new System.Drawing.Point(6, 6);
            this.btnCleanDatabase.Name = "btnCleanDatabase";
            this.btnCleanDatabase.Size = new System.Drawing.Size(155, 29);
            this.btnCleanDatabase.TabIndex = 2;
            this.btnCleanDatabase.Text = "Clean Database";
            this.btnCleanDatabase.UseVisualStyleBackColor = true;
            this.btnCleanDatabase.Click += new System.EventHandler(this.btnCleanDatabase_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabDefault);
            this.tabControl.Controls.Add(this.tabListeners);
            this.tabControl.Controls.Add(this.tabWeeklyStats);
            this.tabControl.Controls.Add(this.tabYearlyStats);
            this.tabControl.Controls.Add(this.tabGeneric);
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(528, 370);
            this.tabControl.TabIndex = 0;
            // 
            // tabDefault
            // 
            this.tabDefault.Controls.Add(this.btnClose);
            this.tabDefault.Controls.Add(this.Label1);
            this.tabDefault.Location = new System.Drawing.Point(4, 22);
            this.tabDefault.Name = "tabDefault";
            this.tabDefault.Padding = new System.Windows.Forms.Padding(3);
            this.tabDefault.Size = new System.Drawing.Size(520, 218);
            this.tabDefault.TabIndex = 3;
            this.tabDefault.Text = "Test Controls";
            this.tabDefault.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnClose.Location = new System.Drawing.Point(199, 138);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(115, 50);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(36, 57);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(450, 25);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Welcome to the " + ModuleGeneric.getAppShortName() + " Application test page.";
            // 
            // tabListeners
            // 
            this.tabListeners.Controls.Add(this.DateTimePicker1);
            this.tabListeners.Controls.Add(this.Button4);
            this.tabListeners.Controls.Add(this.Button2);
            this.tabListeners.Controls.Add(this.btnGetFreeIndex);
            this.tabListeners.Controls.Add(this.btnAddListener);
            this.tabListeners.Controls.Add(this.btnCleanDatabase);
            this.tabListeners.Location = new System.Drawing.Point(4, 22);
            this.tabListeners.Name = "tabListeners";
            this.tabListeners.Padding = new System.Windows.Forms.Padding(3);
            this.tabListeners.Size = new System.Drawing.Size(520, 218);
            this.tabListeners.TabIndex = 0;
            this.tabListeners.Text = "Listener Database";
            this.tabListeners.UseVisualStyleBackColor = true;
            // 
            // DateTimePicker1
            // 
            this.DateTimePicker1.CustomFormat = "ddddMMMMyyyy";
            this.DateTimePicker1.Location = new System.Drawing.Point(344, 15);
            this.DateTimePicker1.Name = "DateTimePicker1";
            this.DateTimePicker1.Size = new System.Drawing.Size(152, 20);
            this.DateTimePicker1.TabIndex = 6;
            // 
            // Button4
            // 
            this.Button4.Location = new System.Drawing.Point(344, 44);
            this.Button4.Name = "Button4";
            this.Button4.Size = new System.Drawing.Size(152, 26);
            this.Button4.TabIndex = 5;
            this.Button4.Text = "Print Birthdays for Week";
            this.Button4.UseVisualStyleBackColor = true;
            this.Button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // Button2
            // 
            this.Button2.Location = new System.Drawing.Point(6, 110);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(155, 28);
            this.Button2.TabIndex = 4;
            this.Button2.Text = "Print deleted form for Listener";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // btnGetFreeIndex
            // 
            this.btnGetFreeIndex.Location = new System.Drawing.Point(6, 76);
            this.btnGetFreeIndex.Name = "btnGetFreeIndex";
            this.btnGetFreeIndex.Size = new System.Drawing.Size(155, 28);
            this.btnGetFreeIndex.TabIndex = 3;
            this.btnGetFreeIndex.Text = "Get Next Free Index";
            this.btnGetFreeIndex.UseVisualStyleBackColor = true;
            this.btnGetFreeIndex.Click += new System.EventHandler(this.btnGetFreeIndex_Click);
            // 
            // tabWeeklyStats
            // 
            this.tabWeeklyStats.Controls.Add(this.Button3);
            this.tabWeeklyStats.Controls.Add(this.btnClearWeekStats);
            this.tabWeeklyStats.Location = new System.Drawing.Point(4, 22);
            this.tabWeeklyStats.Name = "tabWeeklyStats";
            this.tabWeeklyStats.Padding = new System.Windows.Forms.Padding(3);
            this.tabWeeklyStats.Size = new System.Drawing.Size(520, 218);
            this.tabWeeklyStats.TabIndex = 1;
            this.tabWeeklyStats.Text = "Weekly Stats";
            this.tabWeeklyStats.UseVisualStyleBackColor = true;
            // 
            // Button3
            // 
            this.Button3.Location = new System.Drawing.Point(6, 41);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(155, 29);
            this.Button3.TabIndex = 5;
            this.Button3.Text = "Get Week Number";
            this.Button3.UseVisualStyleBackColor = true;
            this.Button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // btnClearWeekStats
            // 
            this.btnClearWeekStats.Location = new System.Drawing.Point(6, 6);
            this.btnClearWeekStats.Name = "btnClearWeekStats";
            this.btnClearWeekStats.Size = new System.Drawing.Size(155, 29);
            this.btnClearWeekStats.TabIndex = 4;
            this.btnClearWeekStats.Text = "Clean Database";
            this.btnClearWeekStats.UseVisualStyleBackColor = true;
            this.btnClearWeekStats.Click += new System.EventHandler(this.btnClearWeekStats_Click);
            // 
            // tabYearlyStats
            // 
            this.tabYearlyStats.Controls.Add(this.Button1);
            this.tabYearlyStats.Controls.Add(this.btnClearYearlyStats);
            this.tabYearlyStats.Location = new System.Drawing.Point(4, 22);
            this.tabYearlyStats.Name = "tabYearlyStats";
            this.tabYearlyStats.Size = new System.Drawing.Size(520, 218);
            this.tabYearlyStats.TabIndex = 2;
            this.tabYearlyStats.Text = "Yearly Stats";
            this.tabYearlyStats.UseVisualStyleBackColor = true;
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(3, 38);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(155, 29);
            this.Button1.TabIndex = 6;
            this.Button1.Text = "Check Last Years Listeners";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // btnClearYearlyStats
            // 
            this.btnClearYearlyStats.Location = new System.Drawing.Point(3, 3);
            this.btnClearYearlyStats.Name = "btnClearYearlyStats";
            this.btnClearYearlyStats.Size = new System.Drawing.Size(155, 29);
            this.btnClearYearlyStats.TabIndex = 5;
            this.btnClearYearlyStats.Text = "Clean Database";
            this.btnClearYearlyStats.UseVisualStyleBackColor = true;
            this.btnClearYearlyStats.Click += new System.EventHandler(this.btnClearYearlyStats_Click);
            // 
            // tabGeneric
            // 
            this.tabGeneric.Controls.Add(this.btnDevTest);
            this.tabGeneric.Controls.Add(this.btnThrowException);
            this.tabGeneric.Location = new System.Drawing.Point(4, 22);
            this.tabGeneric.Name = "tabGeneric";
            this.tabGeneric.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneric.Size = new System.Drawing.Size(520, 218);
            this.tabGeneric.TabIndex = 4;
            this.tabGeneric.Text = "Other";
            this.tabGeneric.UseVisualStyleBackColor = true;
            // 
            // btnDevTest
            // 
            this.btnDevTest.Location = new System.Drawing.Point(6, 41);
            this.btnDevTest.Name = "btnDevTest";
            this.btnDevTest.Size = new System.Drawing.Size(155, 29);
            this.btnDevTest.TabIndex = 4;
            this.btnDevTest.Text = "Latest Dev Test";
            this.btnDevTest.UseVisualStyleBackColor = true;
            this.btnDevTest.Click += new System.EventHandler(this.btnDevTest_Click);
            // 
            // btnThrowException
            // 
            this.btnThrowException.Location = new System.Drawing.Point(6, 6);
            this.btnThrowException.Name = "btnThrowException";
            this.btnThrowException.Size = new System.Drawing.Size(155, 29);
            this.btnThrowException.TabIndex = 3;
            this.btnThrowException.Text = "Throw Exception";
            this.btnThrowException.UseVisualStyleBackColor = true;
            this.btnThrowException.Click += new System.EventHandler(this.btnThrowException_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblLinesRead);
            this.tabPage1.Controls.Add(this.btnRunCommands);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtConvertLog);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(520, 344);
            this.tabPage1.TabIndex = 5;
            this.tabPage1.Text = "Log to SQL";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(493, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Attempts to convert a log file into SQL statements - use only as a last resort! D" +
    "rag the file on to convert..";
            // 
            // txtConvertLog
            // 
            this.txtConvertLog.AllowDrop = true;
            this.txtConvertLog.Location = new System.Drawing.Point(6, 42);
            this.txtConvertLog.Multiline = true;
            this.txtConvertLog.Name = "txtConvertLog";
            this.txtConvertLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConvertLog.Size = new System.Drawing.Size(505, 235);
            this.txtConvertLog.TabIndex = 1;
            this.txtConvertLog.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtConvertLog_DragDrop);
            this.txtConvertLog.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtConvertLog_DragEnter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(411, 280);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Warning: this is slow";
            // 
            // btnRunCommands
            // 
            this.btnRunCommands.BackColor = System.Drawing.Color.Maroon;
            this.btnRunCommands.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRunCommands.Location = new System.Drawing.Point(200, 283);
            this.btnRunCommands.Name = "btnRunCommands";
            this.btnRunCommands.Size = new System.Drawing.Size(124, 55);
            this.btnRunCommands.TabIndex = 3;
            this.btnRunCommands.Text = "Run on DB";
            this.btnRunCommands.UseVisualStyleBackColor = false;
            this.btnRunCommands.Click += new System.EventHandler(this.btnRunCommands_Click);
            // 
            // lblLinesRead
            // 
            this.lblLinesRead.AutoSize = true;
            this.lblLinesRead.Location = new System.Drawing.Point(6, 280);
            this.lblLinesRead.Name = "lblLinesRead";
            this.lblLinesRead.Size = new System.Drawing.Size(13, 13);
            this.lblLinesRead.TabIndex = 4;
            this.lblLinesRead.Text = "0";
            // 
            // formTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 394);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Testing Form";
            this.tabControl.ResumeLayout(false);
            this.tabDefault.ResumeLayout(false);
            this.tabDefault.PerformLayout();
            this.tabListeners.ResumeLayout(false);
            this.tabWeeklyStats.ResumeLayout(false);
            this.tabYearlyStats.ResumeLayout(false);
            this.tabGeneric.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

		}
        private System.Windows.Forms.Button btnAddListener;
        private System.Windows.Forms.Button btnCleanDatabase;
		internal System.Windows.Forms.TabControl tabControl;
		internal System.Windows.Forms.TabPage tabListeners;
		internal System.Windows.Forms.TabPage tabWeeklyStats;
		internal System.Windows.Forms.TabPage tabYearlyStats;
        private System.Windows.Forms.Button btnClearWeekStats;
        private System.Windows.Forms.Button btnClearYearlyStats;
		private System.Windows.Forms.Button btnGetFreeIndex;
        private System.Windows.Forms.Button Button1;
		internal System.Windows.Forms.TabPage tabDefault;
        private System.Windows.Forms.Button btnClose;
		internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Button Button2;
		internal System.Windows.Forms.TabPage tabGeneric;
        private System.Windows.Forms.Button btnThrowException;
        private System.Windows.Forms.Button Button3;
		internal System.Windows.Forms.DateTimePicker DateTimePicker1;
        private System.Windows.Forms.Button Button4;
        private System.Windows.Forms.Button btnDevTest;
        private TabPage tabPage1;
        private TextBox txtConvertLog;
        private Label label2;
        private Label label3;
        private Button btnRunCommands;
        private Label lblLinesRead;
	}
}
