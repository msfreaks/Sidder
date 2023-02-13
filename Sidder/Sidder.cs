using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.DirectoryServices.AccountManagement;

namespace SidderApp
{
    public partial class Sidder : Form
    {
        // private ListViewColumnSorter listViewColumnSorter;
        private PrincipalContext principalContext = new PrincipalContext(ContextType.Domain);

        public Sidder()
        {
            InitializeComponent();
            // listViewColumnSorter = new ListViewColumnSorter();
            this.listViewUVHDFiles.ListViewItemSorter = new Sorter();
            //this.listViewUVHDFiles.ListViewItemSorter = listViewColumnSorter;

        }


        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            FolderSelect.FolderSelectDialog selectDialog = new FolderSelect.FolderSelectDialog();
            selectDialog.Title = "Select a folder containing UVHD files";
            if (!String.IsNullOrEmpty(textBoxFilePathUVHD.Text))
            {
                selectDialog.InitialDirectory = textBoxFilePathUVHD.Text + "\\";
            }
            bool result = selectDialog.ShowDialog(this.Handle);           

            if (result)
            {
                string filePathUVHD = selectDialog.FileName;
                textBoxFilePathUVHD.Text = filePathUVHD;
            }
        }

        /// <summary>
        /// Extract SID from filename and grab corresponding <domain>\<username>
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private string ConvertUVHDtoUsername(string fileName)
        {
            string returnValue = String.Empty;

            fileName = fileName.ToUpper();

            try
            {
                if (fileName.Substring(0, 5) != "UVHD-" || fileName.Substring(fileName.Length - 5, 5) != ".VHDX")
                {
                    returnValue = "Filename Error";
                }
                else
                {
                    UserPrincipal user = UserPrincipal.FindByIdentity(principalContext, (fileName.Substring(5, fileName.Length - 10)));
                    returnValue = user.UserPrincipalName; 
                    // returnValue = new SecurityIdentifier(fileName.Substring(5, fileName.Length - 10)).Translate(typeof(NTAccount)).ToString();
                }

            }
            catch 
            {
                returnValue = "SID Resolve Error";
            }

            return returnValue;
        }

        private void listViewUVHDFiles_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            Sorter s = (Sorter)listViewUVHDFiles.ListViewItemSorter;
            s.Column = e.Column;

