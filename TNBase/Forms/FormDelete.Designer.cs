namespace TNBase.Forms
{
    partial class FormDelete
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDelete));
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.listenerDetailsLabel = new System.Windows.Forms.Label();
            this.memStickQuestionLabel = new System.Windows.Forms.Label();
            this.yesMemStickRadioButton = new System.Windows.Forms.RadioButton();
            this.noMemStickRadioButton = new System.Windows.Forms.RadioButton();
            this.memStickGroupBox = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.newsSentLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.magazinesSentLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxReason = new System.Windows.Forms.TextBox();
            this.memStickGroupBox.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnDelete.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnDelete.Enabled = false;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(222, 342);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(327, 58);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Mark for deletion";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(555, 342);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(128, 58);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // listenerDetailsLabel
            // 
            this.listenerDetailsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listenerDetailsLabel.Location = new System.Drawing.Point(30, 52);
            this.listenerDetailsLabel.Name = "listenerDetailsLabel";
            this.listenerDetailsLabel.Size = new System.Drawing.Size(388, 114);
            this.listenerDetailsLabel.TabIndex = 36;
            this.listenerDetailsLabel.Text = "Listener Details";
            // 
            // memStickQuestionLabel
            // 
            this.memStickQuestionLabel.AutoSize = true;
            this.memStickQuestionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memStickQuestionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.memStickQuestionLabel.Location = new System.Drawing.Point(6, 16);
            this.memStickQuestionLabel.Name = "memStickQuestionLabel";
            this.memStickQuestionLabel.Size = new System.Drawing.Size(400, 24);
            this.memStickQuestionLabel.TabIndex = 37;
            this.memStickQuestionLabel.Text = "Did the listener return the memory stick player?";
            // 
            // yesMemStickRadioButton
            // 
            this.yesMemStickRadioButton.AutoSize = true;
            this.yesMemStickRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yesMemStickRadioButton.Location = new System.Drawing.Point(537, 14);
            this.yesMemStickRadioButton.Name = "yesMemStickRadioButton";
            this.yesMemStickRadioButton.Size = new System.Drawing.Size(60, 28);
            this.yesMemStickRadioButton.TabIndex = 1;
            this.yesMemStickRadioButton.TabStop = true;
            this.yesMemStickRadioButton.Text = "Yes";
            this.yesMemStickRadioButton.UseVisualStyleBackColor = true;
            this.yesMemStickRadioButton.CheckedChanged += new System.EventHandler(this.memStickRadioButton_CheckedChanged);
            // 
            // noMemStickRadioButton
            // 
            this.noMemStickRadioButton.AutoSize = true;
            this.noMemStickRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noMemStickRadioButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.noMemStickRadioButton.Location = new System.Drawing.Point(612, 14);
            this.noMemStickRadioButton.Name = "noMemStickRadioButton";
            this.noMemStickRadioButton.Size = new System.Drawing.Size(53, 28);
            this.noMemStickRadioButton.TabIndex = 2;
            this.noMemStickRadioButton.TabStop = true;
            this.noMemStickRadioButton.Text = "No";
            this.noMemStickRadioButton.UseVisualStyleBackColor = true;
            this.noMemStickRadioButton.CheckedChanged += new System.EventHandler(this.memStickRadioButton_CheckedChanged);
            // 
            // memStickGroupBox
            // 
            this.memStickGroupBox.Controls.Add(this.memStickQuestionLabel);
            this.memStickGroupBox.Controls.Add(this.noMemStickRadioButton);
            this.memStickGroupBox.Controls.Add(this.yesMemStickRadioButton);
            this.memStickGroupBox.Location = new System.Drawing.Point(12, 194);
            this.memStickGroupBox.Name = "memStickGroupBox";
            this.memStickGroupBox.Size = new System.Drawing.Size(671, 51);
            this.memStickGroupBox.TabIndex = 41;
            this.memStickGroupBox.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 413);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(695, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 43;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(112, 17);
            this.toolStripStatusLabel.Text = "toolStripStatusLabel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(445, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 24);
            this.label2.TabIndex = 44;
            this.label2.Text = "News wallets sent:";
            // 
            // newsSentLabel
            // 
            this.newsSentLabel.AutoSize = true;
            this.newsSentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newsSentLabel.ForeColor = System.Drawing.Color.DimGray;
            this.newsSentLabel.Location = new System.Drawing.Point(663, 78);
            this.newsSentLabel.Name = "newsSentLabel";
            this.newsSentLabel.Size = new System.Drawing.Size(20, 24);
            this.newsSentLabel.TabIndex = 45;
            this.newsSentLabel.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(445, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 24);
            this.label3.TabIndex = 46;
            this.label3.Text = "Magazine wallets sent:";
            // 
            // magazinesSentLabel
            // 
            this.magazinesSentLabel.AutoSize = true;
            this.magazinesSentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.magazinesSentLabel.ForeColor = System.Drawing.Color.DimGray;
            this.magazinesSentLabel.Location = new System.Drawing.Point(663, 112);
            this.magazinesSentLabel.Name = "magazinesSentLabel";
            this.magazinesSentLabel.Size = new System.Drawing.Size(20, 24);
            this.magazinesSentLabel.TabIndex = 47;
            this.magazinesSentLabel.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(529, 25);
            this.label1.TabIndex = 35;
            this.label1.Text = "Are you sure you want to delete the following listener?";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(218, 262);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 24);
            this.label4.TabIndex = 48;
            this.label4.Text = "Reason";
            // 
            // tbxReason
            // 
            this.tbxReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxReason.Location = new System.Drawing.Point(299, 262);
            this.tbxReason.Multiline = true;
            this.tbxReason.Name = "tbxReason";
            this.tbxReason.Size = new System.Drawing.Size(384, 52);
            this.tbxReason.TabIndex = 49;
            // 
            // FormDelete
            // 
            this.AcceptButton = this.btnDelete;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(695, 435);
            this.Controls.Add(this.tbxReason);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.magazinesSentLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.newsSentLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.memStickGroupBox);
            this.Controls.Add(this.listenerDetailsLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDelete";
            this.Text = "Delete Listener";
            this.memStickGroupBox.ResumeLayout(false);
            this.memStickGroupBox.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label listenerDetailsLabel;
        private System.Windows.Forms.Label memStickQuestionLabel;
        private System.Windows.Forms.RadioButton yesMemStickRadioButton;
        private System.Windows.Forms.RadioButton noMemStickRadioButton;
        private System.Windows.Forms.GroupBox memStickGroupBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label newsSentLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label magazinesSentLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxReason;
    }
}