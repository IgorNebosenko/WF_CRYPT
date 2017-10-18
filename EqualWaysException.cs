using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WF_CRYPT
{
    //Exception if path to file and key are equals
    [Serializable]
    class EqualWaysException : ApplicationException
    {
        public EqualWaysException() :
            base("Source file and key file must has diffrent pathes!")
        { }
        public EqualWaysException(string what) :
            base(what)
        { }
        public EqualWaysException(string message, Exception innerException) :
            base(message, innerException)
        { }
        protected EqualWaysException(SerializationInfo info, StreamingContext context) :
            base(info, context)
        { }
    }
}
