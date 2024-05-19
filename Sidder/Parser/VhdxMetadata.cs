using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SidderApp.Exceptions;
using SidderApp.Extensions;

namespace SidderApp.Parser
{
    internal class VhdxMetadata
    {
        public Int64 VirtualDiskSize { get { return MetadataItemData.VirtualDiskSize.VDiskSize; } }
        public uint BlockSize { get { return MetadataItemData.FileParameters.BlockSize; } }
        public Int64 BlockAllocationTableOffset { get { return Offsets.BlockAllocationTableStructure; } }
        public uint BlockAllocationTableSize { get { return Sizes.BlockAllocationTableStructure; } }
        public int PayloadBlockCount { get { return (int)Math.Ceiling((decimal)MetadataItemData.VirtualDiskSize.VDiskSize / (decimal)MetadataItemData.FileParameters.BlockSize); } }
        public int ChunkRatio { get { return (int)Math.Ceiling((8388608m * (decimal)MetadataItemData.LogicalSectorSize.LSectorSize) / (decimal)MetadataItemData.FileParameters.BlockSize); } }
        public int SectorBitmapBlockCount { get { return (int)Math.Ceiling((decimal)PayloadBlockCount / (decimal)ChunkRatio); } }
        public int TotalBlockAllocationTableEntryCount { get { return (int)(PayloadBlockCount + Math.Floor((decimal)(PayloadBlockCount - 1) / (decimal)ChunkRatio)); } }

        private Stream BaseStream { get; set; }

        private static class FixedGuids
        {
            public static class RegionEntryType
            {
                public static Guid BlockAllocationTable { get { return Guid.Parse("2DC27766-F623-4200-9D64-115E9BFD4A08"); } }
                public static Guid MetadataRegion { get { return Guid.Parse("8B7CA206-4790-4B9A-B8FE-575F050F886E"); } }
            }

            public static class MetadataItemType
            {
                public static Guid FileParameters { get { return Guid.Parse("CAA16737-FA36-4D43-B3B6-33F0AA44E76B"); } }
                public static Guid VirtualDiskSize { get { return Guid.Parse("2FA54224-CD1B-4876-B211-5DBED83BF4B8"); } }
                public static Guid VirtualDiskID { get { return Guid.Parse("BECA12AB-B2E6-4523-93EF-C309E000C746"); } }
                public static Guid LogicalSectorSize { get { return Guid.Parse("8141BF1D-A96F-4709-BA47-F233A8FAAB5F"); } }
                public static Guid PhysicalSectorSize { get { return Guid.Parse("CDA348C7-445D-4471-9CC9-E9885251C556"); } }
                public static Guid ParentLocator { get { return Guid.Parse("A8D35F2D-B30B-454D-ABF7-D3D84834AB0C"); } }
            }
        }

        private static class FixedOffsets
        {
            public static uint HeaderSection { get { return 0x00; } }
            public static uint FirstHeader { get { return 0x10000; } }
            public static uint SecondHeader { get { return 0x20000; } }
            public static uint HeaderSequenceNumber { get { return 8; } }
            public static uint HeaderLogLength { get { return 68; } }
            public static uint HeaderLogOffset { get { return 72; } }
            public static uint FirstRegionTable { get { return 0x30000; } }
            public static uint SecondRegionTable { get { return 0x40000; } }
            public static uint RegionTableEntryCount { get { return 8; } }
            public static uint MetadataRegionTableEntryCount { get { return 10; } }
        }

        private static class FixedSizes
        {
            public static uint HeaderSection { get { return 0x100000; } }
            public static uint RegionTableHeader { get { return 16; } }
            public static uint RegionTableEntry { get { return 32; } }
            public static uint MetadataTableHeader { get { return 32; } }
            public static uint MetadataTableEntry { get { return 32; } }
        }

        private static class Offsets
        {
            public static uint ActiveHeader { get; set; }
            public static Int64 LogStructure { get; set; }
            public static Int64 MetadataRegionStructure { get; set; }
            public static Int64 BlockAllocationTableStructure { get; set; }
        }

        private static class Sizes
        {
            public static uint LogStructure { get; set; }
            public static uint MetadataRegionStructure { get; set; }
            public static uint BlockAllocationTableStructure { get; set; }
        }

        private static class MetadataItemData
        {
            public static class FileParameters
            {
                public static uint BlockSize { get; set; }
            }

