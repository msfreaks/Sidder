using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SidderApp.Storages
{
    internal static class Config
    {
        public static ConfigStorage CurrentConfig { get; set; }

        static Config()
        {
            CurrentConfig = new ConfigStorage();
        }
    }

    internal enum UsernameFormatType
    {
        NTAccount = 0,
        UserPrincipalName = 1
    }

    internal enum ExportDividerType
    {
        Comma = 0,
        Semicolon = 1
    }

    internal enum ExportSizeType
    {
        Megabytes = 0,
        Bytes = 1
    }

    internal enum DiskProviderType
    {
        UserProfileDisk = 0,
        FSLogix = 1
    }

    internal class ConfigStorage : IDisposable
    {
        public PrincipalContext PrincipalContext { get; private set; }
        public string PathUVHD { get { return Properties.Settings.Default.userUVHDFilePath; } set { Properties.Settings.Default.userUVHDFilePath = value; } }
        public int ColumnWitdth1 { get { return Properties.Settings.Default.userColumn1; } set { Properties.Settings.Default.userColumn1 = value; } }
        public int ColumnWitdth2 { get { return Properties.Settings.Default.userColumn2; } set { Properties.Settings.Default.userColumn2 = value; } }
        public int ColumnWitdth3 { get { return Properties.Settings.Default.userColumn3; } set { Properties.Settings.Default.userColumn3 = value; } }
        public int ColumnWitdth4 { get { return Properties.Settings.Default.userColumn4; } set { Properties.Settings.Default.userColumn4 = value; } }
        public int ColumnWitdth5 { get { return Properties.Settings.Default.userColumn5; } set { Properties.Settings.Default.userColumn5 = value; } }
        public int ColumnWitdth6 { get { return Properties.Settings.Default.userColumn6; } set { Properties.Settings.Default.userColumn6 = value; } }
        public int MainFormWidth { get { return Properties.Settings.Default.sidderWidth; } set { Properties.Settings.Default.sidderWidth = value; } }
        public int MainFormHeight { get { return Properties.Settings.Default.sidderHeight; } set { Properties.Settings.Default.sidderHeight = value; } }
        public UsernameFormatType UsernameFormat { get { return (Properties.Settings.Default.resolveTypeSID == 0) ? UsernameFormatType.NTAccount : UsernameFormatType.UserPrincipalName; } set { Properties.Settings.Default.resolveTypeSID = (byte)(value == UsernameFormatType.NTAccount ? 0 : 1); } }
        public ExportDividerType ExportDivider { get { return (Properties.Settings.Default.exportDividerType == 0) ? ExportDividerType.Comma : ExportDividerType.Semicolon; } set { Properties.Settings.Default.exportDividerType = (byte)(value == ExportDividerType.Comma ? 0 : 1); } }
        public ExportSizeType ExportSize { get { return (Properties.Settings.Default.exportSizeType == 0) ? ExportSizeType.Megabytes : ExportSizeType.Bytes; } set { Properties.Settings.Default.exportSizeType = (byte)(value == ExportSizeType.Megabytes ? 0 : 1); } }
        public DiskProviderType DiskProvider { get { return (Properties.Settings.Default.diskProviderType == 0) ? DiskProviderType.UserProfileDisk : DiskProviderType.FSLogix; } set { Properties.Settings.Default.diskProviderType = (byte)(value == DiskProviderType.UserProfileDisk ? 0 : 1); } }

        public ConfigStorage()
        {
            try
            {
                this.PrincipalContext = new PrincipalContext(ContextType.Domain);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Could not initialize PrincipalContext. Sidder will close now!{Environment.NewLine}{Environment.NewLine}Exception:{Environment.NewLine}{e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                throw e;
            }
        }

        public void Dispose()
        {
            Properties.Settings.Default.Save();
        }
    }
}
