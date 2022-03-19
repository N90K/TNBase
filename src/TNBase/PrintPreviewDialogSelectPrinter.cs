using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;

namespace TNBase
{
    public class PrintPreviewDialogSelectPrinter : PrintPreviewDialog
    {
        private Timer focusTimer;
        private System.ComponentModel.IContainer components;

        private void myPrintPreview_Shown(object sender, System.EventArgs e)
		{
			//Get the toolstrip from the base control
			ToolStrip ts = (ToolStrip)this.Controls[1];
			//Get the print button from the toolstrip
			ToolStripItem printItem = ts.Items["printToolStripButton"];

			//Add a new button 
			var _with1 = printItem;

            if (_with1 != null)
            {
                ToolStripItem myPrintItem = null;
                myPrintItem = ts.Items.Add(_with1.Text, _with1.Image, new EventHandler(MyPrintItemClicked));

                myPrintItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
                //Relocate the item to the beginning of the toolstrip
                ts.Items.Insert(0, myPrintItem);

                //Remove the orginal button
                ts.Items.Remove(printItem);
            }
		}

		private void MyPrintItemClicked(object sender, EventArgs e)
		{
            this.focusTimer.Start();
		}

		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.focusTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // focusTimer
            // 
            this.focusTimer.Tick += new System.EventHandler(this.focusTimer_Tick);
            // 
            // PrintPreviewDialogSelectPrinter
            // 
            this.ClientSize = new System.Drawing.Size(815, 457);
            this.Name = "PrintPreviewDialogSelectPrinter";
            this.ResumeLayout(false);

		}
		public PrintPreviewDialogSelectPrinter()
		{
			Shown += myPrintPreview_Shown;
            InitializeComponent();
        }

        private void focusTimer_Tick(object sender, EventArgs e)
        {
            this.focusTimer.Stop();

            // Show the print dialog, this is done in a timer so that we ensure the print dialog gets focus when created.
            // See: https://stackoverflow.com/questions/4372969/print-dialog-focus-issue
            PrintDialog dlgPrint = new PrintDialog();
            try
            {
                var _with2 = dlgPrint;
                _with2.AllowSomePages = true;
                _with2.AllowSelection = true;
                _with2.ShowNetwork = true;
                _with2.UseEXDialog = true;
                _with2.Document = this.Document;
                if (dlgPrint.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.Document.Print();
                }
                this.Close();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Print Error: " + ex.Message);
            }
        }
    }
}
