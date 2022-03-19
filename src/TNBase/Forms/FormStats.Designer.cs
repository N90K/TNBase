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
	partial class FormStats : System.Windows.Forms.Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStats));
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.Label11 = new System.Windows.Forms.Label();
            this.Label13 = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.Label15 = new System.Windows.Forms.Label();
            this.Label16 = new System.Windows.Forms.Label();
            this.btnFinished = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lblWeeklyYearListeners = new System.Windows.Forms.Label();
            this.lblListenersToday = new System.Windows.Forms.Label();
            this.lblNewListeners = new System.Windows.Forms.Label();
            this.lblLostListeners = new System.Windows.Forms.Label();
            this.lblNetListeners = new System.Windows.Forms.Label();
            this.lblAverageListeners = new System.Windows.Forms.Label();
            this.lblInactiveWallets = new System.Windows.Forms.Label();
            this.lblAverageDispatched = new System.Windows.Forms.Label();
            this.lblWalletsDispatched = new System.Windows.Forms.Label();
            this.lblMemorySticksOnLoad = new System.Windows.Forms.Label();
            this.lblStoppedWallets = new System.Windows.Forms.Label();
            this.lblAverageStopped = new System.Windows.Forms.Label();
            this.lblDormant = new System.Windows.Forms.Label();
            this.printStatsDoc = new System.Drawing.Printing.PrintDocument();
            this.printPreview = new TNBase.PrintPreviewDialogSelectPrinter();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(254, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(291, 37);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Database Statistics";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.Label2.Location = new System.Drawing.Point(177, 40);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(381, 25);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "This Year\'s Database Statistics Up To ";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblDate.Location = new System.Drawing.Point(551, 40);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(120, 25);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "??/??/????";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(47, 114);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(387, 33);
            this.Label3.TabIndex = 3;
            this.Label3.Text = "Weekly listeners as of today:";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(47, 81);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(527, 33);
            this.Label4.TabIndex = 4;
            this.Label4.Text = "Weekly listeners at the start of the year:";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(47, 147);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(457, 33);
            this.Label5.TabIndex = 5;
            this.Label5.Text = "Number of new listeners this year:";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(47, 180);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(450, 33);
            this.Label6.TabIndex = 6;
            this.Label6.Text = "Number of lost listeners this year:";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.Location = new System.Drawing.Point(47, 213);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(476, 33);
            this.Label7.TabIndex = 7;
            this.Label7.Text = "Net change of listeners for the year:";
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.Location = new System.Drawing.Point(47, 246);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(543, 33);
            this.Label8.TabIndex = 8;
            this.Label8.Text = "Average number of listeners for the year:";
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.Location = new System.Drawing.Point(47, 279);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(511, 33);
            this.Label9.TabIndex = 9;
            this.Label9.Text = "Inactive wallets (not available for use):";
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label10.Location = new System.Drawing.Point(47, 312);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(664, 33);
            this.Label10.TabIndex = 10;
            this.Label10.Text = "Average number of wallets dispatched each week:";
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label11.Location = new System.Drawing.Point(47, 345);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(387, 33);
            this.Label11.TabIndex = 11;
            this.Label11.Text = "News Wallets dispatched this year:";
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label13.Location = new System.Drawing.Point(47, 378);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(411, 33);
            this.Label13.TabIndex = 13;
            this.Label13.Text = "Memory stick players on loan: ";
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label14.Location = new System.Drawing.Point(47, 411);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(228, 33);
            this.Label14.TabIndex = 14;
            this.Label14.Text = "Stopped wallets:";
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label15.Location = new System.Drawing.Point(47, 444);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(681, 33);
            this.Label15.TabIndex = 15;
            this.Label15.Text = "Average number of stopped wallets during the year:";
            // 
            // Label16
            // 
            this.Label16.AutoSize = true;
            this.Label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label16.Location = new System.Drawing.Point(48, 479);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(492, 33);
            this.Label16.TabIndex = 16;
            this.Label16.Text = "Listeners dormant for over 3 months:";
            // 
            // btnFinished
            // 
            this.btnFinished.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnFinished.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinished.ForeColor = System.Drawing.Color.Black;
            this.btnFinished.Location = new System.Drawing.Point(146, 539);
            this.btnFinished.Name = "btnFinished";
            this.btnFinished.Size = new System.Drawing.Size(192, 64);
            this.btnFinished.TabIndex = 19;
            this.btnFinished.Text = "Finished";
            this.btnFinished.UseVisualStyleBackColor = false;
            this.btnFinished.Click += new System.EventHandler(this.btnFinished_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(536, 539);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(192, 64);
            this.btnPrint.TabIndex = 20;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lblWeeklyYearListeners
            // 
            this.lblWeeklyYearListeners.AutoSize = true;
            this.lblWeeklyYearListeners.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeeklyYearListeners.Location = new System.Drawing.Point(746, 81);
            this.lblWeeklyYearListeners.Name = "lblWeeklyYearListeners";
            this.lblWeeklyYearListeners.Size = new System.Drawing.Size(31, 33);
            this.lblWeeklyYearListeners.TabIndex = 21;
            this.lblWeeklyYearListeners.Text = "?";
            // 
            // lblListenersToday
            // 
            this.lblListenersToday.AutoSize = true;
            this.lblListenersToday.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListenersToday.Location = new System.Drawing.Point(746, 114);
            this.lblListenersToday.Name = "lblListenersToday";
            this.lblListenersToday.Size = new System.Drawing.Size(31, 33);
            this.lblListenersToday.TabIndex = 22;
            this.lblListenersToday.Text = "?";
            // 
            // lblNewListeners
            // 
            this.lblNewListeners.AutoSize = true;
            this.lblNewListeners.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewListeners.Location = new System.Drawing.Point(746, 147);
            this.lblNewListeners.Name = "lblNewListeners";
            this.lblNewListeners.Size = new System.Drawing.Size(31, 33);
            this.lblNewListeners.TabIndex = 23;
            this.lblNewListeners.Text = "?";
            // 
            // lblLostListeners
            // 
            this.lblLostListeners.AutoSize = true;
            this.lblLostListeners.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLostListeners.Location = new System.Drawing.Point(746, 180);
            this.lblLostListeners.Name = "lblLostListeners";
            this.lblLostListeners.Size = new System.Drawing.Size(31, 33);
            this.lblLostListeners.TabIndex = 24;
            this.lblLostListeners.Text = "?";
            // 
            // lblNetListeners
            // 
            this.lblNetListeners.AutoSize = true;
            this.lblNetListeners.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetListeners.Location = new System.Drawing.Point(746, 213);
            this.lblNetListeners.Name = "lblNetListeners";
            this.lblNetListeners.Size = new System.Drawing.Size(31, 33);
            this.lblNetListeners.TabIndex = 25;
            this.lblNetListeners.Text = "?";
            // 
            // lblAverageListeners
            // 
            this.lblAverageListeners.AutoSize = true;
            this.lblAverageListeners.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAverageListeners.Location = new System.Drawing.Point(746, 246);
            this.lblAverageListeners.Name = "lblAverageListeners";
            this.lblAverageListeners.Size = new System.Drawing.Size(31, 33);
            this.lblAverageListeners.TabIndex = 26;
            this.lblAverageListeners.Text = "?";
            // 
            // lblInactiveWallets
            // 
            this.lblInactiveWallets.AutoSize = true;
            this.lblInactiveWallets.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInactiveWallets.Location = new System.Drawing.Point(746, 279);
            this.lblInactiveWallets.Name = "lblInactiveWallets";
            this.lblInactiveWallets.Size = new System.Drawing.Size(31, 33);
            this.lblInactiveWallets.TabIndex = 27;
            this.lblInactiveWallets.Text = "?";
            // 
            // lblAverageDispatched
            // 
            this.lblAverageDispatched.AutoSize = true;
            this.lblAverageDispatched.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAverageDispatched.Location = new System.Drawing.Point(746, 312);
            this.lblAverageDispatched.Name = "lblAverageDispatched";
            this.lblAverageDispatched.Size = new System.Drawing.Size(31, 33);
            this.lblAverageDispatched.TabIndex = 28;
            this.lblAverageDispatched.Text = "?";
            // 
            // lblWalletsDispatched
            // 
            this.lblWalletsDispatched.AutoSize = true;
            this.lblWalletsDispatched.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWalletsDispatched.Location = new System.Drawing.Point(746, 345);
            this.lblWalletsDispatched.Name = "lblWalletsDispatched";
            this.lblWalletsDispatched.Size = new System.Drawing.Size(31, 33);
            this.lblWalletsDispatched.TabIndex = 29;
            this.lblWalletsDispatched.Text = "?";
            // 
            // lblMemorySticksOnLoad
            // 
            this.lblMemorySticksOnLoad.AutoSize = true;
            this.lblMemorySticksOnLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemorySticksOnLoad.Location = new System.Drawing.Point(746, 378);
            this.lblMemorySticksOnLoad.Name = "lblMemorySticksOnLoad";
            this.lblMemorySticksOnLoad.Size = new System.Drawing.Size(31, 33);
            this.lblMemorySticksOnLoad.TabIndex = 31;
            this.lblMemorySticksOnLoad.Text = "?";
            // 
            // lblStoppedWallets
            // 
            this.lblStoppedWallets.AutoSize = true;
            this.lblStoppedWallets.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStoppedWallets.Location = new System.Drawing.Point(746, 411);
            this.lblStoppedWallets.Name = "lblStoppedWallets";
            this.lblStoppedWallets.Size = new System.Drawing.Size(31, 33);
            this.lblStoppedWallets.TabIndex = 32;
            this.lblStoppedWallets.Text = "?";
            // 
            // lblAverageStopped
            // 
            this.lblAverageStopped.AutoSize = true;
            this.lblAverageStopped.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAverageStopped.Location = new System.Drawing.Point(746, 444);
            this.lblAverageStopped.Name = "lblAverageStopped";
            this.lblAverageStopped.Size = new System.Drawing.Size(31, 33);
            this.lblAverageStopped.TabIndex = 33;
            this.lblAverageStopped.Text = "?";
            // 
            // lblDormant
            // 
            this.lblDormant.AutoSize = true;
            this.lblDormant.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDormant.Location = new System.Drawing.Point(746, 477);
            this.lblDormant.Name = "lblDormant";
            this.lblDormant.Size = new System.Drawing.Size(31, 33);
            this.lblDormant.TabIndex = 34;
            this.lblDormant.Text = "?";
            // 
            // printStatsDoc
            // 
            this.printStatsDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printStatsDoc_PrintPage);
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
            // formStats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(851, 620);
            this.Controls.Add(this.lblDormant);
            this.Controls.Add(this.lblAverageStopped);
            this.Controls.Add(this.lblStoppedWallets);
            this.Controls.Add(this.lblMemorySticksOnLoad);
            this.Controls.Add(this.lblWalletsDispatched);
            this.Controls.Add(this.lblAverageDispatched);
            this.Controls.Add(this.lblInactiveWallets);
            this.Controls.Add(this.lblAverageListeners);
            this.Controls.Add(this.lblNetListeners);
            this.Controls.Add(this.lblLostListeners);
            this.Controls.Add(this.lblNewListeners);
            this.Controls.Add(this.lblListenersToday);
            this.Controls.Add(this.lblWeeklyYearListeners);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnFinished);
            this.Controls.Add(this.Label16);
            this.Controls.Add(this.Label15);
            this.Controls.Add(this.Label14);
            this.Controls.Add(this.Label13);
            this.Controls.Add(this.Label11);
            this.Controls.Add(this.Label10);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formStats";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Label lblDate;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.Label Label6;
		internal System.Windows.Forms.Label Label7;
		internal System.Windows.Forms.Label Label8;
		internal System.Windows.Forms.Label Label9;
		internal System.Windows.Forms.Label Label10;
		internal System.Windows.Forms.Label Label11;
		internal System.Windows.Forms.Label Label13;
		internal System.Windows.Forms.Label Label14;
		internal System.Windows.Forms.Label Label15;
		internal System.Windows.Forms.Label Label16;
        private System.Windows.Forms.Button btnFinished;
        private System.Windows.Forms.Button btnPrint;
		internal System.Windows.Forms.Label lblWeeklyYearListeners;
		internal System.Windows.Forms.Label lblListenersToday;
		internal System.Windows.Forms.Label lblNewListeners;
		internal System.Windows.Forms.Label lblLostListeners;
		internal System.Windows.Forms.Label lblNetListeners;
		internal System.Windows.Forms.Label lblAverageListeners;
		internal System.Windows.Forms.Label lblInactiveWallets;
		internal System.Windows.Forms.Label lblAverageDispatched;
		internal System.Windows.Forms.Label lblWalletsDispatched;
		internal System.Windows.Forms.Label lblMemorySticksOnLoad;
		internal System.Windows.Forms.Label lblStoppedWallets;
		internal System.Windows.Forms.Label lblAverageStopped;
        internal System.Windows.Forms.Label lblDormant;
        private System.Drawing.Printing.PrintDocument printStatsDoc;
        internal TNBase.PrintPreviewDialogSelectPrinter printPreview;
	}
}
