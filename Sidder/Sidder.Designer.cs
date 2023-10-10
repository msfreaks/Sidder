namespace SidderApp
{
    partial class Sidder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sidder));
            System.Windows.Forms.ColumnHeader columnHeader1;
            System.Windows.Forms.ColumnHeader columnHeader2;
            System.Windows.Forms.ColumnHeader columnHeader3;
            System.Windows.Forms.ColumnHeader columnHeader4;
            System.Windows.Forms.ColumnHeader columnHeader5;
            System.Windows.Forms.ColumnHeader columnHeader6;
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.textBoxFilePathUVHD = new System.Windows.Forms.TextBox();
            this.labelPathToUVHD = new System.Windows.Forms.Label();
            this.linkLabel = new System.Windows.Forms.LinkLabel();
            this.textBoxFilePathUVHDCurrent = new System.Windows.Forms.TextBox();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.buttonSettings = new System.Windows.Forms.Button();
            this.buttonExpand = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.buttonExport = new System.Windows.Forms.Button();
            this.listViewUVHDFiles = new System.Windows.Forms.ListView();
            this.textBoxSearchUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "drive.png");
            this.imageList.Images.SetKeyName(1, "driveerror.png");
            // 
            // textBoxFilePathUVHD
            // 
            this.textBoxFilePathUVHD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFilePathUVHD.Enabled = false;
            this.textBoxFilePathUVHD.Location = new System.Drawing.Point(12, 25);
            this.textBoxFilePathUVHD.Name = "textBoxFilePathUVHD";
            this.textBoxFilePathUVHD.ReadOnly = true;
            this.textBoxFilePathUVHD.Size = new System.Drawing.Size(606, 22);
            this.textBoxFilePathUVHD.TabIndex = 0;
            this.textBoxFilePathUVHD.TabStop = false;
            this.textBoxFilePathUVHD.TextChanged += new System.EventHandler(this.textBoxFilePathUVHD_TextChanged);
            // 
            // labelPathToUVHD
            // 
            this.labelPathToUVHD.AutoSize = true;
            this.labelPathToUVHD.Location = new System.Drawing.Point(9, 9);
            this.labelPathToUVHD.Name = "labelPathToUVHD";
            this.labelPathToUVHD.Size = new System.Drawing.Size(105, 13);
            this.labelPathToUVHD.TabIndex = 2;
            this.labelPathToUVHD.Text = "Path to UVHD files:";
            // 
            // linkLabel
            // 
            this.linkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel.AutoSize = true;
            this.linkLabel.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(133)))), ((int)(((byte)(133)))));
            this.linkLabel.Location = new System.Drawing.Point(712, 447);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(239, 12);
            this.linkLabel.TabIndex = 10;
            this.linkLabel.TabStop = true;
            this.linkLabel.Text = "2015-2020 Arjan Mensch - msfreaks | 2023 Bastian Mencke";
            this.linkLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.toolTip.SetToolTip(this.linkLabel, "About");
            this.linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // textBoxFilePathUVHDCurrent
            // 
            this.textBoxFilePathUVHDCurrent.Location = new System.Drawing.Point(567, 477);
            this.textBoxFilePathUVHDCurrent.Name = "textBoxFilePathUVHDCurrent";
            this.textBoxFilePathUVHDCurrent.Size = new System.Drawing.Size(100, 22);
            this.textBoxFilePathUVHDCurrent.TabIndex = 6;
            this.textBoxFilePathUVHDCurrent.Visible = false;
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStatus.Enabled = false;
            this.textBoxStatus.Location = new System.Drawing.Point(13, 422);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.ReadOnly = true;
            this.textBoxStatus.Size = new System.Drawing.Size(864, 22);
            this.textBoxStatus.TabIndex = 7;
            this.textBoxStatus.TabStop = false;
            // 
            // buttonSettings
            // 
            this.buttonSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSettings.Image = global::SidderApp.Properties.Resources.wrench;
            this.buttonSettings.Location = new System.Drawing.Point(815, 25);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(28, 22);
            this.buttonSettings.TabIndex = 2;
            this.toolTip.SetToolTip(this.buttonSettings, "Settings");
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // buttonExpand
            // 
            this.buttonExpand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExpand.Enabled = false;
            this.buttonExpand.Image = global::SidderApp.Properties.Resources.expand;
            this.buttonExpand.Location = new System.Drawing.Point(883, 422);
            this.buttonExpand.Name = "buttonExpand";
            this.buttonExpand.Size = new System.Drawing.Size(28, 22);
            this.buttonExpand.TabIndex = 8;
            this.toolTip.SetToolTip(this.buttonExpand, "Expand VHDX");
            this.buttonExpand.UseVisualStyleBackColor = true;
            this.buttonExpand.Click += new System.EventHandler(this.buttonExpand_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.Enabled = false;
            this.buttonDelete.Image = global::SidderApp.Properties.Resources.delete;
            this.buttonDelete.Location = new System.Drawing.Point(917, 422);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(28, 22);
            this.buttonDelete.TabIndex = 9;
            this.toolTip.SetToolTip(this.buttonDelete, "Delete selected items");
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRefresh.Image = global::SidderApp.Properties.Resources.sync;
            this.buttonRefresh.Location = new System.Drawing.Point(849, 25);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(28, 22);
            this.buttonRefresh.TabIndex = 3;
            this.toolTip.SetToolTip(this.buttonRefresh, "Refresh");
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowse.Image = global::SidderApp.Properties.Resources.folder;
            this.buttonBrowse.Location = new System.Drawing.Point(883, 25);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(28, 22);
            this.buttonBrowse.TabIndex = 4;
            this.toolTip.SetToolTip(this.buttonBrowse, "Browse for a folder");
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // buttonExport
            // 
            this.buttonExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExport.Image = global::SidderApp.Properties.Resources.export;
            this.buttonExport.Location = new System.Drawing.Point(917, 25);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(28, 22);
            this.buttonExport.TabIndex = 5;
            this.toolTip.SetToolTip(this.buttonExport, "Export list");
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // listViewUVHDFiles
            // 
            this.listViewUVHDFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewUVHDFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnHeader1,
            columnHeader2,
            columnHeader3,
            columnHeader4,
            columnHeader5,
            columnHeader6});
            this.listViewUVHDFiles.FullRowSelect = true;
            this.listViewUVHDFiles.HideSelection = false;
            this.listViewUVHDFiles.Location = new System.Drawing.Point(12, 55);
            this.listViewUVHDFiles.Name = "listViewUVHDFiles";
            this.listViewUVHDFiles.Size = new System.Drawing.Size(933, 354);
            this.listViewUVHDFiles.SmallImageList = this.imageList;
            this.listViewUVHDFiles.TabIndex = 6;
            this.listViewUVHDFiles.UseCompatibleStateImageBehavior = false;
            this.listViewUVHDFiles.View = System.Windows.Forms.View.Details;
            this.listViewUVHDFiles.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewUVHDFiles_ColumnClick);
            this.listViewUVHDFiles.SelectedIndexChanged += new System.EventHandler(this.listViewUVHDFiles_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            columnHeader1.Tag = "";
            columnHeader1.Text = "UVHD file";
            columnHeader1.Width = 342;
            // 
            // columnHeader2
            // 
            columnHeader2.Tag = "DateTime";
            columnHeader2.Text = "Last change";
            columnHeader2.Width = 133;
            // 
            // columnHeader3
            // 
            columnHeader3.Tag = "";
            columnHeader3.Text = "Username";
            columnHeader3.Width = 161;
            // 
            // columnHeader4
            // 
            columnHeader4.Tag = "Numeric";
            columnHeader4.Text = "Size (MB)";
            // 
            // columnHeader5
            // 
            columnHeader5.Tag = "Numeric";
            columnHeader5.Text = "PartitionSize (MB)";
            columnHeader5.Width = 110;
            // 
            // columnHeader6
            // 
            columnHeader6.Tag = "Numeric";
            columnHeader6.Text = "NativeSize (MB)";
            columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            columnHeader6.Width = 100;
            // 
            // textBoxSearchUsername
            // 
            this.textBoxSearchUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSearchUsername.Location = new System.Drawing.Point(624, 25);
            this.textBoxSearchUsername.Name = "textBoxSearchUsername";
            this.textBoxSearchUsername.Size = new System.Drawing.Size(185, 22);
            this.textBoxSearchUsername.TabIndex = 1;
            this.textBoxSearchUsername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSearchUsername_KeyPress);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(621, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Search username:";
            // 
            // Sidder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 465);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxSearchUsername);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.buttonExpand);
            this.Controls.Add(this.listViewUVHDFiles);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.textBoxStatus);
            this.Controls.Add(this.textBoxFilePathUVHDCurrent);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.linkLabel);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.labelPathToUVHD);
            this.Controls.Add(this.textBoxFilePathUVHD);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(758, 504);
            this.Name = "Sidder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sidder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Sidder_FormClosing);
            this.Load += new System.EventHandler(this.Sidder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFilePathUVHD;
        private System.Windows.Forms.Label labelPathToUVHD;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.LinkLabel linkLabel;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.TextBox textBoxFilePathUVHDCurrent;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.ListView listViewUVHDFiles;
        private System.Windows.Forms.Button buttonExpand;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.TextBox textBoxSearchUsername;
        private System.Windows.Forms.Label label1;
    }
}

