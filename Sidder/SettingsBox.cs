using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SidderApp
{
    partial class SettingsBox : Form
    {
        private Button buttonCancel;
        private Button buttonOK;
        private ImageList imageList;
        public RadioButton radioButtonNTAccount;
        private GroupBox groupBoxSIDResolve;
        public RadioButton radioButtonUPN;
        private GroupBox groupBoxCSVdivider;
        public RadioButton radioButtonCSVSemicolon;
        public RadioButton radioButtonCSVComma;
        private GroupBox groupBoxCSVsizeformat;
        public RadioButton radioButtonCSVSizeMB;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        public RadioButton radioButtonCSVSizeBytes;
        private System.ComponentModel.IContainer components;
    
        public SettingsBox()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsBox));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.radioButtonNTAccount = new System.Windows.Forms.RadioButton();
            this.groupBoxSIDResolve = new System.Windows.Forms.GroupBox();
            this.radioButtonUPN = new System.Windows.Forms.RadioButton();
            this.groupBoxCSVdivider = new System.Windows.Forms.GroupBox();
            this.radioButtonCSVSemicolon = new System.Windows.Forms.RadioButton();
            this.radioButtonCSVComma = new System.Windows.Forms.RadioButton();
            this.groupBoxCSVsizeformat = new System.Windows.Forms.GroupBox();
            this.radioButtonCSVSizeBytes = new System.Windows.Forms.RadioButton();
            this.radioButtonCSVSizeMB = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBoxSIDResolve.SuspendLayout();
            this.groupBoxCSVdivider.SuspendLayout();
            this.groupBoxCSVsizeformat.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
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
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(258, 230);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(177, 230);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // radioButtonNTAccount
            // 
            this.radioButtonNTAccount.AutoSize = true;
            this.radioButtonNTAccount.Location = new System.Drawing.Point(6, 21);
            this.radioButtonNTAccount.Name = "radioButtonNTAccount";
            this.radioButtonNTAccount.Size = new System.Drawing.Size(222, 17);
            this.radioButtonNTAccount.TabIndex = 2;
            this.radioButtonNTAccount.TabStop = true;
            this.radioButtonNTAccount.Text = "NT account name (DOMAIN\\username)";
            this.radioButtonNTAccount.UseVisualStyleBackColor = true;
            // 
            // groupBoxSIDResolve
            // 
            this.groupBoxSIDResolve.Controls.Add(this.radioButtonUPN);
            this.groupBoxSIDResolve.Controls.Add(this.radioButtonNTAccount);
            this.groupBoxSIDResolve.Location = new System.Drawing.Point(10, 21);
            this.groupBoxSIDResolve.Name = "groupBoxSIDResolve";
            this.groupBoxSIDResolve.Size = new System.Drawing.Size(305, 70);
            this.groupBoxSIDResolve.TabIndex = 1;
            this.groupBoxSIDResolve.TabStop = false;
            this.groupBoxSIDResolve.Text = "Username format";
            // 
            // radioButtonUPN
            // 
            this.radioButtonUPN.AutoSize = true;
            this.radioButtonUPN.Location = new System.Drawing.Point(6, 44);
            this.radioButtonUPN.Name = "radioButtonUPN";
            this.radioButtonUPN.Size = new System.Drawing.Size(225, 17);
            this.radioButtonUPN.TabIndex = 3;
            this.radioButtonUPN.TabStop = true;
            this.radioButtonUPN.Text = "User principal name (username@suffix)";
            this.radioButtonUPN.UseVisualStyleBackColor = true;
            // 
            // groupBoxCSVdivider
            // 
            this.groupBoxCSVdivider.Controls.Add(this.radioButtonCSVSemicolon);
            this.groupBoxCSVdivider.Controls.Add(this.radioButtonCSVComma);
            this.groupBoxCSVdivider.Location = new System.Drawing.Point(6, 21);
            this.groupBoxCSVdivider.Name = "groupBoxCSVdivider";
            this.groupBoxCSVdivider.Size = new System.Drawing.Size(153, 70);
            this.groupBoxCSVdivider.TabIndex = 4;
            this.groupBoxCSVdivider.TabStop = false;
            this.groupBoxCSVdivider.Text = "CSV divider";
            // 
            // radioButtonCSVSemicolon
            // 
            this.radioButtonCSVSemicolon.AutoSize = true;
            this.radioButtonCSVSemicolon.Location = new System.Drawing.Point(6, 44);
            this.radioButtonCSVSemicolon.Name = "radioButtonCSVSemicolon";
            this.radioButtonCSVSemicolon.Size = new System.Drawing.Size(78, 17);
            this.radioButtonCSVSemicolon.TabIndex = 3;
            this.radioButtonCSVSemicolon.TabStop = true;
            this.radioButtonCSVSemicolon.Text = "Semicolon";
            this.radioButtonCSVSemicolon.UseVisualStyleBackColor = true;
            // 
            // radioButtonCSVComma
            // 
            this.radioButtonCSVComma.AutoSize = true;
            this.radioButtonCSVComma.Location = new System.Drawing.Point(6, 21);
            this.radioButtonCSVComma.Name = "radioButtonCSVComma";
            this.radioButtonCSVComma.Size = new System.Drawing.Size(63, 17);
            this.radioButtonCSVComma.TabIndex = 2;
            this.radioButtonCSVComma.TabStop = true;
            this.radioButtonCSVComma.Text = "Comma";
            this.radioButtonCSVComma.UseVisualStyleBackColor = true;
            // 
            // groupBoxCSVsizeformat
            // 
            this.groupBoxCSVsizeformat.Controls.Add(this.radioButtonCSVSizeBytes);
            this.groupBoxCSVsizeformat.Controls.Add(this.radioButtonCSVSizeMB);
            this.groupBoxCSVsizeformat.Location = new System.Drawing.Point(165, 21);
            this.groupBoxCSVsizeformat.Name = "groupBoxCSVsizeformat";
            this.groupBoxCSVsizeformat.Size = new System.Drawing.Size(150, 70);
            this.groupBoxCSVsizeformat.TabIndex = 5;
            this.groupBoxCSVsizeformat.TabStop = false;
            this.groupBoxCSVsizeformat.Text = "CSV size format";
            // 
            // radioButtonCSVSizeBytes
            // 
            this.radioButtonCSVSizeBytes.AutoSize = true;
            this.radioButtonCSVSizeBytes.Location = new System.Drawing.Point(6, 44);
            this.radioButtonCSVSizeBytes.Name = "radioButtonCSVSizeBytes";
            this.radioButtonCSVSizeBytes.Size = new System.Drawing.Size(51, 17);
            this.radioButtonCSVSizeBytes.TabIndex = 4;
            this.radioButtonCSVSizeBytes.TabStop = true;
            this.radioButtonCSVSizeBytes.Text = "Bytes";
            this.radioButtonCSVSizeBytes.UseVisualStyleBackColor = true;
            // 
            // radioButtonCSVSizeMB
            // 
            this.radioButtonCSVSizeMB.AutoSize = true;
            this.radioButtonCSVSizeMB.Location = new System.Drawing.Point(6, 21);
            this.radioButtonCSVSizeMB.Name = "radioButtonCSVSizeMB";
            this.radioButtonCSVSizeMB.Size = new System.Drawing.Size(41, 17);
            this.radioButtonCSVSizeMB.TabIndex = 2;
            this.radioButtonCSVSizeMB.TabStop = true;
            this.radioButtonCSVSizeMB.Text = "MB";
            this.radioButtonCSVSizeMB.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBoxCSVdivider);
            this.groupBox2.Controls.Add(this.groupBoxCSVsizeformat);
            this.groupBox2.Location = new System.Drawing.Point(12, 119);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(321, 100);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Export settings";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBoxSIDResolve);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(321, 101);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Display settings";
            // 
            // SettingsBox
            // 
            this.ClientSize = new System.Drawing.Size(345, 261);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.groupBoxSIDResolve.ResumeLayout(false);
            this.groupBoxSIDResolve.PerformLayout();
            this.groupBoxCSVdivider.ResumeLayout(false);
            this.groupBoxCSVdivider.PerformLayout();
            this.groupBoxCSVsizeformat.ResumeLayout(false);
            this.groupBoxCSVsizeformat.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
