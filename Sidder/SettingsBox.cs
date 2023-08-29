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
            this.groupBoxSIDResolve.SuspendLayout();
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
            this.buttonCancel.Location = new System.Drawing.Point(258, 102);
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
            this.buttonOK.Location = new System.Drawing.Point(177, 102);
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
            this.groupBoxSIDResolve.Location = new System.Drawing.Point(12, 12);
            this.groupBoxSIDResolve.Name = "groupBoxSIDResolve";
            this.groupBoxSIDResolve.Size = new System.Drawing.Size(239, 70);
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
            // SettingsBox
            // 
            this.ClientSize = new System.Drawing.Size(345, 133);
            this.Controls.Add(this.groupBoxSIDResolve);
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
            this.ResumeLayout(false);

        }
    }
}
