using System;
using System.Windows.Forms;

namespace WF_CRYPT
{
    /// <summary>
    /// <s>Need for draw and work with form</s>
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// <s>This field need to draw select file dialog</s>
        /// </summary>
        OpenFileDialog ofd = null;

        /// <summary>
        /// <s>defines maximum value for progressbar</s>
        /// </summary>
        const int IMaxValueProgress = 1000;

        /// <summary>
        /// <s>Field of object Crypt</s>
        /// </summary>
        Crypt c = null;

        /// <summary>
        /// <s>Field of object CopyProgress</s>
        /// </summary>
        CopyProgress cp = null;

        /// <summary>
        /// <s>Constructor for initzilize form</s>
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            ofd = new OpenFileDialog();
        }

        /// <summary>
        /// <c>Defines is selected crypt by Caesar.</c>
        /// <c>Set group with Crypt/Decrypt to enabled</c>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbCaesar_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbCaesar.Checked)
                this.groupType.Enabled = true;
        }

        /// <summary>
        /// <c>Defines is selected crypt by XOR.</c>
        /// <c>Disable group with Crypt/Decrypt</c>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbXOR_CheckedChanged(object sender, EventArgs e)
        {
            if(this.rbXOR.Checked)
                this.groupType.Enabled = false;
        }

        /// <summary>
        /// <s>Defines key as such as string</s>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbString_CheckedChanged(object sender, EventArgs e)
        {
            if (rbString.Checked)
            {
                this.labelKey.Text = "String with key:";
                this.buttonkey.Enabled = false;
            }
        }

        /// <summary>
        /// <s>Defines key as such as file</s>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbFile_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFile.Checked)
            {
                this.labelKey.Text = "String with path to key:";
                this.buttonkey.Enabled = true;
            }
        }

        /// <summary>
        /// <s>Show DialogMessage for select file</s>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSource_Click(object sender, EventArgs e)
        {
            this.ofd.ShowDialog();
            this.textBoxSource.Text = this.ofd.FileName;
        }

        /// <summary>
        /// <s>Show DialogMessage for select key as file</s>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonkey_Click(object sender, EventArgs e)
        {
            this.ofd.ShowDialog();
            this.textBoxKey.Text = this.ofd.FileName;
        }

        /// <summary>
        /// <s>Enable or disable elements of form</s>
        /// <paramref bStatus="true - enable elements, false - disable"/>
        /// </summary>
        /// <param name="bStatus"></param>
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

        /// <summary>
        /// <s>Starts crypt</s>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// <s>Delegate for Async block</s>
        /// </summary>
        delegate void DCrypt();

        /// <summary>
        /// <s>Async crypt</s>
        /// </summary>
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
