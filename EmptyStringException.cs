using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WF_CRYPT
{
    /// <summary>
    /// <s>Exception of empty string with key</s>
    /// </summary>
    [Serializable]
    class EmptyStringException : ApplicationException
    {
        /// <summary>
        /// <s>Standart constructor</s>
        /// </summary>
        public EmptyStringException() :
            base("Empty string with key!")
        { }

        /// <summary>
        /// <s>Constructor with defines what string is empty</s>
        /// </summary>
        /// <param name="what"></param>
        public EmptyStringException(string what) :
            base(what)
        { }

        /// <summary>
        /// <s>Constructor. Need for correct worc exceptions</s>
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public EmptyStringException(string message, Exception innerException) :
            base(message, innerException)
        { }

        /// <summary>
        /// <s>Constructor. Need for correct worc exceptions</s>
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected EmptyStringException(SerializationInfo info, StreamingContext context) :
            base(info, context)
        { }
    }
}
