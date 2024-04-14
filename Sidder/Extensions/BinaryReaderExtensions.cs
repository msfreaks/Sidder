using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SidderApp.Extensions
{
    internal static class BinaryReaderExtensions
    {
        public static Guid ReadGuid(this BinaryReader binaryReader)
        {
            return new Guid(binaryReader.ReadBytes(16));
        }
    }
}
