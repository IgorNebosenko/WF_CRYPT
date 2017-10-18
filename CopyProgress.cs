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
        const string SSufix = ".crp";                                                               //Additional suffix

        string sPath = null;

        long iPosFile = 0;
        long iSizeFile = 0;

        FileStream fs = null;
        FileStream fsDest = null;

        byte[] buf = null;

        public CopyProgress(string sPath)
        {
            this.sPath = sPath;
            buf = new byte[Crypt.ISizeBlock];
        }

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
        public int Copy()
        {
            int iNumRead = this.fs.Read(this.buf, 0, Crypt.ISizeBlock);
            this.fsDest.Write(this.buf, 0, iNumRead);
            this.iPosFile += iNumRead;

            return (int)(1f * this.iPosFile / this.iSizeFile * 1000);
        }
        public void Replace()
        {
            this.Close();
            File.Delete(this.sPath);
            File.Move(this.sPath + SSufix, this.sPath);
        }
    }
}
