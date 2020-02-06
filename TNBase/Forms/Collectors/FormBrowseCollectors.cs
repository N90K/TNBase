using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using TNBase.Objects;
using TNBase.DataStorage;
namespace TNBase
{
    public partial class FormBrowseCollectors
	{
        IServiceLayer serviceLayer = new ServiceLayer(ModuleGeneric.GetDatabasePath());

		int limit = 15;

		int offset = 0;
		public void clearList()
		{
			lstBrowse.Items.Clear();
		}

		public void refreshList()
		{
			clearList();

			List<Collector> theCollectors = new List<Collector>();
            theCollectors = serviceLayer.GetCollectors().Skip(offset).Take(limit).ToList();

            foreach (Collector tCollector in theCollectors)
            {
				addToCollectors(tCollector);
			}
		}

		// Add items to the list.
		public void addToCollectors(Collector theCollector)
		{
			//Add items in the listview
			string[] arr = new string[12];
			ListViewItem itm = null;

			//Add first item
			arr[0] = theCollector.ID.ToString();
			arr[1] = theCollector.Forename;
			arr[2] = theCollector.Surname;
			arr[3] = theCollector.Number;
			arr[4] = theCollector.Postcodes;

			itm = new ListViewItem(arr);

			lstBrowse.Items.Add(itm);
		}

		private void btnRemove_Click(object sender, EventArgs e)
		{
			int theIndex = 0;
			theIndex = lstBrowse.FocusedItem.Index;

			// First sub item is wallet number.
			int Id = 0;
			Id = int.Parse(lstBrowse.Items[theIndex].SubItems[0].Text);

            DialogResult result = MessageBox.Show("Are you sure you wish to delete the selected collector?", ModuleGeneric.getAppShortName(), MessageBoxButtons.YesNo);
			if (result == DialogResult.No) {
				return;
			} else if (result == DialogResult.Yes) {
				if (!serviceLayer.DeleteCollector(serviceLayer.GetCollector(Id))) {
					Interaction.MsgBox("Error: Failed to delete collector!");
				} else {
					Interaction.MsgBox("Successfully deleted collector.");
				}
			}

			refreshList();
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			int theIndex = 0;

			try {
				theIndex = lstBrowse.FocusedItem.Index;

				// First sub item is wallet number.
				int id = 0;
				id = int.Parse(lstBrowse.Items[theIndex].SubItems[0].Text);

				Collector theCollector = serviceLayer.GetCollector(id);
				My.MyProject.Forms.formAddCollectors.Show();
				My.MyProject.Forms.formAddCollectors.setupEditMode(theCollector);

				refreshList();
			} catch (Exception ex) {
				// Probably nothing selected... ignore.
			}
		}

		private void btnDone_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnFirst_Click(object sender, EventArgs e)
		{
			offset = 0;
			refreshList();
		}

		private void btnPrevious_Click(object sender, EventArgs e)
		{
            if ((offset - limit) >= 0)
            {
                offset -= limit;
            }
            else
            {
                offset = 0;
            }
            refreshList();
		}

		private void btnNext_Click(object sender, EventArgs e)
		{
            if ((offset + limit) < serviceLayer.GetCollectors().Count())
            {
                offset += limit;
            }
			refreshList();
		}

		private void btnLast_Click(object sender, EventArgs e)
		{
            offset = serviceLayer.GetCollectors().Count - limit;
			refreshList();
		}

		private void formBrowseCollectors_Load(object sender, EventArgs e)
		{
			refreshList();
		}
		public FormBrowseCollectors()
		{
			Load += formBrowseCollectors_Load;
			InitializeComponent();
		}
	}
}