            if (s.Order == System.Windows.Forms.SortOrder.Ascending)
            {
                s.Order = System.Windows.Forms.SortOrder.Descending;
            }
            else
            {
                s.Order = System.Windows.Forms.SortOrder.Ascending;
            }
            listViewUVHDFiles.Sort();
        }

        /*
        private void listViewUVHDFiles_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if ( e.Column == listViewColumnSorter.SortColumn )
            {
                if(e.Column == 3)
                {
                    // convert string column to int before sorting

                }
	            // Reverse the current sort direction for this column.
	            if (listViewColumnSorter.Order == SortOrder.Ascending)
	            {
		            listViewColumnSorter.Order = SortOrder.Descending;
	            }
	            else
	            {
		            listViewColumnSorter.Order = SortOrder.Ascending;
	            }
            }
            else
            {
	            // Set the column number that is to be sorted; default to ascending.
	            listViewColumnSorter.SortColumn = e.Column;
	            listViewColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.listViewUVHDFiles.Sort();

        }
        */

        private void Sidder_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Properties.Settings.Default.userUVHDFilePath)){this.textBoxFilePathUVHD.Text = Properties.Settings.Default.userUVHDFilePath;}
            this.listViewUVHDFiles.Columns[0].Width = Properties.Settings.Default.userColumn1;
            this.listViewUVHDFiles.Columns[1].Width = Properties.Settings.Default.userColumn2;
            this.listViewUVHDFiles.Columns[2].Width = Properties.Settings.Default.userColumn3;
            this.listViewUVHDFiles.Columns[3].Width = Properties.Settings.Default.userColumn4;
            this.listViewUVHDFiles.Columns[4].Width = Properties.Settings.Default.userColumn5;
            this.listViewUVHDFiles.Columns[5].Width = Properties.Settings.Default.userColumn6;
            this.Width = Properties.Settings.Default.sidderWidth;
            this.Height = Properties.Settings.Default.sidderHeight;
        }

        private void Sidder_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.userUVHDFilePath = this.textBoxFilePathUVHD.Text;
            Properties.Settings.Default.userColumn1 = this.listViewUVHDFiles.Columns[0].Width;
            Properties.Settings.Default.userColumn2 = this.listViewUVHDFiles.Columns[1].Width;
            Properties.Settings.Default.userColumn3 = this.listViewUVHDFiles.Columns[2].Width;
            Properties.Settings.Default.userColumn4 = this.listViewUVHDFiles.Columns[3].Width;
            Properties.Settings.Default.userColumn5 = this.listViewUVHDFiles.Columns[4].Width;
            Properties.Settings.Default.userColumn6 = this.listViewUVHDFiles.Columns[5].Width;
            Properties.Settings.Default.sidderWidth = this.Width;
            Properties.Settings.Default.sidderHeight = this.Height;
            Properties.Settings.Default.Save();
        }

        private void textBoxFilePathUVHD_TextChanged(object sender, EventArgs e)
        {
            string filePathUVHD = textBoxFilePathUVHD.Text;

            if (filePathUVHD.ToLower() == textBoxFilePathUVHDCurrent.Text) { return; }

            refreshListBox(filePathUVHD);

            textBoxFilePathUVHDCurrent.Text = filePathUVHD.ToLower();
        }

        private void refreshListBox(string filePath)
        {
            buttonRefresh.Enabled = false;
            listViewUVHDFiles.Enabled = false;
            
            try
            {
                DirectoryInfo directory = new DirectoryInfo(filePath);
                if (!directory.Exists)
                {
                    textBoxStatus.Text = "Folder not found.";
                    return;
                }

                FileInfo[] files = directory.GetFiles("UVHD-*.vhdx");

                if (files.GetLength(0) < 1)
                {
                    textBoxStatus.Text = "No UVHD Profile disks found in current folder.";
                    return;
                }

                textBoxStatus.Text = "Refreshing..";

                listViewUVHDFiles.Items.Clear();

                foreach (FileInfo file in files)
                {
                    int fileLock = 0;
                    if (IsFileLocked(file)) { fileLock = 1; }
                    ListViewItem item = new ListViewItem(file.Name, fileLock);
                    item.SubItems.Add(file.LastWriteTime.ToString());
                    item.SubItems.Add(ConvertUVHDtoUsername(file.Name));
                    long fileSize = file.Length / 1024 / 1024;
                    item.SubItems.Add(fileSize.ToString());
                    var vhdxInfo = new VHDXParser(file.FullName);
                    item.SubItems.Add((vhdxInfo.FirstPartitionSize / 1024 / 1024).ToString());
                    item.SubItems.Add((vhdxInfo.NativeDiskSize / 1024 / 1024).ToString());
                    item.SubItems.Add(file.FullName);

                    listViewUVHDFiles.Items.Add(item);
                }

                textBoxStatus.Text = String.Format("Folder processed. {0} UVHD Profile disks found.", listViewUVHDFiles.Items.Count.ToString());
            }
            catch (Exception e)
            {
                textBoxStatus.Text = e.Message; // "Error getting UVHD files. Try restarting Sidder with administrative rights.";
            }
            buttonRefresh.Enabled = true;
            listViewUVHDFiles.Enabled = true;
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            refreshListBox(textBoxFilePathUVHD.Text);
        }

        private void listViewUVHDFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewUVHDFiles.SelectedItems.Count < 1) 
            {
                buttonDelete.Enabled = false;
                return;
            }

            buttonDelete.Enabled = true;

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

            DeleteBox deleteBox = new DeleteBox();
            deleteBox.listViewUVHDFiles.Items.Clear();

            foreach(ListViewItem item in listViewUVHDFiles.SelectedItems)
            {
                ListViewItem deleteItem = new ListViewItem(item.Text, item.ImageIndex);
                deleteItem.SubItems.Add(item.SubItems[2].Text);
                deleteItem.SubItems.Add(item.SubItems[4].Text);
                deleteBox.listViewUVHDFiles.Items.Add(deleteItem);
            }

            DialogResult result = deleteBox.ShowDialog();

            if (result == DialogResult.Cancel) { return; }

            if (result == DialogResult.OK)
            {
                foreach(ListViewItem item in deleteBox.listViewUVHDFiles.Items)
                {
                    try
                    {
                        File.Delete(item.SubItems[2].Text);
                    }
                    catch (Exception)
                    {
                    }
                }

                refreshListBox(textBoxFilePathUVHD.Text);
            }
        }

        protected virtual bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            return false;
        }

    }
}
