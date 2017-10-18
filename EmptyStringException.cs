using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WF_CRYPT
{
    //Exception of empty string with key
    [Serializable]
    class EmptyStringException : ApplicationException
    {
        public EmptyStringException() :
            base("Empty string with key!")
        { }
        public EmptyStringException(string what) :
            base(what)
        { }
        public EmptyStringException(string message, Exception innerException) :
            base(message, innerException)
        { }
        protected EmptyStringException(SerializationInfo info, StreamingContext context) :
            base(info, context)
        { }
    }
}
