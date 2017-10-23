using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WF_CRYPT
{
    class CopyProgress
    {
        /// <summary>
        /// <s>Suffix for temporaly file in directory equal to directory with sorce file</s>
        /// </summary>
        const string SSufix = ".crp";                                                               //Additional suffix

        /// <summary>
        /// <s>Path to file</s>
        /// </summary>
        string sPath = null;

        /// <summary>
        /// <s>Defines in what position current seek</s>
        /// </summary>
        long iPosFile = 0;

        /// <summary>
        /// <s>Defines size of file</s>
        /// </summary>
        long iSizeFile = 0;

        /// <summary>
        /// <s>Object FileStrem with source file</s>
        /// </summary>
        FileStream fs = null;

        /// <summary>
        /// <s>Object FileStream with dest file</s>
        /// </summary>
        FileStream fsDest = null;

        /// <summary>
        /// <s>Buffer for copy file. Size equals SizeBlock from class Crypt</s>
        /// </summary>
        byte[] buf = null;

        /// <summary>
        /// <s>Constructor, which gets partition to file</s>
        /// </summary>
        /// <param Path_to_file="sPath"></param>
        public CopyProgress(string sPath)
        {
            this.sPath = sPath;
            buf = new byte[Crypt.ISizeBlock];
        }

        /// <summary>
        /// <s>Open files</s>
        /// <exception cref = "FileNotFoundException">If file not found</exception>
        /// </summary>
        public void Open()
        {
            try
            {
                if (!File.Exists(this.sPath))
                    throw new FileNotFoundException();
                this.fs = new FileStream(Crypt.tmpPath, FileMode.Open, FileAccess.Read);
                this.iSizeFile = this.fs.Length;

                File.Delete(this.sPath + SSufix);

                this.fsDest = new FileStream(this.sPath + SSufix, FileMode.Append, FileAccess.Write);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// <c>Close opened files. Don't generates exceptions</c>
        /// </summary>
        public void Close()
        {
            if (this.fs != null)
            {
                this.fs.Close();
                this.fs = null;
            }
            if (this.fsDest != null)
            {
                this.fsDest.Close();
                this.fsDest = null;
            }
        }

        /// <summary>
        /// <c>Copy file from src.dat to temporaly file in directory with sorce file</c>
        /// </summary>
        /// <returns></returns>
        public int Copy()
        {
            int iNumRead = this.fs.Read(this.buf, 0, Crypt.ISizeBlock);
            this.fsDest.Write(this.buf, 0, iNumRead);
            this.iPosFile += iNumRead;

            return (int)(1f * this.iPosFile / this.iSizeFile * 1000);
        }

        /// <summary>
        /// <s>Replaces temporaly file to source file</s>
        /// </summary>
        public void Replace()
        {
            this.Close();
            File.Delete(this.sPath);
            File.Move(this.sPath + SSufix, this.sPath);
        }
    }
}
