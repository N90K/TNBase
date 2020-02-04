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
	partial class FormBrowse : System.Windows.Forms.Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBrowse));
            this.lstBrowse = new System.Windows.Forms.ListView();
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Forename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Surname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Addr1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Addr2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Town = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.County = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Postcode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Magazine = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Player = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Telephone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Joined = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Birthday = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StatusInfo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Stock = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LastIn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LastOut = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Info = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnCancelStop = new System.Windows.Forms.Button();
            this.btnStopSending = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.cmbOrder = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.MagazineStock = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstFreeze = new System.Windows.Forms.ListView();
            this.walletFreeze = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lstBrowse
            // 
            this.lstBrowse.AllowColumnReorder = true;
            this.lstBrowse.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Title,
            this.Forename,
            this.Surname,
            this.Addr1,
            this.Addr2,
            this.Town,
            this.County,
            this.Postcode,
            this.Magazine,
            this.Player,
            this.Telephone,
            this.Joined,
            this.Birthday,
            this.Status,
            this.StatusInfo,
            this.Stock,
            this.MagazineStock,
            this.LastIn,
            this.LastOut,
            this.Info});
            this.lstBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBrowse.FullRowSelect = true;
            this.lstBrowse.GridLines = true;
            this.lstBrowse.HideSelection = false;
            this.lstBrowse.Location = new System.Drawing.Point(96, 61);
            this.lstBrowse.MultiSelect = false;
            this.lstBrowse.Name = "lstBrowse";
            this.lstBrowse.Size = new System.Drawing.Size(991, 405);
            this.lstBrowse.TabIndex = 2;
            this.lstBrowse.UseCompatibleStateImageBehavior = false;
            this.lstBrowse.View = System.Windows.Forms.View.Details;
            this.lstBrowse.SelectedIndexChanged += new System.EventHandler(this.lstBrowse_SelectedIndexChanged);
            // 
            // Title
            // 
            this.Title.Text = "Title";
            this.Title.Width = 50;
            // 
            // Forename
            // 
            this.Forename.Text = "Forename";
            this.Forename.Width = 85;
            // 
            // Surname
            // 
            this.Surname.Text = "Surname";
            this.Surname.Width = 80;
            // 
            // Addr1
            // 
            this.Addr1.Text = "Addr1";
            this.Addr1.Width = 100;
            // 
            // Addr2
            // 
            this.Addr2.Text = "Addr2";
            this.Addr2.Width = 100;
            // 
            // Town
            // 
            this.Town.Text = "Town";
            this.Town.Width = 80;
            // 
            // County
            // 
            this.County.Text = "County";
            this.County.Width = 80;
            // 
            // Postcode
            // 
            this.Postcode.Text = "Postcode";
            this.Postcode.Width = 80;
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
            // 
            // Birthday
            // 
            this.Birthday.Text = "Birthday";
            this.Birthday.Width = 70;
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
            this.Stock.Text = "News Stock";
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
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(422, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(255, 33);
            this.lblTitle.TabIndex = 51;
            this.lblTitle.Text = "Browse Listeners";
            // 
            // btnCancelStop
            // 
            this.btnCancelStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCancelStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelStop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelStop.Location = new System.Drawing.Point(663, 546);
            this.btnCancelStop.Name = "btnCancelStop";
            this.btnCancelStop.Size = new System.Drawing.Size(209, 74);
            this.btnCancelStop.TabIndex = 56;
            this.btnCancelStop.Text = "Cancel a Stop";
            this.btnCancelStop.UseVisualStyleBackColor = false;
            this.btnCancelStop.Click += new System.EventHandler(this.btnCancelStop_Click);
            // 
            // btnStopSending
            // 
            this.btnStopSending.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnStopSending.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStopSending.Location = new System.Drawing.Point(227, 546);
            this.btnStopSending.Name = "btnStopSending";
            this.btnStopSending.Size = new System.Drawing.Size(209, 74);
            this.btnStopSending.TabIndex = 55;
            this.btnStopSending.Text = "Stop Sending";
            this.btnStopSending.UseVisualStyleBackColor = false;
            this.btnStopSending.Click += new System.EventHandler(this.btnStopSending_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(448, 546);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(209, 74);
            this.btnEdit.TabIndex = 54;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemove.Location = new System.Drawing.Point(12, 546);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(209, 74);
            this.btnRemove.TabIndex = 53;
            this.btnRemove.Text = "Delete";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnDone
            // 
            this.btnDone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDone.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDone.Location = new System.Drawing.Point(878, 546);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(209, 74);
            this.btnDone.TabIndex = 57;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = false;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.BackColor = System.Drawing.Color.White;
            this.btnFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFirst.Location = new System.Drawing.Point(12, 472);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(78, 64);
            this.btnFirst.TabIndex = 58;
            this.btnFirst.Text = "<<";
            this.btnFirst.UseVisualStyleBackColor = false;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.BackColor = System.Drawing.Color.White;
            this.btnPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.Location = new System.Drawing.Point(96, 472);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(78, 64);
            this.btnPrevious.TabIndex = 59;
            this.btnPrevious.Text = "<";
            this.btnPrevious.UseVisualStyleBackColor = false;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.White;
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(180, 472);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(78, 64);
            this.btnNext.TabIndex = 60;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnLast
            // 
            this.btnLast.BackColor = System.Drawing.Color.White;
            this.btnLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLast.Location = new System.Drawing.Point(264, 472);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(78, 64);
            this.btnLast.TabIndex = 61;
            this.btnLast.Text = ">>";
            this.btnLast.UseVisualStyleBackColor = false;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // cmbOrder
            // 
            this.cmbOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOrder.FormattingEnabled = true;
            this.cmbOrder.Items.AddRange(new object[] {
            "Wallet",
            "Surname"});
            this.cmbOrder.Location = new System.Drawing.Point(922, 472);
            this.cmbOrder.Name = "cmbOrder";
            this.cmbOrder.Size = new System.Drawing.Size(165, 39);
            this.cmbOrder.TabIndex = 62;
            this.cmbOrder.SelectedIndexChanged += new System.EventHandler(this.cmbOrder_SelectedIndexChanged);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(779, 472);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(127, 31);
            this.Label1.TabIndex = 63;
            this.Label1.Text = "Order by:";
            // 
            // MagazineStock
            // 
            this.MagazineStock.Text = "Mag Stock";
            // 
            // lstFreeze
            // 
            this.lstFreeze.AllowColumnReorder = true;
            this.lstFreeze.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.walletFreeze});
            this.lstFreeze.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstFreeze.FullRowSelect = true;
            this.lstFreeze.GridLines = true;
            this.lstFreeze.HideSelection = false;
            this.lstFreeze.Location = new System.Drawing.Point(12, 61);
            this.lstFreeze.MultiSelect = false;
            this.lstFreeze.Name = "lstFreeze";
            this.lstFreeze.Size = new System.Drawing.Size(83, 405);
            this.lstFreeze.TabIndex = 64;
            this.lstFreeze.UseCompatibleStateImageBehavior = false;
            this.lstFreeze.View = System.Windows.Forms.View.Details;
            this.lstFreeze.SelectedIndexChanged += new System.EventHandler(this.lstFreeze_SelectedIndexChanged);
            // 
            // walletFreeze
            // 
            this.walletFreeze.Text = "Wallet";
            this.walletFreeze.Width = 87;
            // 
            // FormBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1104, 634);
            this.Controls.Add(this.lstFreeze);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.cmbOrder);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.btnCancelStop);
            this.Controls.Add(this.btnStopSending);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lstBrowse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBrowse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		internal System.Windows.Forms.ListView lstBrowse;
		internal System.Windows.Forms.ColumnHeader Title;
		internal System.Windows.Forms.ColumnHeader Forename;
		internal System.Windows.Forms.ColumnHeader Surname;
		internal System.Windows.Forms.ColumnHeader Addr1;
		internal System.Windows.Forms.ColumnHeader Addr2;
		internal System.Windows.Forms.ColumnHeader Town;
		internal System.Windows.Forms.ColumnHeader County;
		internal System.Windows.Forms.ColumnHeader Postcode;
		internal System.Windows.Forms.ColumnHeader Birthday;
		internal System.Windows.Forms.Label lblTitle;
		internal System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.Button btnCancelStop;
        private System.Windows.Forms.Button btnStopSending;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnLast;
		internal System.Windows.Forms.ColumnHeader Magazine;
		internal System.Windows.Forms.ColumnHeader Player;
		internal System.Windows.Forms.ColumnHeader Telephone;
		internal System.Windows.Forms.ColumnHeader Joined;
		internal System.Windows.Forms.ColumnHeader StatusInfo;
		internal System.Windows.Forms.ColumnHeader Stock;
		internal System.Windows.Forms.ColumnHeader LastIn;
		internal System.Windows.Forms.ColumnHeader LastOut;
        internal System.Windows.Forms.ColumnHeader Info;
        private System.Windows.Forms.ComboBox cmbOrder;
		internal System.Windows.Forms.Label Label1;
        internal ColumnHeader MagazineStock;
        internal ListView lstFreeze;
        internal ColumnHeader walletFreeze;
    }
}
