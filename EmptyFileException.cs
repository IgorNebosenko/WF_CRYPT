using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WF_CRYPT
{
    //Exception of empty file
    [Serializable]
    class EmptyFileException : ApplicationException
    {
        public EmptyFileException() :
            base("File is empty!")
        { }
        public EmptyFileException(string what) :
            base("Empty " + what + " file")
        { }
        public EmptyFileException(string message, Exception innerException) :
            base(message, innerException)
        { }
        protected EmptyFileException(SerializationInfo info, StreamingContext context) :
            base(info, context)
        { }
    }
}
