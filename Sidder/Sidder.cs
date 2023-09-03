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
using SidderApp.Exceptions;
using SidderApp.Parser;
using SidderApp.Storages;

namespace SidderApp
{
    public partial class Sidder : Form
    {
        // private ListViewColumnSorter listViewColumnSorter;
        private DiskListStorage _disks { get; set; }

        public Sidder()
        {
            InitializeComponent();
            // listViewColumnSorter = new ListViewColumnSorter();
            this.listViewUVHDFiles.ListViewItemSorter = new Sorter();
            //this.listViewUVHDFiles.ListViewItemSorter = listViewColumnSorter;

            this._disks = new DiskListStorage();
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
            this.listViewUVHDFiles.Columns[0].Width = Config.CurrentConfig.ColumnWitdth1;
            this.listViewUVHDFiles.Columns[1].Width = Config.CurrentConfig.ColumnWitdth2;
            this.listViewUVHDFiles.Columns[2].Width = Config.CurrentConfig.ColumnWitdth3;
            this.listViewUVHDFiles.Columns[3].Width = Config.CurrentConfig.ColumnWitdth4;
            this.listViewUVHDFiles.Columns[4].Width = Config.CurrentConfig.ColumnWitdth5;
            this.listViewUVHDFiles.Columns[5].Width = Config.CurrentConfig.ColumnWitdth6;
            this.Width = Config.CurrentConfig.MainFormWidth;
            this.Height = Config.CurrentConfig.MainFormHeight;

            if (!String.IsNullOrEmpty(Config.CurrentConfig.PathUVHD)) { this.textBoxFilePathUVHD.Text = Config.CurrentConfig.PathUVHD; }
        }

        private void Sidder_FormClosing(object sender, FormClosingEventArgs e)
        {
            Config.CurrentConfig.PathUVHD = this.textBoxFilePathUVHD.Text;
            Config.CurrentConfig.ColumnWitdth1 = this.listViewUVHDFiles.Columns[0].Width;
            Config.CurrentConfig.ColumnWitdth2 = this.listViewUVHDFiles.Columns[1].Width;
            Config.CurrentConfig.ColumnWitdth3 = this.listViewUVHDFiles.Columns[2].Width;
            Config.CurrentConfig.ColumnWitdth4 = this.listViewUVHDFiles.Columns[3].Width;
            Config.CurrentConfig.ColumnWitdth5 = this.listViewUVHDFiles.Columns[4].Width;
            Config.CurrentConfig.ColumnWitdth6 = this.listViewUVHDFiles.Columns[5].Width;
            Config.CurrentConfig.MainFormWidth = this.Width;
            Config.CurrentConfig.MainFormHeight = this.Height;

            Config.CurrentConfig.Dispose();
        }

        private void textBoxFilePathUVHD_TextChanged(object sender, EventArgs e)
        {
            string filePathUVHD = textBoxFilePathUVHD.Text;

            if (filePathUVHD.ToLower() == textBoxFilePathUVHDCurrent.Text) { return; }

            refreshListBox(textBoxFilePathUVHD.Text);

            textBoxFilePathUVHDCurrent.Text = filePathUVHD.ToLower();
        }

        private void refreshDiskList(string filePath)
        {
            this._disks.UpdateListUPD(filePath);
        }

        private void refreshListBox(string filePath, bool updateViewOnly = false)
        {
            buttonRefresh.Enabled = false;
            listViewUVHDFiles.Enabled = false;
            textBoxSearchUsername.Text = String.Empty;

            if (!updateViewOnly) refreshDiskList(filePath);

            try
            {
                textBoxStatus.Text = "Refreshing..";

                refreshListBox(this._disks.DiskList);

                textBoxStatus.Text = String.Format("Folder processed. {0} UVHD Profile disks found.", listViewUVHDFiles.Items.Count.ToString());
            }
            catch (NoFilesFoundException)
            {
                textBoxStatus.Text = "No UVHD Profile disks found in current folder.";
            }
            catch (DirectoryNotFoundException)
            {
                textBoxStatus.Text = "Folder not found.";
            }
            catch (Exception e)
            {
                textBoxStatus.Text = e.Message; // "Error getting UVHD files. Try restarting Sidder with administrative rights.";
            }
            buttonRefresh.Enabled = true;
            listViewUVHDFiles.Enabled = true;
        }

        private void refreshListBox(IEnumerable<DiskListStorage.DiskListEntry> _diskList)
        {
            buttonExpand.Enabled = false;
            buttonDelete.Enabled = false;

            listViewUVHDFiles.Items.Clear();

            foreach (var disk in _diskList)
            {
                int fileLock = disk.DiskInUse ? 1 : 0;

                ListViewItem item = new ListViewItem(disk.DiskName, fileLock);
                item.SubItems.Add(disk.DiskFileLastChange.ToString());
                item.SubItems.Add(disk.DiskUsername);
                item.SubItems.Add(disk.DiskFileSizeMB.ToString());
                item.SubItems.Add(disk.DiskPartitionSizeMB.ToString());
                item.SubItems.Add(disk.DiskNativeSizeMB.ToString());
                item.SubItems.Add(disk.DiskFullName);

                listViewUVHDFiles.Items.Add(item);
            }
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
                buttonExpand.Enabled = false;
                buttonDelete.Enabled = false;
                return;
            }

