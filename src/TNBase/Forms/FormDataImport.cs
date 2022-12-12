using Microsoft.Extensions.DependencyInjection;
using NLog;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using TNBase.External.DataImport;

namespace TNBase.Forms
{
    public partial class FormDataImport : Form
    {
        private readonly Logger log = LogManager.GetCurrentClassLogger();

        public FormDataImport()
        {
            InitializeComponent();
        }

        private void ImportListenersButton_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "CSV Text|*.csv",
                Title = "Select File to Import Listeners",
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    log.Info($"Importing listeners from {dialog.FileName}");
                    var content = File.ReadAllText(dialog.FileName, Encoding.UTF8);
                    var importService = Program.ServiceProvider.GetService<CsvImportService>();

                    var result = importService.ImportListeners(content);
                    log.Info("Import listeners complete. Showing result.");
                    var reportForm = new FormDataImportReport(result);
                    reportForm.ShowDialog();
                    Close();
                }
                catch (Exception ex)
                {
                    log.Error(ex, $"Importing listeners failed: {ex.Message}");
                    MessageBox.Show(ex.Message, "Listener Import Error");
                }
            }

        }

        private void DownloadListenersTemplateLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var dialog = new SaveFileDialog
            {
                Filter = "CSV Text|*.csv",
                Title = "Save Listeners Import Template",
                FileName = "Listeners Import Template.csv"
            };

            dialog.ShowDialog();

            if (!string.IsNullOrWhiteSpace(dialog.FileName))
            {
                log.Info($"Saving Listeners Import Template to {dialog.FileName}");
                var resourceManager = Program.ServiceProvider.GetService<ResourceManager>();
                File.Copy(resourceManager.ListenersImportTemplatePath, dialog.FileName, true);
            }
        }
    }
}