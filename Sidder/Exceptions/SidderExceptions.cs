using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SidderApp.Exceptions
{
    internal class NoFilesFoundException : Exception
    {
        public NoFilesFoundException() : base() { }
        public NoFilesFoundException(string message) : base(message) { }
        public NoFilesFoundException(string message, Exception innerException) : base(message, innerException) { }
    }

    internal class NoDirectoriesFoundException : Exception
    {
        public NoDirectoriesFoundException() : base() { }
        public NoDirectoriesFoundException(string message) : base(message) { }
        public NoDirectoriesFoundException(string message, Exception innerException) : base(message, innerException) { }
    }

    internal class VhdxParseException : Exception
    {
        public VhdxParseException() : base() { }
        public VhdxParseException(string message) : base(message) { }
        public VhdxParseException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class InvalidVhdxFileException : Exception
    {
        public InvalidVhdxFileException() : base() { }
        public InvalidVhdxFileException(string message) : base(message) { }
        public InvalidVhdxFileException(string message, Exception innerException) : base(message, innerException) { }
    }
}
