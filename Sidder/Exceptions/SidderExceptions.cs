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
}
