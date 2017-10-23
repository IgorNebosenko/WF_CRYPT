using System;
using System.Windows.Forms;

namespace WF_CRYPT
{
    /// <summary>
    /// <c>Main class</c>
    /// </summary>
    static class Program
    {
        /// <summary>
        /// <s>Defines main entry for application</s>
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
