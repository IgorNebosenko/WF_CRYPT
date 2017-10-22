using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace WF_CRYPT
{
    public partial class Form1 : Form
    {
        OpenFileDialog ofd = null;
        const int IMaxValueProgress = 1000;
        Crypt c = null;
        CopyProgress cp = null;

        public Form1()
        {
            InitializeComponent();
            ofd = new OpenFileDialog();
        }

        private void rbCaesar_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbCaesar.Checked)
                this.groupType.Enabled = true;
        }

        private void rbXOR_CheckedChanged(object sender, EventArgs e)
        {
            if(this.rbXOR.Checked)
                this.groupType.Enabled = false;
        }

        private void rbString_CheckedChanged(object sender, EventArgs e)
        {
            if (rbString.Checked)
            {
                this.labelKey.Text = "String with key:";
                this.buttonkey.Enabled = false;
            }
        }

        private void rbFile_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFile.Checked)
            {
                this.labelKey.Text = "String with path to key:";
                this.buttonkey.Enabled = true;
            }
        }

        private void buttonSource_Click(object sender, EventArgs e)
        {
            this.ofd.ShowDialog();
            this.textBoxSource.Text = this.ofd.FileName;
        }

        private void buttonkey_Click(object sender, EventArgs e)
        {
            this.ofd.ShowDialog();
            this.textBoxKey.Text = this.ofd.FileName;
        }

        private void EditStatus(bool bStatus)
        {
            this.groupCrypt.Enabled = bStatus;

            if (bStatus && !this.rbXOR.Checked)
                this.groupType.Enabled = bStatus;
            else
                this.groupType.Enabled = false;

            this.groupKey.Enabled = bStatus;
            this.buttonSource.Enabled = bStatus;

            this.textBoxSource.Enabled = bStatus;
            this.textBoxKey.Enabled = bStatus;

            if (bStatus && !this.rbString.Checked)
                this.buttonkey.Enabled = bStatus;
            else
                this.buttonkey.Enabled = false;

            this.buttonStart.Enabled = bStatus;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            this.c = new Crypt(this.textBoxSource.Text, this.textBoxKey.Text, this.rbFile.Checked);
            this.cp = new CopyProgress(this.textBoxSource.Text);
            try
            {
                c.OpenFile();
                this.EditStatus(false);

                DCrypt handler = new DCrypt(this.CryptAsync);

                IAsyncResult iObj = handler.BeginInvoke(null, null);

                handler.EndInvoke(iObj);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!");
            }
            finally
            {
                c.CloseFiles();
                cp.Close();
                this.EditStatus(true);
            }
        }
        delegate void DCrypt();

        private void CryptAsync()
        {
            int iStatusCrypt = 0;
            while (iStatusCrypt < IMaxValueProgress)
            {
                if (this.rbXOR.Checked)
                    iStatusCrypt = c.CryptProcess(Crypt.XOR);
                else if (this.rbCrypt.Checked)
                    iStatusCrypt = c.CryptProcess(Crypt.CryptCaesar);
                else
                    iStatusCrypt = c.CryptProcess(Crypt.DecryptCaesar);

                this.progressBar1.Value = iStatusCrypt;
            }
            this.progressBar1.Value = IMaxValueProgress;
            c.CloseFiles();

            this.progressBar1.Value = IMaxValueProgress;
            c.CloseFiles();

            cp.Open();
            int iStatusCopy = 0;
            while (iStatusCopy < IMaxValueProgress)
            {
                iStatusCopy = cp.Copy();
                this.progressBar2.Value = iStatusCopy;
            }
            this.progressBar2.Value = IMaxValueProgress;
            cp.Close();

            cp.Replace();
            MessageBox.Show("Covertation complete!", "Succesfull!");
            this.progressBar1.Value = 0;
            this.progressBar2.Value = 0;
        }
    }
}
