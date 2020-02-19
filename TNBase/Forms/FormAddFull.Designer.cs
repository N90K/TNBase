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
	partial class FormAddFull : System.Windows.Forms.Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddFull));
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.comboTitle = new System.Windows.Forms.ComboBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.txtForename = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.txtAddr1 = new System.Windows.Forms.TextBox();
            this.txtAddr2 = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.txtTown = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.txtCounty = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.txtPostcode = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.Label10 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnFinished = new System.Windows.Forms.Button();
            this.chkTape = new System.Windows.Forms.CheckBox();
            this.chkMagazine = new System.Windows.Forms.CheckBox();
            this.Label12 = new System.Windows.Forms.Label();
            this.txtInformation = new System.Windows.Forms.TextBox();
            this.chkNoBirthday = new System.Windows.Forms.CheckBox();
            this.cbxBirthdayDay = new System.Windows.Forms.ComboBox();
            this.cbxBirthdayMonth = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(33, 93);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(71, 33);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Title";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(413, 9);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(309, 37);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "Add a new Listener";
            // 
            // comboTitle
            // 
            this.comboTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboTitle.FormattingEnabled = true;
            this.comboTitle.Location = new System.Drawing.Point(199, 90);
            this.comboTitle.Name = "comboTitle";
            this.comboTitle.Size = new System.Drawing.Size(208, 41);
            this.comboTitle.TabIndex = 2;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(33, 140);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(132, 33);
            this.Label3.TabIndex = 3;
            this.Label3.Text = "Forname";
            // 
            // txtSurname
            // 
            this.txtSurname.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSurname.Location = new System.Drawing.Point(199, 183);
            this.txtSurname.MaxLength = 50;
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(208, 40);
            this.txtSurname.TabIndex = 4;
            // 
            // txtForename
            // 
            this.txtForename.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtForename.Location = new System.Drawing.Point(199, 137);
            this.txtForename.MaxLength = 50;
            this.txtForename.Name = "txtForename";
            this.txtForename.Size = new System.Drawing.Size(208, 40);
            this.txtForename.TabIndex = 3;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(32, 186);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(133, 33);
            this.Label4.TabIndex = 5;
            this.Label4.Text = "Surname";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(33, 232);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(122, 33);
            this.Label5.TabIndex = 7;
            this.Label5.Text = "Address";
            // 
            // txtAddr1
            // 
            this.txtAddr1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddr1.Location = new System.Drawing.Point(199, 229);
            this.txtAddr1.MaxLength = 50;
            this.txtAddr1.Name = "txtAddr1";
            this.txtAddr1.Size = new System.Drawing.Size(303, 40);
            this.txtAddr1.TabIndex = 8;
            // 
            // txtAddr2
            // 
            this.txtAddr2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddr2.Location = new System.Drawing.Point(199, 275);
            this.txtAddr2.MaxLength = 50;
            this.txtAddr2.Name = "txtAddr2";
            this.txtAddr2.Size = new System.Drawing.Size(303, 40);
            this.txtAddr2.TabIndex = 9;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(32, 324);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(86, 33);
            this.Label6.TabIndex = 10;
            this.Label6.Text = "Town";
            // 
            // txtTown
            // 
            this.txtTown.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTown.Location = new System.Drawing.Point(199, 321);
            this.txtTown.MaxLength = 50;
            this.txtTown.Name = "txtTown";
            this.txtTown.Size = new System.Drawing.Size(303, 40);
            this.txtTown.TabIndex = 11;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.Location = new System.Drawing.Point(33, 370);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(107, 33);
            this.Label7.TabIndex = 12;
            this.Label7.Text = "County";
            // 
            // txtCounty
            // 
            this.txtCounty.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCounty.Location = new System.Drawing.Point(199, 367);
            this.txtCounty.MaxLength = 50;
            this.txtCounty.Name = "txtCounty";
            this.txtCounty.Size = new System.Drawing.Size(303, 40);
            this.txtCounty.TabIndex = 13;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.Location = new System.Drawing.Point(33, 416);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(136, 33);
            this.Label8.TabIndex = 14;
            this.Label8.Text = "Postcode";
            // 
            // txtPostcode
            // 
            this.txtPostcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPostcode.Location = new System.Drawing.Point(199, 413);
            this.txtPostcode.MaxLength = 8;
            this.txtPostcode.Name = "txtPostcode";
            this.txtPostcode.Size = new System.Drawing.Size(208, 40);
            this.txtPostcode.TabIndex = 15;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.Location = new System.Drawing.Point(32, 462);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(152, 33);
            this.Label9.TabIndex = 16;
            this.Label9.Text = "Telephone";
            // 
            // txtTelephone
            // 
            this.txtTelephone.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelephone.Location = new System.Drawing.Point(199, 459);
            this.txtTelephone.MaxLength = 11;
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(208, 40);
            this.txtTelephone.TabIndex = 17;
            this.txtTelephone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelephone_KeyPress);
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label10.Location = new System.Drawing.Point(566, 207);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(122, 33);
            this.Label10.TabIndex = 19;
            this.Label10.Text = "Birthday";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(51, 568);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(206, 60);
            this.btnCancel.TabIndex = 32;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnFinished
            // 
            this.btnFinished.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnFinished.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnFinished.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinished.Location = new System.Drawing.Point(867, 568);
            this.btnFinished.Name = "btnFinished";
            this.btnFinished.Size = new System.Drawing.Size(206, 60);
            this.btnFinished.TabIndex = 31;
            this.btnFinished.Text = "Continue";
            this.btnFinished.UseVisualStyleBackColor = false;
            this.btnFinished.Click += new System.EventHandler(this.btnFinished_Click);
            // 
            // chkTape
            // 
            this.chkTape.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkTape.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTape.Location = new System.Drawing.Point(559, 92);
            this.chkTape.Name = "chkTape";
            this.chkTape.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkTape.Size = new System.Drawing.Size(413, 37);
            this.chkTape.TabIndex = 18;
            this.chkTape.Text = "Memory Stick Player Issued?\r\n";
            this.chkTape.UseVisualStyleBackColor = true;
            // 
            // chkMagazine
            // 
            this.chkMagazine.AutoSize = true;
            this.chkMagazine.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkMagazine.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMagazine.Location = new System.Drawing.Point(559, 135);
            this.chkMagazine.Name = "chkMagazine";
            this.chkMagazine.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkMagazine.Size = new System.Drawing.Size(176, 37);
            this.chkMagazine.TabIndex = 19;
            this.chkMagazine.Text = "Magazine?";
            this.chkMagazine.UseVisualStyleBackColor = true;
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label12.Location = new System.Drawing.Point(566, 328);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(169, 33);
            this.Label12.TabIndex = 25;
            this.Label12.Text = "Information:";
            // 
            // txtInformation
            // 
            this.txtInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInformation.Location = new System.Drawing.Point(572, 367);
            this.txtInformation.MaxLength = 1000;
            this.txtInformation.Multiline = true;
            this.txtInformation.Name = "txtInformation";
            this.txtInformation.Size = new System.Drawing.Size(517, 174);
            this.txtInformation.TabIndex = 30;
            // 
            // chkNoBirthday
            // 
            this.chkNoBirthday.AutoSize = true;
            this.chkNoBirthday.BackColor = System.Drawing.Color.Transparent;
            this.chkNoBirthday.Checked = true;
            this.chkNoBirthday.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNoBirthday.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNoBirthday.Location = new System.Drawing.Point(884, 251);
            this.chkNoBirthday.Name = "chkNoBirthday";
            this.chkNoBirthday.Size = new System.Drawing.Size(205, 29);
            this.chkNoBirthday.TabIndex = 22;
            this.chkNoBirthday.Text = "Birthday Unknown";
            this.chkNoBirthday.UseVisualStyleBackColor = false;
            this.chkNoBirthday.CheckedChanged += new System.EventHandler(this.chkNoBirthday_CheckedChanged);
            // 
            // cbxBirthdayDay
            // 
            this.cbxBirthdayDay.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxBirthdayDay.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxBirthdayDay.Cursor = System.Windows.Forms.Cursors.Default;
            this.cbxBirthdayDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBirthdayDay.Enabled = false;
            this.cbxBirthdayDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxBirthdayDay.FormattingEnabled = true;
            this.cbxBirthdayDay.Location = new System.Drawing.Point(827, 204);
            this.cbxBirthdayDay.MaxDropDownItems = 10;
            this.cbxBirthdayDay.Name = "cbxBirthdayDay";
            this.cbxBirthdayDay.Size = new System.Drawing.Size(73, 41);
            this.cbxBirthdayDay.TabIndex = 20;
            // 
            // cbxBirthdayMonth
            // 
            this.cbxBirthdayMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBirthdayMonth.Enabled = false;
            this.cbxBirthdayMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxBirthdayMonth.FormattingEnabled = true;
            this.cbxBirthdayMonth.Location = new System.Drawing.Point(920, 204);
            this.cbxBirthdayMonth.Name = "cbxBirthdayMonth";
            this.cbxBirthdayMonth.Size = new System.Drawing.Size(169, 41);
            this.cbxBirthdayMonth.TabIndex = 21;
            // 
            // FormAddFull
            // 
            this.AcceptButton = this.btnFinished;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1127, 656);
            this.Controls.Add(this.cbxBirthdayMonth);
            this.Controls.Add(this.cbxBirthdayDay);
            this.Controls.Add(this.chkNoBirthday);
            this.Controls.Add(this.txtInformation);
            this.Controls.Add(this.Label12);
            this.Controls.Add(this.chkMagazine);
            this.Controls.Add(this.chkTape);
            this.Controls.Add(this.btnFinished);
            this.Controls.Add(this.btnCancel);
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
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddFull";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAddFull_FormClosing);
            this.Load += new System.EventHandler(this.FormAddFull_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.ComboBox comboTitle;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.TextBox txtSurname;
		internal System.Windows.Forms.TextBox txtForename;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.TextBox txtAddr1;
		internal System.Windows.Forms.TextBox txtAddr2;
		internal System.Windows.Forms.Label Label6;
		internal System.Windows.Forms.TextBox txtTown;
		internal System.Windows.Forms.Label Label7;
		internal System.Windows.Forms.TextBox txtCounty;
		internal System.Windows.Forms.Label Label8;
		internal System.Windows.Forms.TextBox txtPostcode;
		internal System.Windows.Forms.Label Label9;
        private System.Windows.Forms.TextBox txtTelephone;
		internal System.Windows.Forms.Label Label10;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnFinished;
		internal System.Windows.Forms.CheckBox chkTape;
		internal System.Windows.Forms.CheckBox chkMagazine;
		internal System.Windows.Forms.Label Label12;
		internal System.Windows.Forms.TextBox txtInformation;
        private System.Windows.Forms.CheckBox chkNoBirthday;
        private ComboBox cbxBirthdayDay;
        private ComboBox cbxBirthdayMonth;
    }
}
