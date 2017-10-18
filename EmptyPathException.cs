using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WF_CRYPT
{
    //Exception of empty way to file
    [Serializable]
    class EmptyPathException : ApplicationException
    {
        public EmptyPathException() :
            base("Empty way!")
        { }
        public EmptyPathException(string what) :
            base("Empty path to " + what)
        { }
        public EmptyPathException(string message, Exception innerException) :
            base(message, innerException)
        { }
        protected EmptyPathException(SerializationInfo info, StreamingContext context) :
            base(info, context)
        { }
    }
}
