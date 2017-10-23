using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WF_CRYPT
{
    /// <summary>
    /// <s>Exception if path to file and key are equals</s>
    /// </summary>
    [Serializable]
    class EqualWaysException : ApplicationException
    {
        /// <summary>
        /// <s>Standart constructor</s>
        /// </summary>
        public EqualWaysException() :
            base("Source file and key file must has diffrent pathes!")
        { }

        /// <summary>
        /// <s>Constructor with defines equal files</s>
        /// </summary>
        /// <param name="what"></param>
        public EqualWaysException(string what) :
            base(what)
        { }

        /// <summary>
        /// <s>Constructor. Need for correct worc exceptions</s>
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public EqualWaysException(string message, Exception innerException) :
            base(message, innerException)
        { }

        /// <summary>
        /// <s>Constructor. Need for correct worc exceptions</s>
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected EqualWaysException(SerializationInfo info, StreamingContext context) :
            base(info, context)
        { }
    }
}
