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
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.textBoxFilePathUVHD = new System.Windows.Forms.TextBox();
            this.labelPathToUVHD = new System.Windows.Forms.Label();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.linkLabel = new System.Windows.Forms.LinkLabel();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.textBoxFilePathUVHDCurrent = new System.Windows.Forms.TextBox();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.buttonDelete = new System.Windows.Forms.Button();
            this.listViewUVHDFiles = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.textBoxFilePathUVHD.Size = new System.Drawing.Size(867, 22);
            this.textBoxFilePathUVHD.TabIndex = 1;
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
            // buttonBrowse
            // 
            this.buttonBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowse.Image = global::SidderApp.Properties.Resources.folder;
            this.buttonBrowse.Location = new System.Drawing.Point(919, 25);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(28, 22);
            this.buttonBrowse.TabIndex = 1;
            this.toolTip.SetToolTip(this.buttonBrowse, "Browse for a folder");
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // linkLabel
            // 
            this.linkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel.AutoSize = true;
            this.linkLabel.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(133)))), ((int)(((byte)(133)))));
            this.linkLabel.Location = new System.Drawing.Point(809, 447);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(149, 12);
            this.linkLabel.TabIndex = 4;
            this.linkLabel.TabStop = true;
            this.linkLabel.Text = "2015-2020 Arjan Mensch - msfreaks";
            this.linkLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.toolTip.SetToolTip(this.linkLabel, "About");
            this.linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRefresh.Image = global::SidderApp.Properties.Resources.sync;
            this.buttonRefresh.Location = new System.Drawing.Point(885, 25);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(28, 22);
            this.buttonRefresh.TabIndex = 0;
            this.toolTip.SetToolTip(this.buttonRefresh, "Refresh");
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
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
            this.textBoxStatus.Size = new System.Drawing.Size(866, 22);
            this.textBoxStatus.TabIndex = 7;
            this.textBoxStatus.TabStop = false;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.Enabled = false;
            this.buttonDelete.Image = global::SidderApp.Properties.Resources.delete;
            this.buttonDelete.Location = new System.Drawing.Point(919, 422);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(28, 22);
            this.buttonDelete.TabIndex = 3;
            this.toolTip.SetToolTip(this.buttonDelete, "Delete selected items");
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // listViewUVHDFiles
            // 
            this.listViewUVHDFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewUVHDFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listViewUVHDFiles.FullRowSelect = true;
            this.listViewUVHDFiles.HideSelection = false;
            this.listViewUVHDFiles.Location = new System.Drawing.Point(12, 55);
            this.listViewUVHDFiles.Name = "listViewUVHDFiles";
            this.listViewUVHDFiles.Size = new System.Drawing.Size(935, 354);
            this.listViewUVHDFiles.SmallImageList = this.imageList;
            this.listViewUVHDFiles.TabIndex = 8;
            this.listViewUVHDFiles.UseCompatibleStateImageBehavior = false;
            this.listViewUVHDFiles.View = System.Windows.Forms.View.Details;
            this.listViewUVHDFiles.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewUVHDFiles_ColumnClick);
            this.listViewUVHDFiles.SelectedIndexChanged += new System.EventHandler(this.listViewUVHDFiles_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Tag = "";
            this.columnHeader1.Text = "UVHD file";
            this.columnHeader1.Width = 342;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Tag = "DateTime";
            this.columnHeader2.Text = "Last change";
            this.columnHeader2.Width = 133;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Tag = "";
            this.columnHeader3.Text = "Username";
            this.columnHeader3.Width = 161;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Tag = "Numeric";
            this.columnHeader4.Text = "Size (MB)";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Tag = "Numeric";
            this.columnHeader5.Text = "PartitionSize (MB)";
            this.columnHeader5.Width = 110;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Tag = "Numeric";
            this.columnHeader6.Text = "NativeSize (MB)";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader6.Width = 100;
            // 
            // Sidder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 465);
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
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}

