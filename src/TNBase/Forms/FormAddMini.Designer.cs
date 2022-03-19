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
	partial class FormAddMini : System.Windows.Forms.Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddMini));
            this.Label1 = new System.Windows.Forms.Label();
            this.comboTitle = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.txtForename = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.btnFinished = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(23, 20);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(309, 33);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Title: (e.g. Mr/Mrs etc).";
            // 
            // comboTitle
            // 
            this.comboTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboTitle.FormattingEnabled = true;
            this.errorProvider.SetIconAlignment(this.comboTitle, System.Windows.Forms.ErrorIconAlignment.BottomLeft);
            this.comboTitle.Location = new System.Drawing.Point(29, 60);
            this.comboTitle.Name = "comboTitle";
            this.comboTitle.Size = new System.Drawing.Size(413, 41);
            this.comboTitle.TabIndex = 1;
            this.comboTitle.Validating += new System.ComponentModel.CancelEventHandler(this.comboTitle_Validating);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(27, 123);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(133, 33);
            this.Label2.TabIndex = 2;
            this.Label2.Text = "Surname";
            // 
            // txtSurname
            // 
            this.txtSurname.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorProvider.SetIconAlignment(this.txtSurname, System.Windows.Forms.ErrorIconAlignment.BottomLeft);
            this.txtSurname.Location = new System.Drawing.Point(33, 159);
            this.txtSurname.MaxLength = 50;
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(409, 40);
            this.txtSurname.TabIndex = 2;
            this.txtSurname.Validating += new System.ComponentModel.CancelEventHandler(this.txtSurname_Validating);
            // 
            // txtForename
            // 
            this.txtForename.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorProvider.SetIconAlignment(this.txtForename, System.Windows.Forms.ErrorIconAlignment.BottomLeft);
            this.txtForename.Location = new System.Drawing.Point(33, 271);
            this.txtForename.MaxLength = 50;
            this.txtForename.Name = "txtForename";
            this.txtForename.Size = new System.Drawing.Size(409, 40);
            this.txtForename.TabIndex = 3;
            this.txtForename.Validating += new System.ComponentModel.CancelEventHandler(this.txtForename_Validating);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(27, 235);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(148, 33);
            this.Label3.TabIndex = 3;
            this.Label3.Text = "Forename";
            // 
            // btnFinished
            // 
            this.btnFinished.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnFinished.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnFinished.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinished.Location = new System.Drawing.Point(127, 354);
            this.btnFinished.Name = "btnFinished";
            this.btnFinished.Size = new System.Drawing.Size(223, 67);
            this.btnFinished.TabIndex = 4;
            this.btnFinished.Text = "Continue";
            this.btnFinished.UseVisualStyleBackColor = false;
            this.btnFinished.Click += new System.EventHandler(this.btnFinished_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // FormAddMini
            // 
            this.AcceptButton = this.btnFinished;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(482, 451);
            this.Controls.Add(this.btnFinished);
            this.Controls.Add(this.txtForename);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.txtSurname);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.comboTitle);
            this.Controls.Add(this.Label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddMini";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAddMini_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.ComboBox comboTitle;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.TextBox txtSurname;
		internal System.Windows.Forms.TextBox txtForename;
		internal System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Button btnFinished;
		public FormAddMini()
		{
			Load += formAddMini_Load;
			InitializeComponent();
		}

        private ErrorProvider errorProvider;
    }
}
