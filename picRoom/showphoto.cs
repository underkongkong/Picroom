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
    public partial class showphoto : Form
    {
        public showphoto()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

        }

        public PictureBox picture1
        {
            get { return pictureBox1; }

        }
        
    }
}
