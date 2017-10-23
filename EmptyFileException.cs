using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WF_CRYPT
{
    /// <summary>
    /// <s>Exception of empty file</s>
    /// </summary>
    [Serializable]
    class EmptyFileException : ApplicationException
    {
        /// <summary>
        /// <s>Standart constructor</s>
        /// </summary>
        public EmptyFileException() :
            base("File is empty!")
        { }

        /// <summary>
        /// <s>Constructor with defines what file is empty</s>
        /// </summary>
        /// <param name="what"></param>
        public EmptyFileException(string what) :
            base("Empty " + what + " file")
        { }

        /// <summary>
        /// <s>Constructor. Need for correct worc exceptions</s>
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public EmptyFileException(string message, Exception innerException) :
            base(message, innerException)
        { }

        /// <summary>
        /// <s>Constructor. Need for correct worc exceptions</s>
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected EmptyFileException(SerializationInfo info, StreamingContext context) :
            base(info, context)
        { }
    }
}
