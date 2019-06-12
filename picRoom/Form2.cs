using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace picRoom
{
    public partial class Form2 : Form
    {
        public delegate void TextEventHandler(string decode);

        public TextEventHandler TextHandler;

        public Form2()
        {
            InitializeComponent();
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            if (null != TextHandler)
            {
                TextHandler.Invoke(decode.Text);
                DialogResult = DialogResult.OK;
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void decode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Keys.Enter == (Keys)e.KeyChar)
            {
                if (null != TextHandler)
                {
                    TextHandler.Invoke(decode.Text);
                    DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
