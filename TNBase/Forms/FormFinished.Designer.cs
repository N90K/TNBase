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
	partial class FormFinished : System.Windows.Forms.Form
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFinished));
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.lblFinishTime = new System.Windows.Forms.Label();
            this.lblElapsedTime = new System.Windows.Forms.Label();
            this.lblScannedIn = new System.Windows.Forms.Label();
            this.lblScannedOut = new System.Windows.Forms.Label();
            this.tmrQuit = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.Label1.Location = new System.Drawing.Point(253, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(391, 108);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "TNBase";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Label2.Location = new System.Drawing.Point(239, 126);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(439, 55);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "Programme Closed";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(285, 230);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(147, 31);
            this.Label3.TabIndex = 2;
            this.Label3.Text = "Start Time:";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(285, 270);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(137, 31);
            this.Label4.TabIndex = 3;
            this.Label4.Text = "End Time:";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(285, 311);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(187, 31);
            this.Label5.TabIndex = 4;
            this.Label5.Text = "Elapsed Time:";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(285, 352);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(159, 31);
            this.Label6.TabIndex = 5;
            this.Label6.Text = "Scanned In:";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.Location = new System.Drawing.Point(285, 393);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(180, 31);
            this.Label7.TabIndex = 6;
            this.Label7.Text = "Scanned Out:";
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Label8.Location = new System.Drawing.Point(200, 465);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(518, 55);
            this.Label8.TabIndex = 7;
            this.Label8.Text = "Have a good weekend!";
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.Location = new System.Drawing.Point(286, 532);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(389, 25);
            this.Label9.TabIndex = 8;
            this.Label9.Text = "Note: This form will close automatically.";
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartTime.Location = new System.Drawing.Point(491, 230);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(29, 31);
            this.lblStartTime.TabIndex = 9;
            this.lblStartTime.Text = "?";
            // 
            // lblFinishTime
            // 
            this.lblFinishTime.AutoSize = true;
            this.lblFinishTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinishTime.Location = new System.Drawing.Point(491, 270);
            this.lblFinishTime.Name = "lblFinishTime";
            this.lblFinishTime.Size = new System.Drawing.Size(29, 31);
            this.lblFinishTime.TabIndex = 10;
            this.lblFinishTime.Text = "?";
            // 
            // lblElapsedTime
            // 
            this.lblElapsedTime.AutoSize = true;
            this.lblElapsedTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblElapsedTime.Location = new System.Drawing.Point(491, 311);
            this.lblElapsedTime.Name = "lblElapsedTime";
            this.lblElapsedTime.Size = new System.Drawing.Size(29, 31);
            this.lblElapsedTime.TabIndex = 11;
            this.lblElapsedTime.Text = "?";
            // 
            // lblScannedIn
            // 
            this.lblScannedIn.AutoSize = true;
            this.lblScannedIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScannedIn.Location = new System.Drawing.Point(491, 352);
            this.lblScannedIn.Name = "lblScannedIn";
            this.lblScannedIn.Size = new System.Drawing.Size(29, 31);
            this.lblScannedIn.TabIndex = 12;
            this.lblScannedIn.Text = "?";
            // 
            // lblScannedOut
            // 
            this.lblScannedOut.AutoSize = true;
            this.lblScannedOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScannedOut.Location = new System.Drawing.Point(491, 393);
            this.lblScannedOut.Name = "lblScannedOut";
            this.lblScannedOut.Size = new System.Drawing.Size(29, 31);
            this.lblScannedOut.TabIndex = 13;
            this.lblScannedOut.Text = "?";
            // 
            // tmrQuit
            // 
            this.tmrQuit.Enabled = true;
            this.tmrQuit.Interval = 8000;
            this.tmrQuit.Tick += new System.EventHandler(this.tmrQuit_Tick);
            // 
            // formFinished
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 599);
            this.Controls.Add(this.lblScannedOut);
            this.Controls.Add(this.lblScannedIn);
            this.Controls.Add(this.lblElapsedTime);
            this.Controls.Add(this.lblFinishTime);
            this.Controls.Add(this.lblStartTime);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formFinished";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.Label Label6;
		internal System.Windows.Forms.Label Label7;
		internal System.Windows.Forms.Label Label8;
		internal System.Windows.Forms.Label Label9;
		internal System.Windows.Forms.Label lblStartTime;
		internal System.Windows.Forms.Label lblFinishTime;
		internal System.Windows.Forms.Label lblElapsedTime;
		internal System.Windows.Forms.Label lblScannedIn;
		internal System.Windows.Forms.Label lblScannedOut;
        private System.Windows.Forms.Timer tmrQuit;
	}
}
