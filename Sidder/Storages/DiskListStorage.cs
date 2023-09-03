using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using SidderApp.Exceptions;
using SidderApp.Parser;

namespace SidderApp.Storages
{
    internal class DiskListStorage
    {
        public List<DiskListEntry> DiskList { get; private set; }

        public DiskListStorage()
        {
            this.DiskList = new List<DiskListEntry>();
        }

        public void UpdateListUPD(string dirPath)
        {
            if (Directory.Exists(dirPath))
            {
                var directory = new DirectoryInfo(dirPath);
                var files = directory.GetFiles("UVHD-*.vhdx");

                if (files.Length > 0)
                {
                    UpdateList(files);
                }
                else throw new NoFilesFoundException();
            }
            else throw new DirectoryNotFoundException();
        }

        private void UpdateList(FileInfo[] files)
        {
            this.DiskList.Clear();

            foreach (var file in files)
            {
                this.DiskList.Add(new DiskListEntry(file.FullName));
            }
        }

        public bool ExportCSV(string fileName)
        {
            try
            {
                using (var fileHandle = File.CreateText(fileName))
                {
                    var separator = Config.CurrentConfig.ExportDivider == ExportDividerType.Comma ? "," : ";";
                    var fields = new string[] { "uvhd file", "last change", "username", "size", "partition size", "native size", "full filepath" };

                    fileHandle.WriteLine(String.Join(separator, fields));

                    foreach (var entry in this.DiskList)
                    {
                        var data = new string[] { entry.DiskName, entry.DiskFileLastChange.ToString(), entry.DiskUsername,
                                                  Config.CurrentConfig.ExportSize == ExportSizeType.Megabytes ? entry.DiskFileSizeMB.ToString() : entry.DiskFileSize.ToString(),
                                                  Config.CurrentConfig.ExportSize == ExportSizeType.Megabytes ? entry.DiskPartitionSizeMB.ToString() : entry.DiskPartitionSize.ToString(),
                                                  Config.CurrentConfig.ExportSize == ExportSizeType.Megabytes ? entry.DiskNativeSizeMB.ToString() : entry.DiskNativeSize.ToString(),
                                                  entry.DiskFullName };

                        fileHandle.WriteLine(String.Join(separator, data));
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        internal class DiskListEntry
        {
            private FileInfo DiskFileInfo { get; set; }
            private VHDXParser VHDXParser { get; set; }

            public string DiskFullName { get { return this.DiskFileInfo.FullName; } }
            public string DiskName { get { return this.DiskFileInfo.Name; } }
            public bool DiskInUse { get { return IsFileLocked(this.DiskFileInfo); } }
            public DateTime DiskFileLastChange { get { return this.DiskFileInfo.LastWriteTime; } }
            public string DiskUsername { get { return ConvertUVHDtoUsername(this.DiskFileInfo.Name); } }
            public long DiskFileSize { get { return this.DiskFileInfo.Length; } }
            public long DiskFileSizeMB { get { return this.DiskFileSize / 1024 / 1024; } }
            public ulong DiskPartitionSize { get { return this.VHDXParser.FirstPartitionSize; } }
            public ulong DiskPartitionSizeMB { get { return this.DiskPartitionSize / 1024 / 1024; } }
            public ulong DiskNativeSize { get { return this.VHDXParser.NativeDiskSize; } set { { this.VHDXParser.SetNativeDiskSize(value); } } }
            public ulong DiskNativeSizeMB { get { return this.DiskNativeSize / 1024 / 1024; } set { { this.DiskNativeSize = value * 1024 * 1024; } } }

            public DiskListEntry(string fileName)
            {
                if (File.Exists(fileName))
                {
                    this.DiskFileInfo = new FileInfo(fileName);
                    this.VHDXParser = new VHDXParser(fileName);
                }
            }

            private bool IsFileLocked(FileInfo file)
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
                    if (stream != null) stream.Close();
                }

                return false;
            }

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
                    else if (fileName == "UVHD-TEMPLATE.VHDX")
                    {
                        returnValue = "## UPD template file";
                    }
                    else
                    {
                        var sidString = fileName.Substring(5, fileName.Length - 10);

                        returnValue = Usernames.ResolveSID(sidString);
                    }

                }
                catch
                {
                    returnValue = "SID Resolve Error";
                }

                return returnValue;
            }
        }
    }
}
