using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WF_CRYPT
{
    class Crypt
    {
        public const string tmpPath = "tmp.dat";                                                    //Path with temporaly file
        public const int ISizeBlock = 4096 * 1024;                                                  //Size of block. 4 MB
        const int IMaxValByte = 256;                                                                //Maximum value of byte + 1

        string sPath = null;                                                                        //String with path to file
        string sKey = null;                                                                         //String with key.Is this path or not - defines next bool
        bool bKeyFile = false;                                                                      //Defines is key file or not

        long iPosFile = 0;                                                                          //Defines current position seek in file
        long iSizeFile = 0;                                                                         //Defines size of file
        long iPosKey = 0;                                                                           //Defines current position of key(file/string)
        long iSizeKey = 0;                                                                          //Defines size of key

        FileStream fsFile = null;                                                                   //FileStream of file
        FileStream fsKey = null;                                                                    //FileStream of key, if need
        FileStream fsTmp = null;                                                                    //FileStream of temporaly file

        byte[] sBlockFile = null;
        byte[] sBlockKey = null;

        public Crypt(string sPathFile, string sKey, bool bKeyFile)                                  //There is single constructor
        {
            this.sPath = sPathFile;
            this.sKey = sKey;
            this.bKeyFile = bKeyFile;
            this.sBlockFile = new byte[ISizeBlock];
            this.sBlockKey = new byte[ISizeBlock];
        }

        public void OpenFile()
        {
            try
            {
                if (this.sKey == "")
                    throw new EmptyPathException("file");

                if (this.bKeyFile && this.sPath == "")
                    throw new EmptyPathException("key");

                if (!this.bKeyFile && this.sPath == "")
                    throw new EmptyStringException();

                if (!File.Exists(this.sPath) ||
                    (this.bKeyFile && !File.Exists(this.sKey)))
                    throw new FileNotFoundException();

                if (this.bKeyFile && this.sPath == this.sKey)
                    throw new EqualWaysException();

                this.fsFile = new FileStream(this.sPath, FileMode.Open, FileAccess.Read);
                this.iSizeFile = this.fsFile.Length;

                if (this.bKeyFile)
                {
                    this.fsKey = new FileStream(this.sKey, FileMode.Open, FileAccess.Read);
                    this.iSizeKey = this.fsKey.Length;
                }
                else
                    this.iSizeKey = this.sKey.Length;

                File.Delete(tmpPath);                                                               //Remove temporaly file(or not remove if it not exists)
                this.fsTmp = new FileStream(tmpPath, FileMode.Append, FileAccess.Write);            //Open temporaly file to write

                if (this.iSizeFile == 0)
                    throw new EmptyFileException("source");
                if (this.iSizeKey == 0)                                                              //Size of key can't be equals 0 if string, because upper tests are except this
                    throw new EmptyFileException("key");
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void CloseFiles()
        {
            if (this.fsFile != null)
            {
                this.fsFile.Close();
                this.fsFile = null;
            }
            if (this.fsKey != null)
            {
                this.fsKey.Close();
                this.fsKey = null;
            }
            if (this.fsTmp != null)
            {
                this.fsTmp.Close();
                this.fsTmp = null;
            }
        }

        public delegate int Pred(int value_left, int value_right);

        public static int XOR(int value_left, int valur_right)
        {
            return value_left ^ valur_right;
        }
        public static int CryptCaesar(int value_left, int value_right)
        {
            value_left += value_right;                                                              //Never be out of range values, because works with bytes
            if (value_left >= IMaxValByte)
                value_left -= IMaxValByte;
            return value_left;
        }
        public static int DecryptCaesar(int value_left, int value_right)
        {
            value_left -= value_right;
            if (value_left < 0)
                value_left += IMaxValByte;
            return value_left;
        }

        public int CryptProcess(Pred p)
        {
            int iNumReadFile = this.fsFile.Read(this.sBlockFile, 0, ISizeBlock);
            int iNumReadKey = 0;

            while (iNumReadKey < iNumReadFile - 1)
            {
                if (this.bKeyFile)
                {
                    iNumReadKey += this.fsKey.Read(this.sBlockKey, iNumReadKey, ISizeBlock - iNumReadKey - 1);
                    if (iNumReadKey < ISizeBlock)
                        this.fsKey.Seek(0, SeekOrigin.Begin);
                }
                else
                {
                    for (var i = this.iPosKey; i < this.iSizeKey && iNumReadKey < ISizeBlock; ++i, iNumReadKey++)
                        this.sBlockKey[iNumReadKey] = (byte)this.sKey[(int)i];
                    this.iPosKey = 0;
                }
            }

            for (var i = 0; i < iNumReadFile; ++i)
                this.sBlockFile[i] = (byte)p((byte)this.sBlockFile[i], (byte)this.sBlockKey[i]);

            this.fsTmp.Write(this.sBlockFile, 0, iNumReadFile);

            this.iPosFile += iNumReadFile;

            return (int)(1f * this.iPosFile / this.iSizeFile * 1000);
        }
    }
}
