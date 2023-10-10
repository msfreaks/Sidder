using SidderApp.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SidderApp.Parser
{
    internal sealed class VHDXParser
    {
        private string _filename { get; set; }
        private ulong _blockAllocationTableHeaderEntry { get; set; }
        private ulong _regionTableMetadataHeaderEntry { get; set; }
        private ulong _posBlockAllocationTable { get; set; }
        private uint _lenBlockAllocationTable { get; set; }
        private ulong _posVDMetadataheader { get; set; }
        private ulong _posVDFileParametersOffsetEntry { get; set; }
        private ulong _posVDSizeOffsetEntry { get; set; }
        private ulong _posVDFileParametersEntry { get; set; }
        private uint _VDBlockSize { get; set; }
        private ulong _posVDSizeEntry { get; set; }
        private ulong _posMBR { get { return 0x400000; /* SearchSignatur(binVHDX.BaseStream, new byte[] { 0x33, 0xC0, 0x8E, 0xD0, 0xBC, 0x00, 0x7C }) - More accurate but way slower (search for MBR code)*/ } }
        private ulong _posMBRPartitionTable { get { return this._posMBR + 446; /* Should work on all default VHDXs with normal master boot record (MBR + partition table offset) */ } }
        private ulong _posPartitionSectorCount { get; set; }
        public ulong NativeDiskSize { get { return GetNativeDiskSize(); } }
        public ulong NativeUsedDiskSize { get { return GetNativeUsedDiskSize(); } }
        public ulong FirstPartitionSize { get { return GetFirstPartitionSize(); } }

        public VHDXParser(string filename)
        {
            this._filename = filename;
            this._blockAllocationTableHeaderEntry = 0;
            this._regionTableMetadataHeaderEntry = 0;
            this._posBlockAllocationTable = 0;
            this._lenBlockAllocationTable = 0;
            this._posVDMetadataheader = 0;
            this._posVDFileParametersOffsetEntry = 0;
            this._posVDSizeOffsetEntry = 0;
            this._posVDFileParametersEntry = 0;
            this._VDBlockSize = 0;
            this._posVDSizeEntry = 0;
            this._posPartitionSectorCount = 0;

            if (!ParseVHDX()) throw new VhdxParseException();
        }

        private bool ParseVHDX()
        {
            try
            {
                using (var fileVHDX = File.Open(this._filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (var binVHDX = new BinaryReader(fileVHDX))
                    {
                        // Region GUID for BAT => 2DC27766-F623-4200-9D64-115E9BFD4A08
                        this._blockAllocationTableHeaderEntry = SearchSignatur(binVHDX.BaseStream, new byte[] { 0x66, 0x77, 0xC2, 0x2D, 0x23, 0xF6, 0x00, 0x42, 0x9D, 0x64, 0x11, 0x5E, 0x9B, 0xFD, 0x4A, 0x08 }) + 16;

                        binVHDX.BaseStream.Seek((long)this._blockAllocationTableHeaderEntry, SeekOrigin.Begin);
                        this._posBlockAllocationTable = binVHDX.ReadUInt64();
                        this._lenBlockAllocationTable = binVHDX.ReadUInt32();

                        // Region GUID for Metadata region => 8B7CA206-4790-4B9A-B8FE-575F050F886E
                        this._regionTableMetadataHeaderEntry = SearchSignatur(binVHDX.BaseStream, new byte[] { 0x06, 0xA2, 0x7C, 0x8B, 0x90, 0x47, 0x9A, 0x4B, 0xB8, 0xFE, 0x57, 0x5F, 0x05, 0x0F, 0x88, 0x6E }) + 16;

                        binVHDX.BaseStream.Seek((long)this._regionTableMetadataHeaderEntry, SeekOrigin.Begin);
                        this._posVDMetadataheader = binVHDX.ReadUInt64();

                        // Metadata GUID for File Parameters => CAA16737-FA36-4D43-B3B6-33F0AA44E76B
                        this._posVDFileParametersOffsetEntry = SearchSignatur(binVHDX.BaseStream, new byte[] { 0x37, 0x67, 0xA1, 0xCA, 0x36, 0xFA, 0x43, 0x4D, 0xB3, 0xB6, 0x33, 0xF0, 0xAA, 0x44, 0xE7, 0x6B }, this._posVDMetadataheader) + 16;

                        binVHDX.BaseStream.Seek((long)this._posVDFileParametersOffsetEntry, SeekOrigin.Begin);
                        this._posVDFileParametersEntry = this._posVDMetadataheader + binVHDX.ReadUInt32();

                        binVHDX.BaseStream.Seek((long)this._posVDFileParametersEntry, SeekOrigin.Begin);
                        this._VDBlockSize = binVHDX.ReadUInt32();

                        // Metadata GUID for Virtual Disk Size => 2FA54224-CD1B-4876-B211-5DBED83BF4B8
                        this._posVDSizeOffsetEntry = SearchSignatur(binVHDX.BaseStream, new byte[] { 0x24, 0x42, 0xA5, 0x2F, 0x1B, 0xCD, 0x76, 0x48, 0xB2, 0x11, 0x5D, 0xBE, 0xD8, 0x3B, 0xF4, 0xB8 }, this._posVDMetadataheader) + 16;

                        binVHDX.BaseStream.Seek((long)this._posVDSizeOffsetEntry, SeekOrigin.Begin);
                        this._posVDSizeEntry = this._posVDMetadataheader + binVHDX.ReadUInt32();

                        this._posPartitionSectorCount = this._posMBRPartitionTable + 12;

                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        private ulong GetNativeDiskSize()
        {
            try
            {
                using (var fileVHDX = File.Open(this._filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (var binVHDX = new BinaryReader(fileVHDX))
                    {
                        if (this._posVDSizeEntry != 0)
                        {
                            binVHDX.BaseStream.Seek((long)this._posVDSizeEntry, SeekOrigin.Begin);
                            var virtualDiskSize = binVHDX.ReadUInt64();

                            return virtualDiskSize;
                        }
                        else return 0;
                    }
                }
            }
            catch
            {
                return 0;
            }
        }

        public bool SetNativeDiskSize(ulong newSize)
        {
            try
            {
                using (var fileVHDX = File.Open(this._filename, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    using (var binVHDX = new BinaryReader(fileVHDX))
                    {
                        using (var binVHDXw = new BinaryWriter(fileVHDX))
                        {
                            if (this._posVDSizeEntry != 0)
                            {
                                binVHDXw.BaseStream.Seek((long)this._posVDSizeEntry, SeekOrigin.Begin);
                                binVHDXw.Write(newSize);
                            }
                            else return false;
                        }

                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        private ulong GetNativeUsedDiskSize()
        {
            try
            {
                using (var fileVHDX = File.Open(this._filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (var binVHDX = new BinaryReader(fileVHDX))
                    {
                        if (this._posBlockAllocationTable != 0 && this._lenBlockAllocationTable != 0 && this._VDBlockSize != 0)
                        {
                            var blocksUsed = 0ul;

                            binVHDX.BaseStream.Seek((long)this._posBlockAllocationTable, SeekOrigin.Begin);

                            for (int i = 0; i < (this._lenBlockAllocationTable / 8); i++)
                            {
                                var batEntry = binVHDX.ReadUInt64();

                                if ((batEntry & 0x7) == 6)
                                {
                                    blocksUsed++;
                                }
                            }

                            return blocksUsed * this._VDBlockSize;
                        }
                        else return 0;
                    }
                }
            }
            catch
            {
                return 0;
            }
        }

        private ulong GetFirstPartitionSize()
        {
            try
            {
                using (var fileVHDX = File.Open(this._filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (var binVHDX = new BinaryReader(fileVHDX))
                    {
                        if (this._posPartitionSectorCount != 0)
                        {
                            binVHDX.BaseStream.Seek((long)this._posPartitionSectorCount, SeekOrigin.Begin);
                            var sectorCount = binVHDX.ReadUInt32();

                            return (ulong)sectorCount * 512u;
                        }
                        else return 0;
                    }
                }
            }
            catch
            {
                return 0;
            }
        }

        private ulong SearchSignatur(Stream haystack, byte[] needle, ulong seekStart = 0)
        {
            haystack.Seek((long)seekStart, SeekOrigin.Begin);

            int b;
            long i = 0;
            while ((b = haystack.ReadByte()) != -1)
            {
                if (b == needle[i++])
                {
                    if (i == needle.Length)
                        return (ulong)(haystack.Position - needle.Length);
                }
                else
                    i = b == needle[0] ? 1 : 0;
            }

            return 0;
        }
    }
}
