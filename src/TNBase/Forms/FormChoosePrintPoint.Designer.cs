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
	partial class FormChoosePrintPoint : System.Windows.Forms.Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChoosePrintPoint));
            this.CheckBox1 = new System.Windows.Forms.CheckBox();
            this.CheckBox2 = new System.Windows.Forms.CheckBox();
            this.CheckBox3 = new System.Windows.Forms.CheckBox();
            this.CheckBox4 = new System.Windows.Forms.CheckBox();
            this.CheckBox5 = new System.Windows.Forms.CheckBox();
            this.CheckBox6 = new System.Windows.Forms.CheckBox();
            this.CheckBox7 = new System.Windows.Forms.CheckBox();
            this.CheckBox8 = new System.Windows.Forms.CheckBox();
            this.CheckBox9 = new System.Windows.Forms.CheckBox();
            this.CheckBox10 = new System.Windows.Forms.CheckBox();
            this.CheckBox11 = new System.Windows.Forms.CheckBox();
            this.CheckBox12 = new System.Windows.Forms.CheckBox();
            this.CheckBox13 = new System.Windows.Forms.CheckBox();
            this.CheckBox14 = new System.Windows.Forms.CheckBox();
            this.CheckBox15 = new System.Windows.Forms.CheckBox();
            this.CheckBox16 = new System.Windows.Forms.CheckBox();
            this.CheckBox17 = new System.Windows.Forms.CheckBox();
            this.CheckBox18 = new System.Windows.Forms.CheckBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Button1 = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cmbSelection = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CheckBox1
            // 
            this.CheckBox1.AutoSize = true;
            this.CheckBox1.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox1.Checked = true;
            this.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBox1.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.CheckBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CheckBox1.Location = new System.Drawing.Point(280, 172);
            this.CheckBox1.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.CheckBox1.Name = "CheckBox1";
            this.CheckBox1.Size = new System.Drawing.Size(28, 27);
            this.CheckBox1.TabIndex = 0;
            this.CheckBox1.UseVisualStyleBackColor = false;
            this.CheckBox1.Click += new System.EventHandler(this.CheckBox1_Click);
            // 
            // CheckBox2
            // 
            this.CheckBox2.AutoSize = true;
            this.CheckBox2.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox2.Checked = true;
            this.CheckBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBox2.Enabled = false;
            this.CheckBox2.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.CheckBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CheckBox2.Location = new System.Drawing.Point(344, 170);
            this.CheckBox2.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.CheckBox2.Name = "CheckBox2";
            this.CheckBox2.Size = new System.Drawing.Size(28, 27);
            this.CheckBox2.TabIndex = 1;
            this.CheckBox2.UseVisualStyleBackColor = false;
            // 
            // CheckBox3
            // 
            this.CheckBox3.AutoSize = true;
            this.CheckBox3.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox3.Checked = true;
            this.CheckBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBox3.Enabled = false;
            this.CheckBox3.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.CheckBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CheckBox3.Location = new System.Drawing.Point(412, 170);
            this.CheckBox3.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.CheckBox3.Name = "CheckBox3";
            this.CheckBox3.Size = new System.Drawing.Size(28, 27);
            this.CheckBox3.TabIndex = 2;
            this.CheckBox3.UseVisualStyleBackColor = false;
            // 
            // CheckBox4
            // 
            this.CheckBox4.AutoSize = true;
            this.CheckBox4.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox4.Enabled = false;
            this.CheckBox4.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.CheckBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CheckBox4.Location = new System.Drawing.Point(412, 219);
            this.CheckBox4.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.CheckBox4.Name = "CheckBox4";
            this.CheckBox4.Size = new System.Drawing.Size(28, 27);
            this.CheckBox4.TabIndex = 5;
            this.CheckBox4.UseVisualStyleBackColor = false;
            // 
            // CheckBox5
            // 
            this.CheckBox5.AutoSize = true;
            this.CheckBox5.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox5.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.CheckBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CheckBox5.Location = new System.Drawing.Point(344, 219);
            this.CheckBox5.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.CheckBox5.Name = "CheckBox5";
            this.CheckBox5.Size = new System.Drawing.Size(28, 27);
            this.CheckBox5.TabIndex = 4;
            this.CheckBox5.UseVisualStyleBackColor = false;
            this.CheckBox5.Click += new System.EventHandler(this.CheckBox5_Click);
            // 
            // CheckBox6
            // 
            this.CheckBox6.AutoSize = true;
            this.CheckBox6.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox6.Checked = true;
            this.CheckBox6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBox6.Enabled = false;
            this.CheckBox6.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.CheckBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CheckBox6.Location = new System.Drawing.Point(280, 219);
            this.CheckBox6.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.CheckBox6.Name = "CheckBox6";
            this.CheckBox6.Size = new System.Drawing.Size(28, 27);
            this.CheckBox6.TabIndex = 3;
            this.CheckBox6.UseVisualStyleBackColor = false;
            // 
            // CheckBox7
            // 
            this.CheckBox7.AutoSize = true;
            this.CheckBox7.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox7.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.CheckBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CheckBox7.Location = new System.Drawing.Point(412, 268);
            this.CheckBox7.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.CheckBox7.Name = "CheckBox7";
            this.CheckBox7.Size = new System.Drawing.Size(28, 27);
            this.CheckBox7.TabIndex = 8;
            this.CheckBox7.UseVisualStyleBackColor = false;
            this.CheckBox7.Click += new System.EventHandler(this.CheckBox7_Click);
            // 
            // CheckBox8
            // 
            this.CheckBox8.AutoSize = true;
            this.CheckBox8.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox8.Enabled = false;
            this.CheckBox8.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.CheckBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CheckBox8.Location = new System.Drawing.Point(344, 268);
            this.CheckBox8.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.CheckBox8.Name = "CheckBox8";
            this.CheckBox8.Size = new System.Drawing.Size(28, 27);
            this.CheckBox8.TabIndex = 7;
            this.CheckBox8.UseVisualStyleBackColor = false;
            // 
            // CheckBox9
            // 
            this.CheckBox9.AutoSize = true;
            this.CheckBox9.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox9.Enabled = false;
            this.CheckBox9.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.CheckBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CheckBox9.Location = new System.Drawing.Point(280, 268);
            this.CheckBox9.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.CheckBox9.Name = "CheckBox9";
            this.CheckBox9.Size = new System.Drawing.Size(28, 27);
            this.CheckBox9.TabIndex = 6;
            this.CheckBox9.UseVisualStyleBackColor = false;
            // 
            // CheckBox10
            // 
            this.CheckBox10.AutoSize = true;
            this.CheckBox10.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox10.Enabled = false;
            this.CheckBox10.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.CheckBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CheckBox10.Location = new System.Drawing.Point(412, 318);
            this.CheckBox10.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.CheckBox10.Name = "CheckBox10";
            this.CheckBox10.Size = new System.Drawing.Size(28, 27);
            this.CheckBox10.TabIndex = 11;
            this.CheckBox10.UseVisualStyleBackColor = false;
            // 
            // CheckBox11
            // 
            this.CheckBox11.AutoSize = true;
            this.CheckBox11.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox11.Enabled = false;
            this.CheckBox11.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.CheckBox11.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CheckBox11.Location = new System.Drawing.Point(344, 318);
            this.CheckBox11.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.CheckBox11.Name = "CheckBox11";
            this.CheckBox11.Size = new System.Drawing.Size(28, 27);
            this.CheckBox11.TabIndex = 10;
            this.CheckBox11.UseVisualStyleBackColor = false;
            // 
            // CheckBox12
            // 
            this.CheckBox12.AutoSize = true;
            this.CheckBox12.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox12.Enabled = false;
            this.CheckBox12.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.CheckBox12.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CheckBox12.Location = new System.Drawing.Point(280, 318);
            this.CheckBox12.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.CheckBox12.Name = "CheckBox12";
            this.CheckBox12.Size = new System.Drawing.Size(28, 27);
            this.CheckBox12.TabIndex = 9;
            this.CheckBox12.UseVisualStyleBackColor = false;
            // 
            // CheckBox13
            // 
            this.CheckBox13.AutoSize = true;
            this.CheckBox13.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox13.Enabled = false;
            this.CheckBox13.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.CheckBox13.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CheckBox13.Location = new System.Drawing.Point(412, 367);
            this.CheckBox13.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.CheckBox13.Name = "CheckBox13";
            this.CheckBox13.Size = new System.Drawing.Size(28, 27);
            this.CheckBox13.TabIndex = 14;
            this.CheckBox13.UseVisualStyleBackColor = false;
            // 
            // CheckBox14
            // 
            this.CheckBox14.AutoSize = true;
            this.CheckBox14.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox14.Enabled = false;
            this.CheckBox14.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.CheckBox14.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CheckBox14.Location = new System.Drawing.Point(344, 367);
            this.CheckBox14.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.CheckBox14.Name = "CheckBox14";
            this.CheckBox14.Size = new System.Drawing.Size(28, 27);
            this.CheckBox14.TabIndex = 13;
            this.CheckBox14.UseVisualStyleBackColor = false;
            // 
            // CheckBox15
            // 
            this.CheckBox15.AutoSize = true;
            this.CheckBox15.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox15.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.CheckBox15.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CheckBox15.Location = new System.Drawing.Point(280, 367);
            this.CheckBox15.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.CheckBox15.Name = "CheckBox15";
            this.CheckBox15.Size = new System.Drawing.Size(28, 27);
            this.CheckBox15.TabIndex = 12;
            this.CheckBox15.UseVisualStyleBackColor = false;
            this.CheckBox15.Click += new System.EventHandler(this.CheckBox15_Click);
            // 
            // CheckBox16
            // 
            this.CheckBox16.AutoSize = true;
            this.CheckBox16.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox16.Enabled = false;
            this.CheckBox16.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.CheckBox16.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CheckBox16.Location = new System.Drawing.Point(412, 416);
            this.CheckBox16.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.CheckBox16.Name = "CheckBox16";
            this.CheckBox16.Size = new System.Drawing.Size(28, 27);
            this.CheckBox16.TabIndex = 17;
            this.CheckBox16.UseVisualStyleBackColor = false;
            // 
            // CheckBox17
            // 
            this.CheckBox17.AutoSize = true;
            this.CheckBox17.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox17.Enabled = false;
            this.CheckBox17.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.CheckBox17.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CheckBox17.Location = new System.Drawing.Point(344, 416);
            this.CheckBox17.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.CheckBox17.Name = "CheckBox17";
            this.CheckBox17.Size = new System.Drawing.Size(28, 27);
            this.CheckBox17.TabIndex = 16;
            this.CheckBox17.UseVisualStyleBackColor = false;
            // 
            // CheckBox18
            // 
            this.CheckBox18.AutoSize = true;
            this.CheckBox18.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox18.Enabled = false;
            this.CheckBox18.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.CheckBox18.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CheckBox18.Location = new System.Drawing.Point(280, 416);
            this.CheckBox18.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.CheckBox18.Name = "CheckBox18";
            this.CheckBox18.Size = new System.Drawing.Size(28, 27);
            this.CheckBox18.TabIndex = 15;
            this.CheckBox18.UseVisualStyleBackColor = false;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Label1.Location = new System.Drawing.Point(48, 44);
            this.Label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(651, 67);
            this.Label1.TabIndex = 18;
            this.Label1.Text = "Choose a starting point..";
            // 
            // Button1
            // 
            this.Button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Button1.Location = new System.Drawing.Point(821, 529);
            this.Button1.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(297, 170);
            this.Button1.TabIndex = 19;
            this.Button1.Text = "Print";
            this.Button1.UseVisualStyleBackColor = false;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.Location = new System.Drawing.Point(184, 529);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(297, 170);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cmbSelection
            // 
            this.cmbSelection.BackColor = System.Drawing.Color.White;
            this.cmbSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbSelection.FormattingEnabled = true;
            this.cmbSelection.Items.AddRange(new object[] {
            "1 - 4",
            "5 - 8",
            "9 - 12",
            "13 - 16"});
            this.cmbSelection.Location = new System.Drawing.Point(654, 286);
            this.cmbSelection.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.cmbSelection.Name = "cmbSelection";
            this.cmbSelection.Size = new System.Drawing.Size(459, 75);
            this.cmbSelection.TabIndex = 21;
            this.cmbSelection.SelectedIndexChanged += new System.EventHandler(this.cmbSelection_SelectedIndexChanged);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Label2.Location = new System.Drawing.Point(641, 197);
            this.Label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(283, 67);
            this.Label2.TabIndex = 22;
            this.Label2.Text = "Selection:";
            // 
            // FormChoosePrintPoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 763);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.cmbSelection);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.CheckBox16);
            this.Controls.Add(this.CheckBox17);
            this.Controls.Add(this.CheckBox18);
            this.Controls.Add(this.CheckBox13);
            this.Controls.Add(this.CheckBox14);
            this.Controls.Add(this.CheckBox15);
            this.Controls.Add(this.CheckBox10);
            this.Controls.Add(this.CheckBox11);
            this.Controls.Add(this.CheckBox12);
            this.Controls.Add(this.CheckBox7);
            this.Controls.Add(this.CheckBox8);
            this.Controls.Add(this.CheckBox9);
            this.Controls.Add(this.CheckBox4);
            this.Controls.Add(this.CheckBox5);
            this.Controls.Add(this.CheckBox6);
            this.Controls.Add(this.CheckBox3);
            this.Controls.Add(this.CheckBox2);
            this.Controls.Add(this.CheckBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormChoosePrintPoint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormChoosePrintPoint_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
        private System.Windows.Forms.CheckBox CheckBox1;
		internal System.Windows.Forms.CheckBox CheckBox2;
		internal System.Windows.Forms.CheckBox CheckBox3;
		internal System.Windows.Forms.CheckBox CheckBox4;
        private System.Windows.Forms.CheckBox CheckBox5;
		internal System.Windows.Forms.CheckBox CheckBox6;
        private System.Windows.Forms.CheckBox CheckBox7;
		internal System.Windows.Forms.CheckBox CheckBox8;
		internal System.Windows.Forms.CheckBox CheckBox9;
		internal System.Windows.Forms.CheckBox CheckBox10;
		internal System.Windows.Forms.CheckBox CheckBox11;
		internal System.Windows.Forms.CheckBox CheckBox12;
		internal System.Windows.Forms.CheckBox CheckBox13;
		internal System.Windows.Forms.CheckBox CheckBox14;
        private System.Windows.Forms.CheckBox CheckBox15;
		internal System.Windows.Forms.CheckBox CheckBox16;
		internal System.Windows.Forms.CheckBox CheckBox17;
		internal System.Windows.Forms.CheckBox CheckBox18;
		internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Button Button1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cmbSelection;
		internal System.Windows.Forms.Label Label2;
	}
}
