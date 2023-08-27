using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SidderApp
{
    partial class ExpandBox : Form
    {
        public ListView listViewUVHDFiles;
        private Button buttonCancel;
        private Button buttonOK;
        private ColumnHeader columnHeader2;
        private ImageList imageList;
        private System.ComponentModel.IContainer components;
        private ColumnHeader columnHeader3;
        private TextBox textBoxNewSize;
        private Label label1;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader1;
    
        public ExpandBox()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExpandBox));
            this.listViewUVHDFiles = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.textBoxNewSize = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listViewUVHDFiles
            // 
            this.listViewUVHDFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewUVHDFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listViewUVHDFiles.FullRowSelect = true;
            this.listViewUVHDFiles.HideSelection = false;
            this.listViewUVHDFiles.Location = new System.Drawing.Point(12, 12);
            this.listViewUVHDFiles.MultiSelect = false;
            this.listViewUVHDFiles.Name = "listViewUVHDFiles";
            this.listViewUVHDFiles.Size = new System.Drawing.Size(716, 375);
            this.listViewUVHDFiles.SmallImageList = this.imageList;
            this.listViewUVHDFiles.TabIndex = 2;
            this.listViewUVHDFiles.UseCompatibleStateImageBehavior = false;
            this.listViewUVHDFiles.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "UVHD files to expand";
            this.columnHeader1.Width = 354;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Username";
            this.columnHeader2.Width = 115;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "NativeSize (MB)";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "New NativeSize (MB)";
            this.columnHeader4.Width = 120;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "drive.png");
            this.imageList.Images.SetKeyName(1, "driveerror.png");
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(653, 393);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(572, 393);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // textBoxNewSize
            // 
            this.textBoxNewSize.Location = new System.Drawing.Point(99, 394);
            this.textBoxNewSize.Name = "textBoxNewSize";
            this.textBoxNewSize.Size = new System.Drawing.Size(100, 22);
            this.textBoxNewSize.TabIndex = 3;
            this.textBoxNewSize.TextChanged += new System.EventHandler(this.textBoxNewSize_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 398);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "New Size (MB):";
            // 
            // ExpandBox
            // 
            this.ClientSize = new System.Drawing.Size(740, 424);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxNewSize);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.listViewUVHDFiles);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExpandBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Expand";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void textBoxNewSize_TextChanged(object sender, EventArgs e)
        {
            if (textBoxNewSize.Text.Length > 0)
            {
                if (ulong.TryParse(textBoxNewSize.Text, out ulong newSize))
                {
                    textBoxNewSize.BackColor = SystemColors.Window;

                    foreach (ListViewItem item in listViewUVHDFiles.Items)
                    {
                        if (ulong.TryParse(item.SubItems[2].Text, out ulong oldSize))
                        {
                            if (newSize > 0 && newSize > oldSize)
                            {
                                item.SubItems[3].Text = newSize.ToString();
                            }
                            else
                            {
                                item.SubItems[3].Text = oldSize.ToString();
                            }
                        }
                    }
                }
                else
                {
                    textBoxNewSize.BackColor = Color.IndianRed;
                }
            } else textBoxNewSize.BackColor = SystemColors.Window;
        }
    }
}
