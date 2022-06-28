using TNBase.DataStorage;
using TNBase.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace TNBase
{
    public partial class FormPrintMagazineWallets : Form
    {
        private readonly IServiceLayer serviceLayer = Program.ServiceProvider.GetRequiredService<IServiceLayer>();

        List<Listener> theListeners = new List<Listener>();
        int totalPages = 0;
        int currentPageNumber = 0;

        public FormPrintMagazineWallets()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetInitial()
        {
            theListeners = serviceLayer.GetPostListenersByStatus(ListenerStates.ACTIVE)
                .Where(x=>x.Magazine).ToList();

            theListeners.Sort(new INumbListener());

            totalPages = (int)Math.Ceiling((double)theListeners.Count / 40);
            if (totalPages == 0)
            {
                totalPages = 1;
            }
        }


        // Print form.
        private void printForm()
        {
            printPreview.Document = printMagazineWalletsDoc;
            printPreview.ClientSize = new Size(600, 600);
            printPreview.ShowDialog();
        }

        private void formPrintMagazineWallets_Load(object sender, EventArgs e)
        {
            SetInitial();
            printForm();
            this.Close();
        }

        private void printMagazineWalletsDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font reportFont = new System.Drawing.Font("Times New Roman", 24, FontStyle.Bold);
            Font reportFontSmall = new System.Drawing.Font("Times New Roman", 16);
            Font reportFontSmallBold = new System.Drawing.Font("Times New Roman", 14, FontStyle.Bold);
            Font reportFontSmallBoldTitles = new System.Drawing.Font("Times New Roman", 16, FontStyle.Bold);
            Font reportFontBigBoldTitles = new System.Drawing.Font("Times New Roman", 30, FontStyle.Bold);

            Graphics g = e.Graphics;
            int pageHeight = e.MarginBounds.Height;

            // More page stuff
            if (theListeners.Count >= 40)
            {
                e.HasMorePages = true;
            }
            currentPageNumber = currentPageNumber + 1;

            g.DrawString("Magazine Wallets", reportFont, Brushes.Black, 280, 80, StringFormat.GenericTypographic);

            int tempCount = theListeners.Count - 1;
            for (int value = 0; value <= Math.Min(39, tempCount); value++)
            {
                Listener currentI = theListeners[0];
                int myColumn = (value % 2);

                var initialY = (20 * value) + 100;
                if (myColumn == 1)
                {
                    initialY -= 20;
                }
                var initialX = (myColumn * 400) + 60;

                g.DrawString(currentI.Wallet + ". " + currentI.GetNiceName(), reportFontSmall, Brushes.Black, initialX, initialY + 40);
                theListeners.RemoveAt(0);
            }
            g.DrawString("Page " + currentPageNumber + "/" + totalPages, reportFontSmallBold, Brushes.Black, 380, 970);

            // VB is stupid.... have to reset this so its back when you actually print it!
            if (!(e.HasMorePages))
            {
                SetInitial();
            }
        }
    }
}
