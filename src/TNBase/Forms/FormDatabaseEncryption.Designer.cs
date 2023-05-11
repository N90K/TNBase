namespace TNBase.Forms
{
    partial class FormDatabaseEncryption
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDatabaseEncryption));
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblState = new System.Windows.Forms.Label();
            this.btnSetEncryption = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.Location = new System.Drawing.Point(1144, 765);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(378, 118);
            this.btnCancel.TabIndex = 33;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Font = new System.Drawing.Font("Segoe UI", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblState.Location = new System.Drawing.Point(69, 67);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(121, 59);
            this.lblState.TabIndex = 35;
            this.lblState.Text = "State";
            // 
            // btnSetEncryption
            // 
            this.btnSetEncryption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSetEncryption.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSetEncryption.Location = new System.Drawing.Point(471, 523);
            this.btnSetEncryption.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnSetEncryption.Name = "btnSetEncryption";
            this.btnSetEncryption.Size = new System.Drawing.Size(663, 117);
            this.btnSetEncryption.TabIndex = 36;
            this.btnSetEncryption.Text = "Set Encryption";
            this.btnSetEncryption.UseVisualStyleBackColor = false;
            this.btnSetEncryption.Click += new System.EventHandler(this.btnSetEncryption_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(69, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1470, 269);
            this.label1.TabIndex = 37;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // FormDatabaseEncryption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1580, 916);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSetEncryption);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDatabaseEncryption";
            this.Text = "Database Encryption";
            this.Load += new System.EventHandler(this.FormDatabaseEncryption_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Button btnSetEncryption;
        private System.Windows.Forms.Label label1;
    }
}