using System;
using TNBase.Objects;
namespace TNBase
{
    public partial class FormChoosePrintPoint
	{

		Listener myListener;
		public void SetupForm(Listener theListener)
		{
			myListener = theListener;
			cmbSelection.Text = "1 - 4";
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			My.MyProject.Forms.formPrintLabels.Show();
			int myIndex = 0;
			if (CheckBox5.Checked == true) {
				myIndex = 4;
			}
			if (CheckBox7.Checked == true) {
				myIndex = 8;
			}
			if (CheckBox15.Checked == true) {
				myIndex = 12;
			}

			My.MyProject.Forms.formPrintLabels.setupForm(myListener, myIndex);
			this.Close();
		}

		private void UncheckAll()
		{
			CheckBox1.Checked = false;
			CheckBox2.Checked = false;
			CheckBox3.Checked = false;
			CheckBox4.Checked = false;
			CheckBox5.Checked = false;
			CheckBox6.Checked = false;
			CheckBox7.Checked = false;
			CheckBox8.Checked = false;
			CheckBox9.Checked = false;
			CheckBox10.Checked = false;
			CheckBox11.Checked = false;
			CheckBox12.Checked = false;
			CheckBox13.Checked = false;
			CheckBox14.Checked = false;
			CheckBox15.Checked = false;
			CheckBox16.Checked = false;
			CheckBox17.Checked = false;
			CheckBox18.Checked = false;
		}

		private void CheckBox1_Click(object sender, EventArgs e)
		{
			UncheckAll();
			CheckBox1.Checked = true;
			CheckBox2.Checked = true;
			CheckBox3.Checked = true;
			CheckBox6.Checked = true;
			cmbSelection.SelectedIndex = 0;
		}

		private void CheckBox5_Click(object sender, EventArgs e)
		{
			UncheckAll();
			CheckBox5.Checked = true;
			CheckBox4.Checked = true;
			CheckBox8.Checked = true;
			CheckBox9.Checked = true;
			cmbSelection.SelectedIndex = 1;
		}

		private void CheckBox7_Click(object sender, EventArgs e)
		{
			UncheckAll();
			CheckBox7.Checked = true;
			CheckBox12.Checked = true;
			CheckBox11.Checked = true;
			CheckBox10.Checked = true;
			cmbSelection.SelectedIndex = 2;
		}

		private void CheckBox15_Click(object sender, EventArgs e)
		{
			UncheckAll();
			CheckBox15.Checked = true;
			CheckBox14.Checked = true;
			CheckBox13.Checked = true;
			CheckBox18.Checked = true;
			cmbSelection.SelectedIndex = 3;
		}

		private void cmbSelection_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cmbSelection.SelectedItem.ToString() == "1 - 4") 
            {
				UncheckAll();
				CheckBox1.Checked = true;
				CheckBox2.Checked = true;
				CheckBox3.Checked = true;
				CheckBox6.Checked = true;
			} 
            else if (cmbSelection.SelectedItem.ToString() == "5 - 8") 
            {
				UncheckAll();
				CheckBox5.Checked = true;
				CheckBox4.Checked = true;
				CheckBox8.Checked = true;
				CheckBox9.Checked = true;
			} 
            else if (cmbSelection.SelectedItem.ToString() == "9 - 12") 
            {
				UncheckAll();
				CheckBox7.Checked = true;
				CheckBox12.Checked = true;
				CheckBox11.Checked = true;
				CheckBox10.Checked = true;
			}
            else if (cmbSelection.SelectedItem.ToString() == "13 - 16") 
            {
				UncheckAll();
				CheckBox15.Checked = true;
				CheckBox14.Checked = true;
				CheckBox13.Checked = true;
				CheckBox18.Checked = true;
			}
		}
		public FormChoosePrintPoint()
		{
			InitializeComponent();
		}
	}
}
