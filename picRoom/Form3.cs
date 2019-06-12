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
    public partial class choose : Form
    {
        public choose()
        {
            InitializeComponent();
        }

        public static string choice;

        public  void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked|| radioButton2.Checked || radioButton3.Checked || radioButton4.Checked || radioButton5.Checked )
            {
                if (radioButton1.Checked) { choice = radioButton1.Text; };
                if (radioButton2.Checked) { choice = radioButton2.Text; };
                if (radioButton3.Checked) { choice = radioButton3.Text; };
                if (radioButton4.Checked) { choice = radioButton4.Text; };
                if (radioButton5.Checked) { choice = radioButton5.Text; };
                DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("选项不能为空！");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
