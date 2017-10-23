using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WF_CRYPT
{
    /// <summary>
    /// <s>Exception of empty way to file</s>
    /// </summary>
    [Serializable]
    class EmptyPathException : ApplicationException
    {
        /// <summary>
        /// <s>Standart constructor</s>
        /// </summary>
        public EmptyPathException() :
            base("Empty way!")
        { }

        /// <summary>
        /// <s>Constructor with defines what path is empty</s>
        /// </summary>
        /// <param name="what"></param>
        public EmptyPathException(string what) :
            base("Empty path to " + what)
        { }

        /// <summary>
        /// <s>Constructor. Need for correct worc exceptions</s>
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public EmptyPathException(string message, Exception innerException) :
            base(message, innerException)
        { }

        /// <summary>
        /// <s>Constructor. Need for correct worc exceptions</s>
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected EmptyPathException(SerializationInfo info, StreamingContext context) :
            base(info, context)
        { }
    }
}
