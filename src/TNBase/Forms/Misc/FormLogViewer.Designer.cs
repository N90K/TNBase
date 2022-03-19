namespace TNBase
{
    partial class FormLogViewer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogViewer));
            this.logUpdater = new System.Windows.Forms.Timer(this.components);
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LogFileLocationLink = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // logUpdater
            // 
            this.logUpdater.Enabled = true;
            this.logUpdater.Interval = 500;
            this.logUpdater.Tick += new System.EventHandler(this.logUpdater_Tick);
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(14, 14);
            this.txtLog.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtLog.Size = new System.Drawing.Size(806, 497);
            this.txtLog.TabIndex = 1;
            this.txtLog.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 527);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Log file location:";
            // 
            // LogFileLocationLink
            // 
            this.LogFileLocationLink.AutoSize = true;
            this.LogFileLocationLink.Location = new System.Drawing.Point(115, 527);
            this.LogFileLocationLink.Name = "LogFileLocationLink";
            this.LogFileLocationLink.Size = new System.Drawing.Size(60, 15);
            this.LogFileLocationLink.TabIndex = 3;
            this.LogFileLocationLink.TabStop = true;
            this.LogFileLocationLink.Text = "linkLabel1";
            this.LogFileLocationLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LogFileLocationLink_LinkClicked);
            // 
            // FormLogViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 551);
            this.Controls.Add(this.LogFileLocationLink);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLog);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLogViewer";
            this.Text = "formLogViewer";
            this.Load += new System.EventHandler(this.formLogViewer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer logUpdater;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel LogFileLocationLink;
    }
}