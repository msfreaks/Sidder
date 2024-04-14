using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SidderApp.Exceptions;

namespace SidderApp.Parser
{
    internal class VhdxReader : Stream, IDisposable
    {
        private Stream BaseStream { get; set; }
        private BinaryReader Reader { get; set; }
        private VhdxMetadata VhdxMetadata { get; set; }
        private long InternalPosition { get; set; }
        private long PositionOffset { get; set; }
        private long VirtualPosition { get { return InternalPosition + PositionOffset; } }
        private Dictionary<int, BatPayloadEntryInfo> BlockAllocationTable { get; set; }

        private class BatPayloadEntryInfo
        {
            private UInt64 EntryPayload { get; set; }

            public enum BatPayloadEntryStates : ulong
            {
                PAYLOAD_BLOCK_NOT_PRESENT = 0,
                PAYLOAD_BLOCK_UNDEFINED = 1,
                PAYLOAD_BLOCK_ZERO = 2,
                PAYLOAD_BLOCK_UNMAPPED = 3,
                PAYLOAD_BLOCK_FULLY_PRESENT = 6,
                PAYLOAD_BLOCK_PARTIALLY_PRESENT = 7
            }

            public BatPayloadEntryInfo(UInt64 entryPayload)
            {
                EntryPayload = entryPayload;
            }

            public BatPayloadEntryStates State { get { return (BatPayloadEntryStates)(EntryPayload & 0x7); } }
            public bool IsBlockPresent { get { return State == BatPayloadEntryStates.PAYLOAD_BLOCK_FULLY_PRESENT; } }
            public long FileOffsetMB { get { return (long)(EntryPayload >> 20) & 0xFFFFFFFFFFFL; } }
        }

        public override bool CanRead => true;

        public override bool CanSeek => true;

        public override bool CanWrite => false;

        public override long Length { get { return VhdxMetadata.VirtualDiskSize; } }

        public override long Position { get { return InternalPosition; } set { InternalPosition = value; } }

        public VhdxReader(String fileName)
        {
            if (File.Exists(fileName))
            {
                BaseStream = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                Reader = new BinaryReader(BaseStream);
                VhdxMetadata = new VhdxMetadata(BaseStream);

                InternalPosition = 0;
                PositionOffset = 0;

                InitializeBAT();
            }
            else throw new FileNotFoundException();
        }

        public new void Dispose()
        {
            base.Dispose();

            if (Reader != null) Reader.Dispose();
            if (BaseStream != null) BaseStream.Dispose();
        }

        public string ReturnMetadata()
        {
            var result = String.Empty;

            result += String.Format("VirtualDiskSize: {0}", VhdxMetadata.VirtualDiskSize) + Environment.NewLine;
            result += String.Format("BlockSize: {0}", VhdxMetadata.BlockSize) + Environment.NewLine;
            result += String.Format("BlockAllocationTableOffset: {0}", VhdxMetadata.BlockAllocationTableOffset) + Environment.NewLine;
            result += String.Format("BlockAllocationTableSize: {0}", VhdxMetadata.BlockAllocationTableSize) + Environment.NewLine;
            result += String.Format("PayloadBlockCount: {0}", VhdxMetadata.PayloadBlockCount) + Environment.NewLine;
            result += String.Format("ChunkRatio: {0}", VhdxMetadata.ChunkRatio) + Environment.NewLine;
            result += String.Format("SectorBitmapBlockCount: {0}", VhdxMetadata.SectorBitmapBlockCount) + Environment.NewLine;
            result += String.Format("TotalBlockAllocationTableEntryCount: {0}", VhdxMetadata.TotalBlockAllocationTableEntryCount) + Environment.NewLine;

            return result;
        }

        public override void Flush()
        {
            throw new NotImplementedException();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int bytesWritten = 0;

            for (int i = 0; i < count; i++)
            {
                var entryNum = (int)Math.Floor((decimal)VirtualPosition / (decimal)VhdxMetadata.BlockSize);
                var offsetInsideBlock = VirtualPosition - (entryNum * VhdxMetadata.BlockSize);

                if (BlockAllocationTable.ContainsKey(entryNum))
                {
                    if (BlockAllocationTable[entryNum].IsBlockPresent)
                    {
                        Reader.BaseStream.Seek((BlockAllocationTable[entryNum].FileOffsetMB * 1048576) + offsetInsideBlock, SeekOrigin.Begin);
                        buffer[offset + i] = Reader.ReadByte();
                    }
                    else
                    {
                        buffer[offset + i] = 0x00;
                    }

                    InternalPosition++;
                    bytesWritten++;
                }
                else throw new InvalidVhdxFileException();
            }

            return bytesWritten;
        }

        public void OffsetToFirstPartition()
        {
            if (BlockAllocationTable.Count > 0)
            {
                Reader.BaseStream.Seek((BlockAllocationTable[0].FileOffsetMB * 1048576), SeekOrigin.Begin); // Seek to MBR
                Reader.BaseStream.Seek(446, SeekOrigin.Current); // Seek to first partition entry
                Reader.BaseStream.Seek(8, SeekOrigin.Current); // Seek to first partition relative sector offset entry
                PositionOffset = Reader.ReadUInt32() * 512u;
            }
            else throw new ArgumentOutOfRangeException();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotImplementedException();
        }

        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }

        private void InitializeBAT()
        {
            BlockAllocationTable = new Dictionary<int, BatPayloadEntryInfo>();

            Reader.BaseStream.Seek(VhdxMetadata.BlockAllocationTableOffset, SeekOrigin.Begin);

            for (int i = 0; i < VhdxMetadata.TotalBlockAllocationTableEntryCount; i++)
            {
                var isSectorBitmap = (i + 1) % VhdxMetadata.ChunkRatio == 0 ? true : false;

                if (isSectorBitmap)
                {
                    Reader.BaseStream.Seek(8, SeekOrigin.Current);
                    continue;
                }

                BlockAllocationTable.Add(i, new BatPayloadEntryInfo(Reader.ReadUInt64()));
            }
        }
    }
}
