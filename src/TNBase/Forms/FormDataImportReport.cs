using Microsoft.Extensions.DependencyInjection;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TNBase.External.DataImport;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TNBase.Forms
{
    public partial class FormDataImportReport : Form
    {
        private ImportResult result;

        public FormDataImportReport(ImportResult result)
        {
            InitializeComponent();
            this.result = result;
        }

        private void FormDataImportReport_Load(object sender, System.EventArgs e)
        {
            var succededCount = result.Records.Count(x => !x.HasError);
            var failedCount = result.Records.Count(x => x.HasError);

            if (succededCount == 0)
            {
                ImportStatusLabel.Text = "Import has failed";
                ImportStatusLabel.ForeColor = Color.IndianRed;
            }
            else if (failedCount > 0)
            {
                ImportStatusLabel.Text = "Import completed with errors";
                ImportStatusLabel.ForeColor = Color.Chocolate;
            }
            else
            {
                ImportStatusLabel.Text = "Import completed successfully";
                ImportStatusLabel.ForeColor = Color.Green;
            }

            ImportedCountLabel.Text = succededCount.ToString();
            FailedCountLabel.Text = failedCount.ToString();
            TotalCountLabel.Text = result.Records.Count().ToString();

            GetFailedRecordsButton.Enabled = failedCount > 0;

            foreach (var record in result.Records.Where(x => x.HasError).ToList())
            {
                var item = new ListViewItem(new[] { record.Row.ToString(), record.Error.ErrorMessage });
                ErrorListView.Items.Add(item);
            }
        }

        private void GetFailedRecordsButton_Click(object sender, System.EventArgs e)
        {
            var dialog = new SaveFileDialog
            {
                Filter = "CSV Text|*.csv",
                Title = "Save Failed Listeners Records",
                FileName = "Failed Listeners Records.csv"
            };

            dialog.ShowDialog();

            if (!string.IsNullOrWhiteSpace(dialog.FileName))
            {
                var builder = new StringBuilder();
                builder.AppendLine(result.RawHeader);

                foreach (var record in result.Records.Where(x => x.HasError).ToList())
                {
                    builder.Append(record.Error.RawRecord);
                }

                File.WriteAllText(dialog.FileName, builder.ToString(), Encoding.UTF8);
            }
        }
    }
}
