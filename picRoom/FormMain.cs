using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.IO;


namespace picRoom
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            
        }

        private Bitmap srcBitmap = null;


        private void TrackBar1_ValueChanged_1(object sender, EventArgs e)
        {
            if (datas.desImage != null)
            {
                label5.Text = "工作中";
                System.Windows.Forms.Application.DoEvents();
                datas.desImage = BitmapHelper.HSLC(datas.originalBitmap, (int)trackBar1.Value, (int)trackBar4.Value, (int)trackBar2.Value, (int)trackBar3.Value);

                // 重新给Image控件赋值新图像

                datas.Form1.picture1.Image = datas.desImage;
                datas.Form1.Show();
                label5.Text = "未工作";
            }
      
            else
                System.Windows.Forms.MessageBox.Show("请先导入一张图片");

        }
        


        private void trackBar4_ValueChanged(object sender, EventArgs e)
        {
            if (datas.desImage != null)
            {
            label5.Text = "工作中";
            System.Windows.Forms.Application.DoEvents();
            datas.desImage = BitmapHelper.HSLC(
                datas.originalBitmap,
                (int)trackBar1.Value, 
                (int)trackBar4.Value, 
                (int)trackBar2.Value, 
                (int)trackBar3.Value);

            // 重新给Image控件赋值新图像

            datas.Form1.picture1.Image = datas.desImage;
            datas.Form1.Show();
            label5.Text = "未工作";
            }
            else
                System.Windows.Forms.MessageBox.Show("请先导入一张图片");
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            if (datas.desImage != null)
            {
            label5.Text = "工作中";
            System.Windows.Forms.Application.DoEvents();
            datas.desImage = BitmapHelper.HSLC(datas.originalBitmap, (int)trackBar1.Value, (int)trackBar4.Value, (int)trackBar2.Value, (int)trackBar3.Value);
            datas.Form1.picture1.Image = datas.desImage;
            datas.Form1.Show();
            label5.Text = "未工作";
             }
             else
                    System.Windows.Forms.MessageBox.Show("请先导入一张图片");
            }

        private void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            if (datas.desImage != null)
            {
                label5.Text = "工作中";
            System.Windows.Forms.Application.DoEvents();
            datas.desImage = BitmapHelper.HSLC(datas.originalBitmap, (int)trackBar1.Value, (int)trackBar4.Value, (int)trackBar2.Value, (int)trackBar3.Value);
            datas.Form1.picture1.Image = datas.desImage;
            datas.Form1.Show();
            label5.Text = "未工作";
                }
                else
                    System.Windows.Forms.MessageBox.Show("请先导入一张图片");
            }

        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            int threshold = (int)trackBar1.Value;
            datas.command = threshold;
        }

        private void trackBar4_MouseUp(object sender, MouseEventArgs e)
        {
            int threshold = (int)trackBar4.Value;
            datas.command = threshold;
        }

        private void trackBar2_MouseUp(object sender, MouseEventArgs e)
        {
            int threshold = (int)trackBar2.Value;
            datas.command = threshold;
        }

        private void trackBar3_MouseUp(object sender, MouseEventArgs e)
        {
            int threshold = (int)trackBar3.Value;
            datas.command = threshold;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (datas.desImage != null)
            {
                label5.Text = "工作中";
            System.Windows.Forms.Application.DoEvents();
            string encode = string.Empty;
            InputDialog.Show(out encode);
            if (string.IsNullOrWhiteSpace(encode))
            {
                return;
            }
            datas.desImage = BitmapHelper.encode(datas.desImage,encode);
            datas.Form1.picture1.Image = datas.desImage;
            datas.stackPosition++;
            datas.stackUndo.Add(datas.desImage);
            datas.Form1.Show();
            label5.Text = "未工作";
                }
                else
                    System.Windows.Forms.MessageBox.Show("请先导入一张图片");
            }

        private void button9_Click(object sender, EventArgs e)
        {
            if (datas.desImage != null)
            {
                label5.Text = "工作中";
            System.Windows.Forms.Application.DoEvents();
            string decode = string.Empty;
            InputDialog.Show(out decode);
            if (string.IsNullOrWhiteSpace(decode))
            {
                return;
            }
            datas.desImage = BitmapHelper.decode(datas.desImage, decode);
            datas.stackPosition++;
            datas.stackUndo.Add(datas.desImage);
            datas.Form1.picture1.Image = datas.desImage;
            datas.Form1.Show();
            label5.Text = "未工作";
                }
                else
                    System.Windows.Forms.MessageBox.Show("请先导入一张图片");
            }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (datas.desImage != null)
            {
                label5.Text = "工作中";
            System.Windows.Forms.Application.DoEvents();
            datas.desImage = BitmapHelper.sharpen(datas.desImage);
            datas.stackPosition++;
            datas.stackUndo.Add(datas.desImage);
            datas.Form1.picture1.Image = datas.desImage;
            datas.Form1.Show();
            label5.Text = "未工作";
                }
                else
                    System.Windows.Forms.MessageBox.Show("请先导入一张图片");
            }

        private void Button10_Click(object sender, EventArgs e)
        {
            if (datas.desImage != null)
            {
                label5.Text = "工作中";
            System.Windows.Forms.Application.DoEvents();
            Bitmap bitmap = (Bitmap)datas.desImage;
            datas.desImage = BitmapHelper.Image_Soften(bitmap);
            datas.stackPosition++;
            datas.stackUndo.Add(datas.desImage);
            datas.Form1.picture1.Image = datas.desImage;
            datas.Form1.Show();
            label5.Text = "未工作";
                }
                else
                    System.Windows.Forms.MessageBox.Show("请先导入一张图片");
            }

        private void Button12_Click(object sender, EventArgs e)
        {
            if (datas.desImage != null)
            {
            label5.Text = "工作中";
            System.Windows.Forms.Application.DoEvents();
            Bitmap bitmap = (Bitmap)datas.desImage;
            datas.desImage = BitmapHelper.KiRotate270(bitmap);
            datas.stackPosition++;
            datas.stackUndo.Add(datas.desImage);
            datas.Form1.picture1.Image = datas.desImage;
            datas.Form1.Show();
            label5.Text = "未工作";
            }
                else
                    System.Windows.Forms.MessageBox.Show("请先导入一张图片");
            }

        private void Button11_Click(object sender, EventArgs e)
        {
            if (datas.desImage != null)
            {
                label5.Text = "工作中";
            System.Windows.Forms.Application.DoEvents();
            Bitmap bitmap = (Bitmap)datas.desImage;
            datas.desImage = BitmapHelper.KiRotate90(bitmap);
            datas.stackPosition++;
            datas.stackUndo.Add(datas.desImage);
            datas.Form1.picture1.Image = datas.desImage;
            datas.Form1.Show();
            label5.Text = "未工作";
                }
                else
                    System.Windows.Forms.MessageBox.Show("请先导入一张图片");
            }

        private void Button13_Click(object sender, EventArgs e)
        {
            if (datas.desImage != null)
            {
                label5.Text = "工作中";
                System.Windows.Forms.Application.DoEvents();
                Bitmap bitmap = (Bitmap)datas.desImage;
                datas.desImage = BitmapHelper.KiRotateX(bitmap);
                datas.stackPosition++;
                datas.stackUndo.Add(datas.desImage);
                datas.Form1.picture1.Image = datas.desImage;
                datas.Form1.Show();
                label5.Text = "未工作";
            }
            else
                System.Windows.Forms.MessageBox.Show("请先导入一张图片");
        }

        private void Button14_Click(object sender, EventArgs e)
        {
            if (datas.desImage != null)
            {
            label5.Text = "工作中";
            System.Windows.Forms.Application.DoEvents();
            Bitmap bitmap = (Bitmap)datas.desImage;
            datas.desImage = BitmapHelper.KiRotateY(bitmap);
            datas.stackPosition++;
            datas.stackUndo.Add(datas.desImage);
            datas.Form1.picture1.Image = datas.desImage;
            datas.Form1.Show();
            label5.Text = "未工作";
            }
            else
                System.Windows.Forms.MessageBox.Show("请先导入一张图片");
            label5.Text = "未工作";
        }

        private void Button15_Click(object sender, EventArgs e)
        {
            

            if (datas.stackPosition > 0)
            {
                datas.stackUndo.RemoveAt(datas.stackPosition);
                datas.stackPosition--;
            }
            datas.desImage = datas.stackUndo[datas.stackPosition];
            datas.Form1.picture1.Image = datas.desImage;
            datas.Form1.Show();
        }
               //e.Handled = true;       //将Handled设置为true，指示已经处理过KeyDown事件   


        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Z && e.Control)
            {
                this.button15.PerformClick(); //执行单击button15的动作   
            }
        }

        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 打开文件夹ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label5.Text = "工作中";
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;//该值确定是否可以选择多个文件
            dialog.Title = "请选择文件夹";
            dialog.Filter = "*jpg|*.JPG|*.GIF|*.BMP";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string file = dialog.FileName;
                srcBitmap = (Bitmap)Bitmap.FromFile(dialog.FileName, false);
                datas.originalBitmap = srcBitmap;
                datas.desImage = datas.originalBitmap;
                datas.stackUndo.Add(datas.originalBitmap);
                // datas.cutwidth = srcBitmap.Width;
                // datas.cutheight = srcBitmap.Height;
                Point ptLoction = new Point(datas.originalBitmap.Size);

                datas.Form1 = new showphoto();//放到初始化去了

                datas.Form1.picture1.Image = datas.desImage;
                datas.Form1.TopLevel = false;
                splitContainer3.Panel1.Controls.Add(datas.Form1);

                if (ptLoction.X > datas.Form1.Size.Width || ptLoction.Y > datas.Form1.Size.Height)
                {
                    //圖像框的停靠方式   
                    datas.Form1.picture1.Dock = DockStyle.Fill;   

                    //圖像充滿圖像框，並且圖像維持比例   
                    datas.Form1.picture1.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    //圖像在圖像框置中   
                    datas.Form1.picture1.SizeMode = PictureBoxSizeMode.CenterImage;
                }

                //LoadAsync：非同步載入圖像   
                datas.Form1.Show();
                datas.Form1.picture1.LoadAsync(file.ToString());
            }
            label5.Text = "未工作";
        }

        private void 另存为ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label5.Text = "工作中";
            System.Windows.Forms.Application.DoEvents();
            SaveFileDialog savedlg = new SaveFileDialog();
            savedlg.Title = "附件另存";
            savedlg.Filter = "jpg图片|*.JPG|gif图片|*.GIF|png图片|*.PNG|jpeg图片|*.JPEG";
            savedlg.FilterIndex = 3;//设置默认文件类型显示顺序 
            savedlg.RestoreDirectory = true; //点了保存按钮进入if (picBox1.Image != null)
            if (savedlg.ShowDialog() == DialogResult.OK)
            {
                string pictureName = savedlg.FileName;
                //照片另存
                using (MemoryStream mem = new MemoryStream())
                {
                    //这句很重要，不然不能正确保存图片或出错（关键就这一句）
                    //保存到磁盘文件
                    datas.desImage.Save(@pictureName, datas.originalBitmap.RawFormat);
                    System.Windows.Forms.MessageBox.Show("附件另存成功！", "注意", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("没有附件信息！", "注意", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            label5.Text = "未工作";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (datas.desImage != null)
            {
                label5.Text = "工作中";
            System.Windows.Forms.Application.DoEvents();
            datas.desImage = BitmapHelper.reducenoise(datas.desImage);
            datas.stackPosition++;
            datas.stackUndo.Add(datas.desImage);
            datas.Form1.picture1.Image = datas.desImage;
            datas.Form1.Show();
            label5.Text = "未工作";
            }
            else
                System.Windows.Forms.MessageBox.Show("请先导入一张图片");
            label5.Text = "未工作";
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            
            label5.Text = "工作中";
            if (datas.desImage != null)
            {
                System.Windows.Forms.Application.DoEvents();
                datas.desImage = BitmapHelper.oilpaint(datas.desImage);
                datas.stackPosition++;
                datas.stackUndo.Add(datas.desImage);
                datas.Form1.picture1.Image = datas.desImage;
                datas.Form1.Show();
            }
            else
                System.Windows.Forms.MessageBox.Show("请先导入一张图片");
            label5.Text = "未工作";
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (datas.desImage != null)
            {
                label5.Text = "工作中";
            System.Windows.Forms.Application.DoEvents();
            datas.desImage = BitmapHelper.emboss(datas.desImage);
            datas.stackPosition++;
            datas.stackUndo.Add(datas.desImage);
            datas.Form1.picture1.Image = datas.desImage;
            datas.Form1.Show();
            label5.Text = "未工作";
            }
            else
                System.Windows.Forms.MessageBox.Show("请先导入一张图片");
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            if (datas.desImage != null)
            {
                label5.Text = "工作中";
            System.Windows.Forms.Application.DoEvents();
            datas.desImage = BitmapHelper.charcoal(datas.desImage);
            datas.stackPosition++;
            datas.stackUndo.Add(datas.desImage);
            datas.Form1.picture1.Image = datas.desImage;
            datas.Form1.Show();
            label5.Text = "未工作";
            }
            else
                System.Windows.Forms.MessageBox.Show("请先导入一张图片");
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            if (datas.desImage != null)
            {
                label5.Text = "工作中";
            System.Windows.Forms.Application.DoEvents();
            datas.desImage = BitmapHelper.cannyedge(datas.desImage);
            datas.stackPosition++;
            datas.stackUndo.Add(datas.desImage);
            datas.Form1.picture1.Image = datas.desImage;
            datas.Form1.Show();
            label5.Text = "未工作";
            }
            else
                System.Windows.Forms.MessageBox.Show("请先导入一张图片");
        }

        private void Button16_Click(object sender, EventArgs e)
        {
            if (datas.desImage != null)
            {
                label5.Text = "工作中";
            System.Windows.Forms.Application.DoEvents();
            datas.desImage = BitmapHelper.negate(datas.desImage);
            datas.stackPosition++;
            datas.stackUndo.Add(datas.desImage);
            datas.Form1.picture1.Image = datas.desImage;
            datas.Form1.Show();
            label5.Text = "未工作";
            }
            else
                System.Windows.Forms.MessageBox.Show("请先导入一张图片");
        }

        private void Button17_Click(object sender, EventArgs e)
        {
            if (datas.desImage != null)
            {
                label5.Text = "工作中";
                System.Windows.Forms.Application.DoEvents();
                datas.desImage = BitmapHelper.polar(datas.desImage);
                datas.stackPosition++;
                datas.stackUndo.Add(datas.desImage);
                datas.Form1.picture1.Image = datas.desImage;
                datas.Form1.Show();
                label5.Text = "未工作";
            }
            else
                System.Windows.Forms.MessageBox.Show("请先导入一张图片");
            }

        private void Button18_Click(object sender, EventArgs e)
        {
            if (datas.desImage != null)
            {
                label5.Text = "工作中";
                System.Windows.Forms.Application.DoEvents();
                datas.desImage = BitmapHelper.arc(datas.desImage);
                datas.stackPosition++;
                datas.stackUndo.Add(datas.desImage);
                datas.Form1.picture1.Image = datas.desImage;
                datas.Form1.Show();
                label5.Text = "未工作";
            }
            else
                System.Windows.Forms.MessageBox.Show("请先导入一张图片");
            
        }

        private void Button19_Click(object sender, EventArgs e)
        {
            if (datas.desImage != null)
            {
                label5.Text = "工作中";
                System.Windows.Forms.Application.DoEvents();
                datas.desImage = BitmapHelper.wave(datas.desImage);
                datas.stackPosition++;
                datas.stackUndo.Add(datas.desImage);
                datas.Form1.picture1.Image = datas.desImage;
                datas.Form1.Show();
                label5.Text = "未工作";
            }
            else
                System.Windows.Forms.MessageBox.Show("请先导入一张图片");
    }

        private void Button21_Click(object sender, EventArgs e)
        {
            if (datas.desImage != null)
            {
                label5.Text = "工作中";
                System.Windows.Forms.Application.DoEvents();
                datas.desImage = BitmapHelper.sepiatone(datas.desImage);
                datas.stackPosition++;
                datas.stackUndo.Add(datas.desImage);
                datas.Form1.picture1.Image = datas.desImage;
                datas.Form1.Show();
                label5.Text = "未工作";
            }
            else
                System.Windows.Forms.MessageBox.Show("请先导入一张图片");
            }

        private void Button22_Click(object sender, EventArgs e)
        {
            if (datas.desImage != null)
            {
            label5.Text = "工作中";
            System.Windows.Forms.Application.DoEvents();
            string choice = string.Empty;
            ChooseDialog.Show(out choice);
            if (string.IsNullOrWhiteSpace(choice))
            {
                return;
            }
            int a = int.Parse(choice);
            datas.ran = BitmapHelper.getRan(a);
            datas.desImage = BitmapHelper.effect(datas.desImage, datas.ran);
            label7.Text = datas.showeffect[0] + "\n\n" + datas.showeffect[1] + "\n\n" + datas.showeffect[2] + "\n\n" + datas.showeffect[3] + "\n\n" + datas.showeffect[4];
            System.Windows.Forms.Application.DoEvents();
            datas.stackPosition++;
            datas.stackUndo.Add(datas.desImage);
            datas.Form1.picture1.Image = datas.desImage;
            datas.Form1.Show();
            label5.Text = "未工作";
            }
            else
                System.Windows.Forms.MessageBox.Show("请先导入一张图片");
        }

        private void SplitContainer3_Panel1_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            label5.Text = "工作中";
            System.Windows.Forms.Application.DoEvents();
            string file = ((System.Array)e.Data.GetData(System.Windows.Forms.DataFormats.FileDrop)).GetValue(0).ToString();
                srcBitmap = (Bitmap)Bitmap.FromFile(file, false);
                datas.originalBitmap = srcBitmap;
                datas.desImage = datas.originalBitmap;
                datas.stackUndo.Add(datas.originalBitmap);
                // datas.cutwidth = srcBitmap.Width;
                // datas.cutheight = srcBitmap.Height;
                Point ptLoction = new Point(datas.originalBitmap.Size);

                datas.Form1 = new showphoto();//放到初始化去了

                datas.Form1.picture1.Image = datas.desImage;
                datas.Form1.TopLevel = false;
                splitContainer3.Panel1.Controls.Add(datas.Form1);

                if (ptLoction.X > datas.Form1.Size.Width || ptLoction.Y > datas.Form1.Size.Height)
                {
                    //相框停靠   
                    datas.Form1.picture1.Dock = DockStyle.Fill;

                    //充滿圖像框，並且圖像維持比例   
                    datas.Form1.picture1.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    //在圖像框置中   
                    datas.Form1.picture1.SizeMode = PictureBoxSizeMode.CenterImage;
                }

                //LoadAsync：非同步載入圖像   
                datas.Form1.Show();
                datas.Form1.picture1.LoadAsync(file.ToString());


                ////顯示圖像名 lblNameValue:label控件   
                //lblNameValue.Text = sPicName;   
                ////顯示圖像大小  lblLengthValue:label控件   
                //lblLengthValue.Text = lPicLong.ToString() + " KB";   
                ////顯示圖像尺寸 lblSizeValue:label控件   
                //lblSizeValue.Text = bmPic.Size.Width.ToString() + "×" + bmPic.Size.Height.ToString();   
            
            label5.Text = "未工作";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if(datas.desImage!=null)
            {
                label5.Text = "工作中";
                System.Windows.Forms.Application.DoEvents();
                datas.desImage = BitmapHelper.spread(datas.desImage);
                datas.stackPosition++;
                datas.stackUndo.Add(datas.desImage);
                datas.Form1.picture1.Image = datas.desImage;
                datas.Form1.Show();
                label5.Text = "未工作";
            }
            else
                System.Windows.Forms.MessageBox.Show("请先导入一张图片");
        }

        private void Button20_Click(object sender, EventArgs e)
        {
            if (datas.desImage != null)
            {
                label5.Text = "工作中";
            System.Windows.Forms.Application.DoEvents();
            Bitmap bitmap = (Bitmap)datas.desImage;
            datas.desImage = BitmapHelper.Image_Sharpen(bitmap);
            datas.desImage = BitmapHelper.Image_Sharpen((Bitmap)datas.desImage);
            datas.stackPosition++;
            datas.stackUndo.Add(datas.desImage);
            datas.Form1.picture1.Image = datas.desImage;
            datas.Form1.Show();
            label5.Text = "未工作";
            }
            else
                System.Windows.Forms.MessageBox.Show("请先导入一张图片");
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("作者：郑宇博 杨奕冉"+"\n"+"制作时间：>100h"+"\n"+"源代码行数：>1500行"+"\n"+"累计代码量：3000行"+"\n"+"此程序为原创，拒绝抄袭");
        }
    }
}
