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
	partial class FormEdit : System.Windows.Forms.Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEdit));
            this.txtInformation = new System.Windows.Forms.TextBox();
            this.Label12 = new System.Windows.Forms.Label();
            this.chkMagazine = new System.Windows.Forms.CheckBox();
            this.chkMemStickPlayer = new System.Windows.Forms.CheckBox();
            this.Label10 = new System.Windows.Forms.Label();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.txtPostcode = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.txtCounty = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.txtTown = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.txtAddr2 = new System.Windows.Forms.TextBox();
            this.txtAddr1 = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.txtForename = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.comboTitle = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.btnFinished = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.Label11 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblExtra = new System.Windows.Forms.Label();
            this.lblExtraContent = new System.Windows.Forms.Label();
            this.lstInOut = new System.Windows.Forms.ListView();
            this.ColumnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.btnRestore = new System.Windows.Forms.Button();
            this.chkNoBirthday = new System.Windows.Forms.CheckBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.Label13 = new System.Windows.Forms.Label();
            this.lblWallet = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.dtpJoined = new System.Windows.Forms.DateTimePicker();
            this.Label15 = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.Label16 = new System.Windows.Forms.Label();
            this.Label17 = new System.Windows.Forms.Label();
            this.DateLastIn = new System.Windows.Forms.DateTimePicker();
            this.DateLastOut = new System.Windows.Forms.DateTimePicker();
            this.Label19 = new System.Windows.Forms.Label();
            this.Label20 = new System.Windows.Forms.Label();
            this.txtMagazineStock = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cbBirthdayDay = new System.Windows.Forms.ComboBox();
            this.cbBirthdayMonth = new System.Windows.Forms.ComboBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.chkWarnOfAddressChange = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.chkOnlineOnly = new System.Windows.Forms.CheckBox();
            this.stockGroup = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.stockGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtInformation
            // 
            this.txtInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtInformation.Location = new System.Drawing.Point(902, 121);
            this.txtInformation.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtInformation.MaxLength = 1000;
            this.txtInformation.Multiline = true;
            this.txtInformation.Name = "txtInformation";
            this.txtInformation.Size = new System.Drawing.Size(414, 133);
            this.txtInformation.TabIndex = 49;
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Label12.Location = new System.Drawing.Point(897, 88);
            this.Label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(107, 24);
            this.Label12.TabIndex = 48;
            this.Label12.Text = "Information:";
            // 
            // chkMagazine
            // 
            this.chkMagazine.AutoSize = true;
            this.chkMagazine.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkMagazine.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkMagazine.Location = new System.Drawing.Point(7, 107);
            this.chkMagazine.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkMagazine.Name = "chkMagazine";
            this.chkMagazine.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkMagazine.Size = new System.Drawing.Size(111, 28);
            this.chkMagazine.TabIndex = 47;
            this.chkMagazine.Text = "Magazine";
            this.chkMagazine.UseVisualStyleBackColor = true;
            this.chkMagazine.CheckedChanged += new System.EventHandler(this.chkMagazine_CheckedChanged);
            // 
            // chkMemStickPlayer
            // 
            this.chkMemStickPlayer.AutoSize = true;
            this.chkMemStickPlayer.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkMemStickPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkMemStickPlayer.Location = new System.Drawing.Point(7, 22);
            this.chkMemStickPlayer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkMemStickPlayer.Name = "chkMemStickPlayer";
            this.chkMemStickPlayer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkMemStickPlayer.Size = new System.Drawing.Size(255, 28);
            this.chkMemStickPlayer.TabIndex = 46;
            this.chkMemStickPlayer.Text = "Memory stick player issued";
            this.chkMemStickPlayer.UseVisualStyleBackColor = true;
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Label10.Location = new System.Drawing.Point(14, 479);
            this.Label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(77, 24);
            this.Label10.TabIndex = 45;
            this.Label10.Text = "Birthday";
            // 
            // txtTelephone
            // 
            this.txtTelephone.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTelephone.Location = new System.Drawing.Point(141, 428);
            this.txtTelephone.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(242, 29);
            this.txtTelephone.TabIndex = 43;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Label9.Location = new System.Drawing.Point(14, 434);
            this.Label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(103, 24);
            this.Label9.TabIndex = 42;
            this.Label9.Text = "Telephone";
            // 
            // txtPostcode
            // 
            this.txtPostcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPostcode.Location = new System.Drawing.Point(141, 355);
            this.txtPostcode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPostcode.MaxLength = 8;
            this.txtPostcode.Name = "txtPostcode";
            this.txtPostcode.Size = new System.Drawing.Size(242, 29);
            this.txtPostcode.TabIndex = 41;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Label8.Location = new System.Drawing.Point(14, 358);
            this.Label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(89, 24);
            this.Label8.TabIndex = 40;
            this.Label8.Text = "Postcode";
            // 
            // txtCounty
            // 
            this.txtCounty.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCounty.Location = new System.Drawing.Point(141, 317);
            this.txtCounty.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtCounty.MaxLength = 50;
            this.txtCounty.Name = "txtCounty";
            this.txtCounty.Size = new System.Drawing.Size(312, 29);
            this.txtCounty.TabIndex = 39;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Label7.Location = new System.Drawing.Point(14, 320);
            this.Label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(69, 24);
            this.Label7.TabIndex = 38;
            this.Label7.Text = "County";
            // 
            // txtTown
            // 
            this.txtTown.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTown.Location = new System.Drawing.Point(141, 279);
            this.txtTown.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtTown.MaxLength = 50;
            this.txtTown.Name = "txtTown";
            this.txtTown.Size = new System.Drawing.Size(312, 29);
            this.txtTown.TabIndex = 37;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Label6.Location = new System.Drawing.Point(14, 282);
            this.Label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(58, 24);
            this.Label6.TabIndex = 36;
            this.Label6.Text = "Town";
            // 
            // txtAddr2
            // 
            this.txtAddr2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAddr2.Location = new System.Drawing.Point(141, 242);
            this.txtAddr2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtAddr2.MaxLength = 50;
            this.txtAddr2.Name = "txtAddr2";
            this.txtAddr2.Size = new System.Drawing.Size(312, 29);
            this.txtAddr2.TabIndex = 35;
            // 
            // txtAddr1
            // 
            this.txtAddr1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAddr1.Location = new System.Drawing.Point(141, 205);
            this.txtAddr1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtAddr1.MaxLength = 50;
            this.txtAddr1.Name = "txtAddr1";
            this.txtAddr1.Size = new System.Drawing.Size(312, 29);
            this.txtAddr1.TabIndex = 34;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Label5.Location = new System.Drawing.Point(14, 208);
            this.Label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(80, 24);
            this.Label5.TabIndex = 33;
            this.Label5.Text = "Address";
            // 
            // txtForename
            // 
            this.txtForename.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtForename.Location = new System.Drawing.Point(141, 130);
            this.txtForename.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtForename.MaxLength = 50;
            this.txtForename.Name = "txtForename";
            this.txtForename.Size = new System.Drawing.Size(242, 29);
            this.txtForename.TabIndex = 32;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Label4.Location = new System.Drawing.Point(14, 170);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(87, 24);
            this.Label4.TabIndex = 31;
            this.Label4.Text = "Surname";
            // 
            // txtSurname
            // 
            this.txtSurname.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSurname.Location = new System.Drawing.Point(141, 167);
            this.txtSurname.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtSurname.MaxLength = 50;
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(242, 29);
            this.txtSurname.TabIndex = 30;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Label3.Location = new System.Drawing.Point(14, 133);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(87, 24);
            this.Label3.TabIndex = 29;
            this.Label3.Text = "Forname";
            // 
            // comboTitle
            // 
            this.comboTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboTitle.FormattingEnabled = true;
            this.comboTitle.Location = new System.Drawing.Point(141, 88);
            this.comboTitle.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboTitle.Name = "comboTitle";
            this.comboTitle.Size = new System.Drawing.Size(242, 32);
            this.comboTitle.TabIndex = 28;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Label1.Location = new System.Drawing.Point(14, 92);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(45, 24);
            this.Label1.TabIndex = 27;
            this.Label1.Text = "Title";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Label2.Location = new System.Drawing.Point(561, 10);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(202, 31);
            this.Label2.TabIndex = 50;
            this.Label2.Text = "Edit a Listener";
            // 
            // btnFinished
            // 
            this.btnFinished.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnFinished.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnFinished.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFinished.Location = new System.Drawing.Point(1100, 564);
            this.btnFinished.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnFinished.Name = "btnFinished";
            this.btnFinished.Size = new System.Drawing.Size(216, 62);
            this.btnFinished.TabIndex = 52;
            this.btnFinished.Text = "Finished";
            this.btnFinished.UseVisualStyleBackColor = false;
            this.btnFinished.Click += new System.EventHandler(this.btnFinished_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.Location = new System.Drawing.Point(20, 564);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(161, 62);
            this.btnCancel.TabIndex = 51;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Label11.Location = new System.Drawing.Point(479, 244);
            this.Label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(65, 24);
            this.Label11.TabIndex = 53;
            this.Label11.Text = "Status:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStatus.Location = new System.Drawing.Point(602, 244);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(20, 24);
            this.lblStatus.TabIndex = 54;
            this.lblStatus.Text = "?";
            // 
            // lblExtra
            // 
            this.lblExtra.AutoSize = true;
            this.lblExtra.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblExtra.Location = new System.Drawing.Point(488, 280);
            this.lblExtra.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExtra.Name = "lblExtra";
            this.lblExtra.Size = new System.Drawing.Size(20, 24);
            this.lblExtra.TabIndex = 55;
            this.lblExtra.Text = "?";
            // 
            // lblExtraContent
            // 
            this.lblExtraContent.AutoSize = true;
            this.lblExtraContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblExtraContent.Location = new System.Drawing.Point(488, 308);
            this.lblExtraContent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExtraContent.Name = "lblExtraContent";
            this.lblExtraContent.Size = new System.Drawing.Size(20, 24);
            this.lblExtraContent.TabIndex = 56;
            this.lblExtraContent.Text = "?";
            // 
            // lstInOut
            // 
            this.lstInOut.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader9,
            this.ColumnHeader1,
            this.ColumnHeader2,
            this.ColumnHeader3,
            this.ColumnHeader4,
            this.ColumnHeader5,
            this.ColumnHeader6,
            this.ColumnHeader7,
            this.ColumnHeader8});
            this.lstInOut.FullRowSelect = true;
            this.lstInOut.GridLines = true;
            this.lstInOut.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstInOut.HideSelection = false;
            this.lstInOut.Location = new System.Drawing.Point(492, 430);
            this.lstInOut.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lstInOut.MultiSelect = false;
            this.lstInOut.Name = "lstInOut";
            this.lstInOut.Size = new System.Drawing.Size(823, 107);
            this.lstInOut.TabIndex = 57;
            this.lstInOut.UseCompatibleStateImageBehavior = false;
            this.lstInOut.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeader9
            // 
            this.ColumnHeader9.Text = "*";
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "8 Weeks Ago";
            this.ColumnHeader1.Width = 80;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "7 Weeks Ago";
            this.ColumnHeader2.Width = 80;
            // 
            // ColumnHeader3
            // 
            this.ColumnHeader3.Text = "6 Weeks Ago";
            this.ColumnHeader3.Width = 80;
            // 
            // ColumnHeader4
            // 
            this.ColumnHeader4.Text = "5 Weeks Ago";
            this.ColumnHeader4.Width = 80;
            // 
            // ColumnHeader5
            // 
            this.ColumnHeader5.Text = "4 Weeks Ago";
            this.ColumnHeader5.Width = 80;
            // 
            // ColumnHeader6
            // 
            this.ColumnHeader6.Text = "3 Weeks Ago";
            this.ColumnHeader6.Width = 80;
            // 
            // ColumnHeader7
            // 
            this.ColumnHeader7.Text = "2 Weeks Ago";
            this.ColumnHeader7.Width = 80;
            // 
            // ColumnHeader8
            // 
            this.ColumnHeader8.Text = "This Week";
            this.ColumnHeader8.Width = 80;
            // 
            // btnRestore
            // 
            this.btnRestore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnRestore.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRestore.Location = new System.Drawing.Point(747, 302);
            this.btnRestore.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(108, 39);
            this.btnRestore.TabIndex = 58;
            this.btnRestore.Text = "Restore";
            this.btnRestore.UseVisualStyleBackColor = false;
            this.btnRestore.Visible = false;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // chkNoBirthday
            // 
            this.chkNoBirthday.AutoSize = true;
            this.chkNoBirthday.BackColor = System.Drawing.Color.Transparent;
            this.chkNoBirthday.Checked = true;
            this.chkNoBirthday.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNoBirthday.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkNoBirthday.Location = new System.Drawing.Point(201, 513);
            this.chkNoBirthday.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkNoBirthday.Name = "chkNoBirthday";
            this.chkNoBirthday.Size = new System.Drawing.Size(157, 24);
            this.chkNoBirthday.TabIndex = 59;
            this.chkNoBirthday.Text = "Birthday Unknown";
            this.chkNoBirthday.UseVisualStyleBackColor = false;
            this.chkNoBirthday.CheckedChanged += new System.EventHandler(this.chkNoBirthday_CheckedChanged);
            this.chkNoBirthday.Validating += new System.ComponentModel.CancelEventHandler(this.chkNoBirthday_Validating);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnNext.Location = new System.Drawing.Point(666, 564);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(91, 62);
            this.btnNext.TabIndex = 60;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnPrevious.Location = new System.Drawing.Point(568, 564);
            this.btnPrevious.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(91, 62);
            this.btnPrevious.TabIndex = 61;
            this.btnPrevious.Text = "<";
            this.btnPrevious.UseVisualStyleBackColor = false;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFirst.Location = new System.Drawing.Point(470, 564);
            this.btnFirst.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(91, 62);
            this.btnFirst.TabIndex = 62;
            this.btnFirst.Text = "<<";
            this.btnFirst.UseVisualStyleBackColor = false;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnLast
            // 
            this.btnLast.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnLast.Location = new System.Drawing.Point(764, 564);
            this.btnLast.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(91, 62);
            this.btnLast.TabIndex = 63;
            this.btnLast.Text = ">>";
            this.btnLast.UseVisualStyleBackColor = false;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Label13.Location = new System.Drawing.Point(15, 54);
            this.Label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(61, 24);
            this.Label13.TabIndex = 64;
            this.Label13.Text = "Wallet";
            // 
            // lblWallet
            // 
            this.lblWallet.AutoSize = true;
            this.lblWallet.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblWallet.Location = new System.Drawing.Point(136, 54);
            this.lblWallet.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWallet.Name = "lblWallet";
            this.lblWallet.Size = new System.Drawing.Size(20, 24);
            this.lblWallet.TabIndex = 65;
            this.lblWallet.Text = "?";
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Label14.Location = new System.Drawing.Point(479, 376);
            this.Label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(67, 24);
            this.Label14.TabIndex = 66;
            this.Label14.Text = "Joined";
            // 
            // dtpJoined
            // 
            this.dtpJoined.CustomFormat = "yyyy/MM/dd";
            this.dtpJoined.Enabled = false;
            this.dtpJoined.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpJoined.Location = new System.Drawing.Point(573, 371);
            this.dtpJoined.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtpJoined.MaxDate = new System.DateTime(2099, 5, 25, 0, 0, 0, 0);
            this.dtpJoined.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpJoined.Name = "dtpJoined";
            this.dtpJoined.Size = new System.Drawing.Size(242, 29);
            this.dtpJoined.TabIndex = 67;
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Label15.Location = new System.Drawing.Point(7, 59);
            this.Label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(109, 24);
            this.Label15.TabIndex = 68;
            this.Label15.Text = "News Stock";
            // 
            // txtStock
            // 
            this.txtStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtStock.Location = new System.Drawing.Point(147, 56);
            this.txtStock.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtStock.MaxLength = 8;
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(138, 29);
            this.txtStock.TabIndex = 69;
            // 
            // Label16
            // 
            this.Label16.AutoSize = true;
            this.Label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Label16.Location = new System.Drawing.Point(915, 320);
            this.Label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(58, 24);
            this.Label16.TabIndex = 70;
            this.Label16.Text = "LastIn";
            // 
            // Label17
            // 
            this.Label17.AutoSize = true;
            this.Label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Label17.Location = new System.Drawing.Point(915, 365);
            this.Label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(73, 24);
            this.Label17.TabIndex = 71;
            this.Label17.Text = "LastOut";
            // 
            // DateLastIn
            // 
            this.DateLastIn.CustomFormat = "yyyy/MM/dd";
            this.DateLastIn.Enabled = false;
            this.DateLastIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DateLastIn.Location = new System.Drawing.Point(1031, 316);
            this.DateLastIn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DateLastIn.MaxDate = new System.DateTime(2099, 5, 25, 0, 0, 0, 0);
            this.DateLastIn.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.DateLastIn.Name = "DateLastIn";
            this.DateLastIn.Size = new System.Drawing.Size(242, 29);
            this.DateLastIn.TabIndex = 72;
            // 
            // DateLastOut
            // 
            this.DateLastOut.CustomFormat = "yyyy/MM/dd";
            this.DateLastOut.Enabled = false;
            this.DateLastOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DateLastOut.Location = new System.Drawing.Point(1031, 365);
            this.DateLastOut.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DateLastOut.MaxDate = new System.DateTime(2099, 5, 25, 0, 0, 0, 0);
            this.DateLastOut.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.DateLastOut.Name = "DateLastOut";
            this.DateLastOut.Size = new System.Drawing.Size(242, 29);
            this.DateLastOut.TabIndex = 73;
            // 
            // Label19
            // 
            this.Label19.AutoSize = true;
            this.Label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Label19.Location = new System.Drawing.Point(1027, 320);
            this.Label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(39, 24);
            this.Label19.TabIndex = 76;
            this.Label19.Text = "N/a";
            // 
            // Label20
            // 
            this.Label20.AutoSize = true;
            this.Label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Label20.Location = new System.Drawing.Point(1027, 365);
            this.Label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label20.Name = "Label20";
            this.Label20.Size = new System.Drawing.Size(39, 24);
            this.Label20.TabIndex = 77;
            this.Label20.Text = "N/a";
            // 
            // txtMagazineStock
            // 
            this.txtMagazineStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtMagazineStock.Location = new System.Drawing.Point(315, 105);
            this.txtMagazineStock.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtMagazineStock.MaxLength = 8;
            this.txtMagazineStock.Name = "txtMagazineStock";
            this.txtMagazineStock.Size = new System.Drawing.Size(68, 29);
            this.txtMagazineStock.TabIndex = 79;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label18.Location = new System.Drawing.Point(163, 108);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(143, 24);
            this.label18.TabIndex = 78;
            this.label18.Text = "Magazine Stock";
            // 
            // cbBirthdayDay
            // 
            this.cbBirthdayDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbBirthdayDay.FormattingEnabled = true;
            this.cbBirthdayDay.Location = new System.Drawing.Point(141, 469);
            this.cbBirthdayDay.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbBirthdayDay.Name = "cbBirthdayDay";
            this.cbBirthdayDay.Size = new System.Drawing.Size(73, 32);
            this.cbBirthdayDay.TabIndex = 80;
            this.cbBirthdayDay.Validating += new System.ComponentModel.CancelEventHandler(this.cbBirthdayDay_Validating);
            // 
            // cbBirthdayMonth
            // 
            this.cbBirthdayMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbBirthdayMonth.FormattingEnabled = true;
            this.cbBirthdayMonth.Location = new System.Drawing.Point(222, 469);
            this.cbBirthdayMonth.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbBirthdayMonth.Name = "cbBirthdayMonth";
            this.cbBirthdayMonth.Size = new System.Drawing.Size(162, 32);
            this.cbBirthdayMonth.TabIndex = 81;
            this.cbBirthdayMonth.Validating += new System.ComponentModel.CancelEventHandler(this.cbBirthdayMonth_Validating);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // chkWarnOfAddressChange
            // 
            this.chkWarnOfAddressChange.AutoSize = true;
            this.chkWarnOfAddressChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkWarnOfAddressChange.Location = new System.Drawing.Point(151, 390);
            this.chkWarnOfAddressChange.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkWarnOfAddressChange.Name = "chkWarnOfAddressChange";
            this.chkWarnOfAddressChange.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkWarnOfAddressChange.Size = new System.Drawing.Size(207, 28);
            this.chkWarnOfAddressChange.TabIndex = 82;
            this.chkWarnOfAddressChange.Text = "Warn of new address";
            this.chkWarnOfAddressChange.UseVisualStyleBackColor = true;
            // 
            // chkOnlineOnly
            // 
            this.chkOnlineOnly.AutoSize = true;
            this.chkOnlineOnly.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkOnlineOnly.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkOnlineOnly.Location = new System.Drawing.Point(479, 53);
            this.chkOnlineOnly.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkOnlineOnly.Name = "chkOnlineOnly";
            this.chkOnlineOnly.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkOnlineOnly.Size = new System.Drawing.Size(125, 28);
            this.chkOnlineOnly.TabIndex = 83;
            this.chkOnlineOnly.Text = "Online only";
            this.chkOnlineOnly.UseVisualStyleBackColor = true;
            this.chkOnlineOnly.CheckedChanged += new System.EventHandler(this.chkOnlineOnly_CheckedChanged);
            // 
            // stockGroup
            // 
            this.stockGroup.Controls.Add(this.chkMemStickPlayer);
            this.stockGroup.Controls.Add(this.chkMagazine);
            this.stockGroup.Controls.Add(this.Label15);
            this.stockGroup.Controls.Add(this.txtStock);
            this.stockGroup.Controls.Add(this.label18);
            this.stockGroup.Controls.Add(this.txtMagazineStock);
            this.stockGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.stockGroup.Location = new System.Drawing.Point(470, 84);
            this.stockGroup.Name = "stockGroup";
            this.stockGroup.Size = new System.Drawing.Size(392, 145);
            this.stockGroup.TabIndex = 84;
            this.stockGroup.TabStop = false;
            // 
            // FormEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(1350, 646);
            this.Controls.Add(this.stockGroup);
            this.Controls.Add(this.chkOnlineOnly);
            this.Controls.Add(this.chkWarnOfAddressChange);
            this.Controls.Add(this.cbBirthdayMonth);
            this.Controls.Add(this.cbBirthdayDay);
            this.Controls.Add(this.DateLastOut);
            this.Controls.Add(this.DateLastIn);
            this.Controls.Add(this.Label17);
            this.Controls.Add(this.Label16);
            this.Controls.Add(this.dtpJoined);
            this.Controls.Add(this.Label14);
            this.Controls.Add(this.lblWallet);
            this.Controls.Add(this.Label13);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.chkNoBirthday);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.lstInOut);
            this.Controls.Add(this.lblExtraContent);
            this.Controls.Add(this.lblExtra);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.Label11);
            this.Controls.Add(this.btnFinished);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.txtInformation);
            this.Controls.Add(this.Label12);
            this.Controls.Add(this.Label10);
            this.Controls.Add(this.txtTelephone);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.txtPostcode);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.txtCounty);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.txtTown);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.txtAddr2);
            this.Controls.Add(this.txtAddr1);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.txtForename);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.txtSurname);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.comboTitle);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Label20);
            this.Controls.Add(this.Label19);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "FormEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.stockGroup.ResumeLayout(false);
            this.stockGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		internal System.Windows.Forms.TextBox txtInformation;
		internal System.Windows.Forms.Label Label12;
		internal System.Windows.Forms.CheckBox chkMagazine;
		internal System.Windows.Forms.CheckBox chkMemStickPlayer;
		internal System.Windows.Forms.Label Label10;
		internal System.Windows.Forms.TextBox txtTelephone;
		internal System.Windows.Forms.Label Label9;
        private System.Windows.Forms.TextBox txtPostcode;
		internal System.Windows.Forms.Label Label8;
        private System.Windows.Forms.TextBox txtCounty;
		internal System.Windows.Forms.Label Label7;
        private System.Windows.Forms.TextBox txtTown;
		internal System.Windows.Forms.Label Label6;
        private System.Windows.Forms.TextBox txtAddr2;
        private System.Windows.Forms.TextBox txtAddr1;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.TextBox txtForename;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.TextBox txtSurname;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.ComboBox comboTitle;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Button btnFinished;
        private System.Windows.Forms.Button btnCancel;
		internal System.Windows.Forms.Label Label11;
		internal System.Windows.Forms.Label lblStatus;
		internal System.Windows.Forms.Label lblExtra;
		internal System.Windows.Forms.Label lblExtraContent;
		internal System.Windows.Forms.ListView lstInOut;
		internal System.Windows.Forms.ColumnHeader ColumnHeader1;
		internal System.Windows.Forms.ColumnHeader ColumnHeader2;
		internal System.Windows.Forms.ColumnHeader ColumnHeader3;
		internal System.Windows.Forms.ColumnHeader ColumnHeader4;
		internal System.Windows.Forms.ColumnHeader ColumnHeader5;
		internal System.Windows.Forms.ColumnHeader ColumnHeader6;
		internal System.Windows.Forms.ColumnHeader ColumnHeader7;
		internal System.Windows.Forms.ColumnHeader ColumnHeader8;
		internal System.Windows.Forms.ColumnHeader ColumnHeader9;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.CheckBox chkNoBirthday;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnLast;
		internal System.Windows.Forms.Label Label13;
		internal System.Windows.Forms.Label lblWallet;
		internal System.Windows.Forms.Label Label14;
		internal System.Windows.Forms.DateTimePicker dtpJoined;
		internal System.Windows.Forms.Label Label15;
		internal System.Windows.Forms.TextBox txtStock;
		internal System.Windows.Forms.Label Label16;
		internal System.Windows.Forms.Label Label17;
		internal System.Windows.Forms.DateTimePicker DateLastIn;
        internal System.Windows.Forms.DateTimePicker DateLastOut;
		internal System.Windows.Forms.Label Label19;
		internal System.Windows.Forms.Label Label20;
        internal TextBox txtMagazineStock;
        internal Label label18;
        private ComboBox cbBirthdayDay;
        private ComboBox cbBirthdayMonth;
        private ErrorProvider errorProvider;
        internal CheckBox chkWarnOfAddressChange;
        private ToolTip toolTip;
        internal CheckBox chkOnlineOnly;
        private GroupBox stockGroup;
    }
}
