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
	partial class FormDuplicates : System.Windows.Forms.Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDuplicates));
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.btnDynamic = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lstDuplicates = new System.Windows.Forms.ListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Magazine = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Player = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Telephone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Joined = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StatusInfo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Stock = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LastIn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LastOut = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Info = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(431, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(232, 33);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "Select a Listener";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(12, 466);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(1068, 66);
            this.Label2.TabIndex = 3;
            this.Label2.Text = "This form can be used to select the correct listener when more than one listeners" +
    " \r\nhave the same Title, Forename and Surname.";
            // 
            // btnDynamic
            // 
            this.btnDynamic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnDynamic.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDynamic.Location = new System.Drawing.Point(742, 557);
            this.btnDynamic.Name = "btnDynamic";
            this.btnDynamic.Size = new System.Drawing.Size(223, 63);
            this.btnDynamic.TabIndex = 4;
            this.btnDynamic.Text = "?";
            this.btnDynamic.UseVisualStyleBackColor = false;
            this.btnDynamic.Click += new System.EventHandler(this.btnDynamic_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(108, 557);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(223, 63);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lstDuplicates
            // 
            this.lstDuplicates.AllowColumnReorder = true;
            this.lstDuplicates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2,
            this.ColumnHeader3,
            this.ColumnHeader4,
            this.ColumnHeader5,
            this.ColumnHeader6,
            this.ColumnHeader7,
            this.ColumnHeader8,
            this.ColumnHeader9,
            this.Magazine,
            this.Player,
            this.Telephone,
            this.Joined,
            this.ColumnHeader10,
            this.Status,
            this.StatusInfo,
            this.Stock,
            this.LastIn,
            this.LastOut,
            this.Info});
            this.lstDuplicates.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstDuplicates.FullRowSelect = true;
            this.lstDuplicates.GridLines = true;
            this.lstDuplicates.HideSelection = false;
            this.lstDuplicates.Location = new System.Drawing.Point(12, 50);
            this.lstDuplicates.MultiSelect = false;
            this.lstDuplicates.Name = "lstDuplicates";
            this.lstDuplicates.Size = new System.Drawing.Size(1075, 392);
            this.lstDuplicates.TabIndex = 6;
            this.lstDuplicates.UseCompatibleStateImageBehavior = false;
            this.lstDuplicates.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Wallet";
            this.ColumnHeader1.Width = 65;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Title";
            this.ColumnHeader2.Width = 50;
            // 
            // ColumnHeader3
            // 
            this.ColumnHeader3.Text = "Forename";
            this.ColumnHeader3.Width = 85;
            // 
            // ColumnHeader4
            // 
            this.ColumnHeader4.Text = "Surname";
            this.ColumnHeader4.Width = 80;
            // 
            // ColumnHeader5
            // 
            this.ColumnHeader5.Text = "Addr1";
            this.ColumnHeader5.Width = 100;
            // 
            // ColumnHeader6
            // 
            this.ColumnHeader6.Text = "Addr2";
            this.ColumnHeader6.Width = 100;
            // 
            // ColumnHeader7
            // 
            this.ColumnHeader7.Text = "Town";
            this.ColumnHeader7.Width = 80;
            // 
            // ColumnHeader8
            // 
            this.ColumnHeader8.Text = "County";
            this.ColumnHeader8.Width = 80;
            // 
            // ColumnHeader9
            // 
            this.ColumnHeader9.Text = "Postcode";
            this.ColumnHeader9.Width = 80;
            // 
            // Magazine
            // 
            this.Magazine.Text = "Magazine";
            this.Magazine.Width = 100;
            // 
            // Player
            // 
            this.Player.Text = "Player";
            // 
            // Telephone
            // 
            this.Telephone.Text = "Telephone";
            this.Telephone.Width = 90;
            // 
            // Joined
            // 
            this.Joined.Text = "Joined";
            this.Joined.Width = 59;
            // 
            // ColumnHeader10
            // 
            this.ColumnHeader10.Text = "Birthday";
            this.ColumnHeader10.Width = 70;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            // 
            // StatusInfo
            // 
            this.StatusInfo.Text = "StatusInfo";
            // 
            // Stock
            // 
            this.Stock.Text = "Stock";
            // 
            // LastIn
            // 
            this.LastIn.Text = "LastIn";
            // 
            // LastOut
            // 
            this.LastOut.Text = "LastOut";
            // 
            // Info
            // 
            this.Info.Text = "Info";
            // 
            // formDuplicates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 632);
            this.Controls.Add(this.lstDuplicates);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDynamic);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formDuplicates";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Button btnDynamic;
        private System.Windows.Forms.Button btnCancel;
		internal System.Windows.Forms.ListView lstDuplicates;
		internal System.Windows.Forms.ColumnHeader ColumnHeader1;
		internal System.Windows.Forms.ColumnHeader ColumnHeader2;
		internal System.Windows.Forms.ColumnHeader ColumnHeader3;
		internal System.Windows.Forms.ColumnHeader ColumnHeader4;
		internal System.Windows.Forms.ColumnHeader ColumnHeader5;
		internal System.Windows.Forms.ColumnHeader ColumnHeader6;
		internal System.Windows.Forms.ColumnHeader ColumnHeader7;
		internal System.Windows.Forms.ColumnHeader ColumnHeader8;
		internal System.Windows.Forms.ColumnHeader ColumnHeader9;
		internal System.Windows.Forms.ColumnHeader Magazine;
		internal System.Windows.Forms.ColumnHeader Player;
		internal System.Windows.Forms.ColumnHeader Telephone;
		internal System.Windows.Forms.ColumnHeader Joined;
        internal System.Windows.Forms.ColumnHeader ColumnHeader10;
		internal System.Windows.Forms.ColumnHeader Status;
		internal System.Windows.Forms.ColumnHeader StatusInfo;
		internal System.Windows.Forms.ColumnHeader Stock;
		internal System.Windows.Forms.ColumnHeader LastIn;
		internal System.Windows.Forms.ColumnHeader LastOut;
		internal System.Windows.Forms.ColumnHeader Info;
	}
}
