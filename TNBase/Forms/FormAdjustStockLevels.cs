﻿using Microsoft.VisualBasic;
using NLog;
using TNBase.DataStorage;
using TNBase.Objects;
using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace TNBase
{
    public partial class FormAdjustStockLevels : Form
    {
        // Logging instance.
        private Logger log = LogManager.GetCurrentClassLogger();

        private readonly IServiceLayer serviceLayer = Program.ServiceProvider.GetRequiredService<IServiceLayer>();

        private Listener listener;

        public FormAdjustStockLevels()
        {
            InitializeComponent();
        }

        public void setListener(Listener listener)
        {
            this.listener = listener;
            lblName.Text = listener.GetNiceName();
            lblWallet.Text = "Wallet: " + listener.Wallet;

            textStock.Text = listener.Stock.ToString();

            textIn1.Text = listener.InOutRecords.In1.ToString();
            textIn2.Text = listener.InOutRecords.In2.ToString();
            textIn3.Text = listener.InOutRecords.In3.ToString();
            textIn4.Text = listener.InOutRecords.In4.ToString();
            textIn5.Text = listener.InOutRecords.In5.ToString();
            textIn6.Text = listener.InOutRecords.In6.ToString();
            textIn7.Text = listener.InOutRecords.In7.ToString();
            textIn8.Text = listener.InOutRecords.In8.ToString();

            textOut1.Text = listener.InOutRecords.Out1.ToString();
            textOut2.Text = listener.InOutRecords.Out2.ToString();
            textOut3.Text = listener.InOutRecords.Out3.ToString();
            textOut4.Text = listener.InOutRecords.Out4.ToString();
            textOut5.Text = listener.InOutRecords.Out5.ToString();
            textOut6.Text = listener.InOutRecords.Out6.ToString();
            textOut7.Text = listener.InOutRecords.Out7.ToString();
            textOut8.Text = listener.InOutRecords.Out8.ToString();
        }

        private void formAdjustStockLevels_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            try
            {
                listener.Stock = int.Parse(textStock.Text);

                listener.InOutRecords.In1 = int.Parse(textIn1.Text);
                listener.InOutRecords.In2 = int.Parse(textIn2.Text);
                listener.InOutRecords.In3 = int.Parse(textIn3.Text);
                listener.InOutRecords.In4 = int.Parse(textIn4.Text);
                listener.InOutRecords.In5 = int.Parse(textIn5.Text);
                listener.InOutRecords.In6 = int.Parse(textIn6.Text);
                listener.InOutRecords.In7 = int.Parse(textIn7.Text);
                listener.InOutRecords.In8 = int.Parse(textIn8.Text);

                listener.InOutRecords.Out1 = int.Parse(textOut1.Text);
                listener.InOutRecords.Out2 = int.Parse(textOut2.Text);
                listener.InOutRecords.Out3 = int.Parse(textOut3.Text);
                listener.InOutRecords.Out4 = int.Parse(textOut4.Text);
                listener.InOutRecords.Out5 = int.Parse(textOut5.Text);
                listener.InOutRecords.Out6 = int.Parse(textOut6.Text);
                listener.InOutRecords.Out7 = int.Parse(textOut7.Text);
                listener.InOutRecords.Out8 = int.Parse(textOut8.Text);

                serviceLayer.UpdateListener(listener);

                Interaction.MsgBox("Listener updated!");
                this.Close();
            }
            catch (Exception ex)
            {
                log.Error(ex, "Failed to adjust stock for listener!");
                Interaction.MsgBox("Failed to adjust stock for listener: " + ex.Message);
            }
        }

        private void textIn1_TextChanged(object sender, EventArgs e)
        {
            labelWarning.Visible = true;
        }

        private void textIn2_TextChanged(object sender, EventArgs e)
        {
            labelWarning.Visible = true;
        }

        private void textIn3_TextChanged(object sender, EventArgs e)
        {
            labelWarning.Visible = true;
        }

        private void textIn4_TextChanged(object sender, EventArgs e)
        {
            labelWarning.Visible = true;
        }

        private void textIn5_TextChanged(object sender, EventArgs e)
        {
            labelWarning.Visible = true;
        }

        private void textIn6_TextChanged(object sender, EventArgs e)
        {
            labelWarning.Visible = true;
        }

        private void textIn7_TextChanged(object sender, EventArgs e)
        {
            labelWarning.Visible = true;
        }

        private void textIn8_TextChanged(object sender, EventArgs e)
        {
            labelWarning.Visible = true;
        }

        private void textOut1_TextChanged(object sender, EventArgs e)
        {
            labelWarning.Visible = true;
        }

        private void textOut2_TextChanged(object sender, EventArgs e)
        {
            labelWarning.Visible = true;
        }

        private void textOut3_TextChanged(object sender, EventArgs e)
        {
            labelWarning.Visible = true;
        }

        private void textOut4_TextChanged(object sender, EventArgs e)
        {
            labelWarning.Visible = true;
        }

        private void textOut5_TextChanged(object sender, EventArgs e)
        {
            labelWarning.Visible = true;
        }

        private void textOut6_TextChanged(object sender, EventArgs e)
        {
            labelWarning.Visible = true;
        }

        private void textOut7_TextChanged(object sender, EventArgs e)
        {
            labelWarning.Visible = true;
        }

        private void textOut8_TextChanged(object sender, EventArgs e)
        {
            labelWarning.Visible = true;
        }
    }
}
