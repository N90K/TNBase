namespace TNBase.Forms
{
    partial class FormDataImport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDataImport));
            this.ImportListenersButton = new System.Windows.Forms.Button();
            this.DownloadListenersTemplateLink = new System.Windows.Forms.LinkLabel();
            this.helpProvider = new System.Windows.Forms.HelpProvider();
            this.SuspendLayout();
            // 
            // ImportListenersButton
            // 
            this.ImportListenersButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.helpProvider.SetHelpKeyword(this.ImportListenersButton, "7");
            this.helpProvider.SetHelpNavigator(this.ImportListenersButton, System.Windows.Forms.HelpNavigator.TopicId);
            this.ImportListenersButton.Location = new System.Drawing.Point(460, 50);
            this.ImportListenersButton.Name = "ImportListenersButton";
            this.helpProvider.SetShowHelp(this.ImportListenersButton, true);
            this.ImportListenersButton.Size = new System.Drawing.Size(300, 79);
            this.ImportListenersButton.TabIndex = 0;
            this.ImportListenersButton.Text = "Import Listeners";
            this.ImportListenersButton.UseVisualStyleBackColor = true;
            this.ImportListenersButton.Click += new System.EventHandler(this.ImportListenersButton_Click);
            // 
            // DownloadListenersTemplateLink
            // 
            this.DownloadListenersTemplateLink.AutoSize = true;
            this.helpProvider.SetHelpKeyword(this.DownloadListenersTemplateLink, "8");
            this.helpProvider.SetHelpNavigator(this.DownloadListenersTemplateLink, System.Windows.Forms.HelpNavigator.TopicId);
            this.DownloadListenersTemplateLink.Location = new System.Drawing.Point(44, 77);
            this.DownloadListenersTemplateLink.Name = "DownloadListenersTemplateLink";
            this.helpProvider.SetShowHelp(this.DownloadListenersTemplateLink, true);
            this.DownloadListenersTemplateLink.Size = new System.Drawing.Size(326, 32);
            this.DownloadListenersTemplateLink.TabIndex = 1;
            this.DownloadListenersTemplateLink.TabStop = true;
            this.DownloadListenersTemplateLink.Text = "Get listeners import template";
            this.DownloadListenersTemplateLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.DownloadListenersTemplateLink_LinkClicked);
            // 
            // helpProvider
            // 
            this.helpProvider.HelpNamespace = "Resource\\TNBase.chm";
            // 
            // FormDataImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 193);
            this.Controls.Add(this.DownloadListenersTemplateLink);
            this.Controls.Add(this.ImportListenersButton);
            this.HelpButton = true;
            this.helpProvider.SetHelpKeyword(this, "8");
            this.helpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDataImport";
            this.helpProvider.SetShowHelp(this, true);
            this.Text = "Data Import";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ImportListenersButton;
        private System.Windows.Forms.LinkLabel DownloadListenersTemplateLink;
        private System.Windows.Forms.HelpProvider helpProvider;
    }
}