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
        /// <summary>
        /// <s>Path with temporaly file</s>
        /// </summary>
        public const string tmpPath = "tmp.dat";

        /// <summary>
        /// <s>Size of block. 4 MB</s>
        /// </summary>
        public const int ISizeBlock = 4096 * 1024;

        /// <summary>
        /// <s>Maximum value of byte + 1</s>
        /// </summary>
        const int IMaxValByte = 256;


        /// <summary>
        /// <s>String with path to file</s>
        /// </summary>
        string sPath = null;

        /// <summary>
        /// <s>String with key.Is this path or not - defines next bool</s>
        /// </summary>
        string sKey = null;

        /// <summary>
        /// <s>Defines is key file or not</s>
        /// </summary>
        bool bKeyFile = false;

        /// <summary>
        /// <s>Defines current position seek in file</s>
        /// </summary>
        long iPosFile = 0;

        /// <summary>
        /// <s>Defines size of file</s>
        /// </summary>
        long iSizeFile = 0;

        /// <summary>
        /// <s>Defines current position of key(file/string)</s>
        /// </summary>
        long iPosKey = 0;

        /// <summary>
        /// <s>Defines size of key</s>
        /// </summary>
        long iSizeKey = 0;

        /// <summary>
        /// <s>FileStream of file</s>
        /// </summary>
        FileStream fsFile = null;

        /// <summary>
        /// <s>FileStream of key, if need</s>
        /// </summary>
        FileStream fsKey = null;

        /// <summary>
        /// <s>FileStream of temporaly file</s>
        /// </summary>
        FileStream fsTmp = null;

        /// <summary>
        /// <s>Buffer with block of file. Size equals ISizeBlock</s>
        /// </summary>
        byte[] sBlockFile = null;

        /// <summary>
        /// <s>Buffer with block of key. Size equals ISizeBlock</s>
        /// </summary>
        byte[] sBlockKey = null;

        /// <summary>
        /// <s>Constructor with path to source file, key, and definition is key file</s>
        /// </summary>
        public Crypt(string sPathFile, string sKey, bool bKeyFile)                                  //There is single constructor
        {
            this.sPath = sPathFile;
            this.sKey = sKey;
            this.bKeyFile = bKeyFile;
            this.sBlockFile = new byte[ISizeBlock];
            this.sBlockKey = new byte[ISizeBlock];
        }

        /// <summary>
        /// <s>Open files. </s>
        /// <exception cref = "EmptyPathException">Exception of empty path</exception>
        /// <exception cref = "EmptyStringException">Exception of empty string with key</exception>
        /// <exception cref = "FileNotFoundException">Exception of not founded file</exception>
        /// <exception cref = "EqualWaysException">Exception of equal ways to file and key</exception>
        /// <exception cref = "EmptyFileException">Exception of empty file</exception>
        /// </summary>
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

        /// <summary>
        /// <s>Close files</s>
        /// </summary>
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

        /// <summary>
        /// <s>Delegate for select crypt</s>
        /// </summary>
        public delegate int Pred(int value_left, int value_right);

        /// <summary>
        /// <s>Predicat of crypt by XOR</s>
        /// <return>Encrypted variable</return>
        /// </summary>
        /// <param name="value_left"></param>
        /// <param name="valur_right"></param>
        /// <returns></returns>
        public static int XOR(int value_left, int valur_right)
        {
            return value_left ^ valur_right;
        }

        /// <summary>
        /// <s>Predicate of crypt by Caesar</s>
        /// <return>Encrypted variable</return>
        /// </summary>
        /// <param name="value_left"></param>
        /// <param name="value_right"></param>
        /// <returns></returns>
        public static int CryptCaesar(int value_left, int value_right)
        {
            value_left += value_right;                                                              //Never be out of range values, because works with bytes
            if (value_left >= IMaxValByte)
                value_left -= IMaxValByte;
            return value_left;
        }

        /// <summary>
        /// <s>Predicate of decrypt by Caesar</s>
        /// <return>Encrypted variable</return> 
        /// </summary>
        /// <param name="value_left"></param>
        /// <param name="value_right"></param>
        /// <returns></returns>
        public static int DecryptCaesar(int value_left, int value_right)
        {
            value_left -= value_right;
            if (value_left < 0)
                value_left += IMaxValByte;
            return value_left;
        }

        /// <summary>
        /// <s>Crypt file, with selected predicate</s>
        /// <return>Value of progress crypt. Array of values 0...1000</return>
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
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
