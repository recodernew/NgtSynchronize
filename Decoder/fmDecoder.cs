using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Decoder
{
    public partial class fmDecoder : Form
    {
        public fmDecoder()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(openFileDialog.FileName))
            {
                txtFileName.Text = openFileDialog.FileName;
                Decoder decoder = new Decoder(openFileDialog.FileName);

                gvData.DataSource = decoder.DecodeData;

            }
        }
    }
}