            public static class VirtualDiskSize
            {
                public static Int64 VDiskSize { get; set; }
            }

            public static class VirtualDiskID
            {
                public static Guid VDiskID { get; set; }
            }

            public static class LogicalSectorSize
            {
                public static uint LSectorSize { get; set; }
            }

            public static class PhysicalSectorSize
            {
                public static uint PSectorSize { get; set; }
            }
        }

        public VhdxMetadata(Stream fileStream)
        {
            if (fileStream != null)
            {
                BaseStream = fileStream;

                ParseVHDX();
            }
            else throw new InvalidDataException();
        }

        private void ParseVHDX()
        {
            using (var binVHDX = new BinaryReader(BaseStream, Encoding.UTF8, true))
            {
                // VHDX File signature 0x7668647866696C65  at offset 0x00
                binVHDX.BaseStream.Seek(0, SeekOrigin.Begin);
                if (!binVHDX.ReadBytes(8).SequenceEqual(new byte[8] { 0x76, 0x68, 0x64, 0x78, 0x66, 0x69, 0x6C, 0x65 })) throw new InvalidVhdxFileException();

                // First header signature 0x68656164 at offset 0x10000
                binVHDX.BaseStream.Seek(FixedOffsets.FirstHeader, SeekOrigin.Begin);
                if (!binVHDX.ReadBytes(4).SequenceEqual(new byte[4] { 0x68, 0x65, 0x61, 0x64 })) throw new InvalidVhdxFileException();

                // Second header signature 0x68656164 at offset 0x20000
                binVHDX.BaseStream.Seek(FixedOffsets.SecondHeader, SeekOrigin.Begin);
                if (!binVHDX.ReadBytes(4).SequenceEqual(new byte[4] { 0x68, 0x65, 0x61, 0x64 })) throw new InvalidVhdxFileException();

                // First region table signature 0x72656769 at offset 0x30000
                binVHDX.BaseStream.Seek(FixedOffsets.FirstRegionTable, SeekOrigin.Begin);
                if (!binVHDX.ReadBytes(4).SequenceEqual(new byte[4] { 0x72, 0x65, 0x67, 0x69 })) throw new InvalidVhdxFileException();

                // Second region table signature 0x72656769 at offset 0x40000
                binVHDX.BaseStream.Seek(FixedOffsets.SecondRegionTable, SeekOrigin.Begin);
                if (!binVHDX.ReadBytes(4).SequenceEqual(new byte[4] { 0x72, 0x65, 0x67, 0x69 })) throw new InvalidVhdxFileException();

                // Determine active Header
                binVHDX.BaseStream.Seek(FixedOffsets.FirstHeader + FixedOffsets.HeaderSequenceNumber, SeekOrigin.Begin);
                var firstHeaderSeq = binVHDX.ReadUInt64();

                binVHDX.BaseStream.Seek(FixedOffsets.SecondHeader + FixedOffsets.HeaderSequenceNumber, SeekOrigin.Begin);
                var secondHeaderSeq = binVHDX.ReadUInt64();

                Offsets.ActiveHeader = (firstHeaderSeq > secondHeaderSeq) ? FixedOffsets.FirstHeader : FixedOffsets.SecondHeader;

                // Determine log section size
                binVHDX.BaseStream.Seek(Offsets.ActiveHeader + FixedOffsets.HeaderLogLength, SeekOrigin.Begin);
                Sizes.LogStructure = binVHDX.ReadUInt32();

                // Determine log section offset
                binVHDX.BaseStream.Seek(Offsets.ActiveHeader + FixedOffsets.HeaderLogOffset, SeekOrigin.Begin);
                Offsets.LogStructure = binVHDX.ReadInt64();

                // Parse region table
                binVHDX.BaseStream.Seek(FixedOffsets.FirstRegionTable + FixedOffsets.RegionTableEntryCount, SeekOrigin.Begin);
                var regionTableEntryCount = binVHDX.ReadUInt32();

                if (regionTableEntryCount > 2047) throw new InvalidVhdxFileException();

                for (var i = 0; i < regionTableEntryCount; i++)
                {
                    binVHDX.BaseStream.Seek(FixedOffsets.FirstRegionTable + FixedSizes.RegionTableHeader + (FixedSizes.RegionTableEntry * i), SeekOrigin.Begin);
                    var entrySequence = binVHDX.ReadGuid();

                    if (entrySequence.Equals(FixedGuids.RegionEntryType.BlockAllocationTable))
                    {
                        // BAT
                        Offsets.BlockAllocationTableStructure = binVHDX.ReadInt64();
                        Sizes.BlockAllocationTableStructure += binVHDX.ReadUInt32();

                        continue;
                    }

                    if (entrySequence.Equals(FixedGuids.RegionEntryType.MetadataRegion))
                    {
                        // Metadata region
                        Offsets.MetadataRegionStructure = binVHDX.ReadInt64();
                        Sizes.MetadataRegionStructure += binVHDX.ReadUInt32();

                        continue;
                    }
                }

                // Parse metadata region table
                binVHDX.BaseStream.Seek(Offsets.MetadataRegionStructure, SeekOrigin.Begin);
                if (!binVHDX.ReadBytes(8).SequenceEqual(new byte[8] { 0x6D, 0x65, 0x74, 0x61, 0x64, 0x61, 0x74, 0x61 })) throw new InvalidVhdxFileException();

                binVHDX.BaseStream.Seek(Offsets.MetadataRegionStructure + FixedOffsets.MetadataRegionTableEntryCount, SeekOrigin.Begin);
                var metadataRegionTableEntryCount = binVHDX.ReadUInt16();

                if (metadataRegionTableEntryCount > 2047) throw new InvalidVhdxFileException();

                for (var i = 0; i < metadataRegionTableEntryCount; i++)
                {
                    binVHDX.BaseStream.Seek(Offsets.MetadataRegionStructure + FixedSizes.MetadataTableHeader + (FixedSizes.MetadataTableEntry * i), SeekOrigin.Begin);
                    var itemID = binVHDX.ReadGuid();
                    var itemOffset = binVHDX.ReadUInt32();
                    var itemLength = binVHDX.ReadUInt32();

                    if (itemLength == 0 && itemOffset == 0) continue; // metadata item present but empty

                    if (itemID.Equals(FixedGuids.MetadataItemType.FileParameters))
                    {
                        binVHDX.BaseStream.Seek(Offsets.MetadataRegionStructure + itemOffset, SeekOrigin.Begin);
                        MetadataItemData.FileParameters.BlockSize = binVHDX.ReadUInt32();

                        continue;
                    }

                    if (itemID.Equals(FixedGuids.MetadataItemType.VirtualDiskSize))
                    {
                        binVHDX.BaseStream.Seek(Offsets.MetadataRegionStructure + itemOffset, SeekOrigin.Begin);
                        MetadataItemData.VirtualDiskSize.VDiskSize = binVHDX.ReadInt64();

                        continue;
                    }

                    if (itemID.Equals(FixedGuids.MetadataItemType.VirtualDiskID))
                    {
                        binVHDX.BaseStream.Seek(Offsets.MetadataRegionStructure + itemOffset, SeekOrigin.Begin);
                        MetadataItemData.VirtualDiskID.VDiskID = binVHDX.ReadGuid();

                        continue;
                    }

                    if (itemID.Equals(FixedGuids.MetadataItemType.LogicalSectorSize))
                    {
                        binVHDX.BaseStream.Seek(Offsets.MetadataRegionStructure + itemOffset, SeekOrigin.Begin);
                        MetadataItemData.LogicalSectorSize.LSectorSize = binVHDX.ReadUInt32();

                        if (MetadataItemData.LogicalSectorSize.LSectorSize != 512 && MetadataItemData.LogicalSectorSize.LSectorSize != 4096) throw new InvalidVhdxFileException();

                        continue;
                    }

                    if (itemID.Equals(FixedGuids.MetadataItemType.PhysicalSectorSize))
                    {
                        binVHDX.BaseStream.Seek(Offsets.MetadataRegionStructure + itemOffset, SeekOrigin.Begin);
                        MetadataItemData.PhysicalSectorSize.PSectorSize = binVHDX.ReadUInt32();

                        if (MetadataItemData.PhysicalSectorSize.PSectorSize != 512 && MetadataItemData.PhysicalSectorSize.PSectorSize != 4096) throw new InvalidVhdxFileException();

                        continue;
                    }

                    if (itemID.Equals(FixedGuids.MetadataItemType.ParentLocator))
                    {
                        throw new NotImplementedException();
                    }
                }
            }
        }
    }
}