            buttonExpand.Enabled = true;
            buttonDelete.Enabled = true;

        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            SettingsBox settingsBox = new SettingsBox();
            settingsBox.radioButtonNTAccount.Checked = (Config.CurrentConfig.UsernameFormat == UsernameFormatType.NTAccount);
            settingsBox.radioButtonUPN.Checked = (Config.CurrentConfig.UsernameFormat == UsernameFormatType.UserPrincipalName);
            settingsBox.radioButtonCSVComma.Checked = (Config.CurrentConfig.ExportDivider == ExportDividerType.Comma);
            settingsBox.radioButtonCSVSemicolon.Checked = (Config.CurrentConfig.ExportDivider == ExportDividerType.Semicolon);
            settingsBox.radioButtonCSVSizeMB.Checked = (Config.CurrentConfig.ExportSize == ExportSizeType.Megabytes);
            settingsBox.radioButtonCSVSizeBytes.Checked = (Config.CurrentConfig.ExportSize == ExportSizeType.Bytes);

            DialogResult result = settingsBox.ShowDialog();

            if (result == DialogResult.Cancel) { return; }

            if (result == DialogResult.OK)
            {
                Config.CurrentConfig.UsernameFormat = (settingsBox.radioButtonNTAccount.Checked ? UsernameFormatType.NTAccount : UsernameFormatType.UserPrincipalName);
                Config.CurrentConfig.ExportDivider = (settingsBox.radioButtonCSVComma.Checked ? ExportDividerType.Comma : ExportDividerType.Semicolon);
                Config.CurrentConfig.ExportSize = (settingsBox.radioButtonCSVSizeMB.Checked ? ExportSizeType.Megabytes : ExportSizeType.Bytes);

                refreshListBox(textBoxFilePathUVHD.Text);
            }
        }

        private void buttonExpand_Click(object sender, EventArgs e)
        {
            ExpandBox expandBox = new ExpandBox();
            expandBox.listViewUVHDFiles.Items.Clear();

            foreach (ListViewItem item in listViewUVHDFiles.SelectedItems)
            {
                if (item.ImageIndex == 0)
                {
                    ListViewItem expandItem = new ListViewItem(item.Text, item.ImageIndex);
                    expandItem.SubItems.Add(item.SubItems[2].Text);
                    expandItem.SubItems.Add(item.SubItems[5].Text);
                    expandItem.SubItems.Add(item.SubItems[5].Text);
                    expandItem.SubItems.Add(item.SubItems[6].Text);
                    expandBox.listViewUVHDFiles.Items.Add(expandItem);
                }
            }

            if (expandBox.listViewUVHDFiles.Items.Count > 0)
            {
                DialogResult result = expandBox.ShowDialog();

                if (result == DialogResult.Cancel) { return; }

                if (result == DialogResult.OK)
                {
                    foreach (ListViewItem item in expandBox.listViewUVHDFiles.Items)
                    {
                        try
                        {
                            if (ulong.TryParse(item.SubItems[2].Text, out ulong oldSize) && ulong.TryParse(item.SubItems[3].Text, out ulong newSize))
                            {
                                if (newSize > 0 && newSize > oldSize)
                                {
                                    (new VHDXParser(item.SubItems[4].Text)).SetNativeDiskSize(newSize * 1024 * 1024);
                                }
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }

                    refreshListBox(textBoxFilePathUVHD.Text);
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DeleteBox deleteBox = new DeleteBox();
            deleteBox.listViewUVHDFiles.Items.Clear();

            foreach(ListViewItem item in listViewUVHDFiles.SelectedItems)
            {
                if (item.ImageIndex == 0)
                {
                    ListViewItem deleteItem = new ListViewItem(item.Text, item.ImageIndex);
                    deleteItem.SubItems.Add(item.SubItems[2].Text);
                    deleteItem.SubItems.Add(item.SubItems[6].Text);
                    deleteBox.listViewUVHDFiles.Items.Add(deleteItem);
                }
            }

            if (deleteBox.listViewUVHDFiles.Items.Count > 0)
            {
                DialogResult result = deleteBox.ShowDialog();

                if (result == DialogResult.Cancel) { return; }

                if (result == DialogResult.OK)
                {
                    foreach (ListViewItem item in deleteBox.listViewUVHDFiles.Items)
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
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            using (var fileSave = new SaveFileDialog())
            {
                fileSave.Title = "Export to CSV";
                fileSave.Filter = "CSV file (*.csv)|*.csv| All Files (*.*)|*.*";
                fileSave.FilterIndex = 0;
                fileSave.RestoreDirectory = true;
                fileSave.CreatePrompt = true;

                if (fileSave.ShowDialog() == DialogResult.OK)
                {
                    if (this._disks.ExportCSV(fileSave.FileName))
                    {
                        MessageBox.Show("Export done!", "CSV Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Export failed!", "CSV Export", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void textBoxSearchUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter) && this._disks.DiskList.Count > 0)
            {
                if (textBoxSearchUsername.Text.Length > 0)
                {
                    refreshListBox(this._disks.DiskList.Where(x => x.DiskUsername.ToLower().Contains(textBoxSearchUsername.Text.ToLower())));
                }
                else
                {
                    refreshListBox(this._disks.DiskList);
                }
            }
        }
    }
}
