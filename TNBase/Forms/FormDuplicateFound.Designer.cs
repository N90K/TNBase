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
	partial class FormDuplicateFound : System.Windows.Forms.Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDuplicateFound));
            this.Label1 = new System.Windows.Forms.Label();
            this.lblWallet = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.btnDontAdd = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSeconds = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.timerEnableAdd = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Label1.Location = new System.Drawing.Point(40, 19);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(592, 33);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "You have scanned the following wallet twice:";
            // 
            // lblWallet
            // 
            this.lblWallet.AutoSize = true;
            this.lblWallet.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWallet.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblWallet.Location = new System.Drawing.Point(638, 19);
            this.lblWallet.Name = "lblWallet";
            this.lblWallet.Size = new System.Drawing.Size(32, 33);
            this.lblWallet.TabIndex = 1;
            this.lblWallet.Text = "?";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.Black;
            this.btnAdd.Location = new System.Drawing.Point(442, 173);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(289, 86);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add the duplicate";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Label2.Location = new System.Drawing.Point(40, 114);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(497, 33);
            this.Label2.TabIndex = 3;
            this.Label2.Text = "Do you wan\'t to add it as a duplicate?";
            // 
            // btnDontAdd
            // 
            this.btnDontAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDontAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDontAdd.ForeColor = System.Drawing.Color.Black;
            this.btnDontAdd.Location = new System.Drawing.Point(76, 173);
            this.btnDontAdd.Name = "btnDontAdd";
            this.btnDontAdd.Size = new System.Drawing.Size(289, 86);
            this.btnDontAdd.TabIndex = 4;
            this.btnDontAdd.Text = "Don\'t add this duplicate";
            this.btnDontAdd.UseVisualStyleBackColor = false;
            this.btnDontAdd.Click += new System.EventHandler(this.btnDontAdd_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(70, 290);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(641, 33);
            this.label3.TabIndex = 5;
            this.label3.Text = "This form will close automatically in       seconds\r\n";
            // 
            // lblSeconds
            // 
            this.lblSeconds.AutoSize = true;
            this.lblSeconds.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeconds.ForeColor = System.Drawing.Color.Yellow;
            this.lblSeconds.Location = new System.Drawing.Point(549, 290);
            this.lblSeconds.Name = "lblSeconds";
            this.lblSeconds.Size = new System.Drawing.Size(31, 33);
            this.lblSeconds.TabIndex = 6;
            this.lblSeconds.Text = "?";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // timerEnableAdd
            // 
            this.timerEnableAdd.Enabled = true;
            this.timerEnableAdd.Interval = 250;
            this.timerEnableAdd.Tick += new System.EventHandler(this.timerEnableAdd_Tick);
            // 
            // FormDuplicateFound
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(795, 352);
            this.Controls.Add(this.lblSeconds);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnDontAdd);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblWallet);
            this.Controls.Add(this.Label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDuplicateFound";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.formDuplicateFound_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Label lblWallet;
        private System.Windows.Forms.Button btnAdd;
		internal System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Button btnDontAdd;
        internal Label label3;
        internal Label lblSeconds;
        private Timer timer;
        private Timer timerEnableAdd;
    }
}
