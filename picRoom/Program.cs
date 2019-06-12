using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;
using System.Collections;
using System.Windows.Media.Imaging;
using ImageMagick;

namespace picRoom
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
        
    }

     

    public class datas
    {
        public static Bitmap originalBitmap;    //初始导入的图片
        public static Image desImage;           //用于输出和显示的图片
        public static showphoto Form1 ;         //提前声明的图片显示窗体
        public static int command;              //堆栈用变量   
        public static int stackPosition=0;      //撤销功能所用堆栈指针
        public static List<Image> stackUndo = new List<Image>();    //为撤销功能所建堆栈
        public static int[] ran;
        public static string[] showeffect;
    }
    


    public static class BitmapHelper
    {

        public static Bitmap reducenoise(Image sourceimg)
        {
            if (sourceimg != null)
            {
                ImageMagick.MagickImage originalMagickImage;
                originalMagickImage = new ImageMagick.MagickImage((Bitmap)sourceimg);
                originalMagickImage.ReduceNoise();
                Bitmap bitmap = originalMagickImage.ToBitmap();
                return bitmap;
            }
            else
                return (Bitmap)sourceimg;
        }

        public static Bitmap oilpaint(Image sourceimg)
        {
            if (sourceimg != null)
            {
                ImageMagick.MagickImage originalMagickImage;
                originalMagickImage = new ImageMagick.MagickImage((Bitmap)sourceimg);
                originalMagickImage.OilPaint();
                Bitmap bitmap = originalMagickImage.ToBitmap();
                return bitmap;
            }
            else
                return (Bitmap)sourceimg;
        }

        public static Bitmap emboss(Image sourceimg)
        {
            if (sourceimg != null)
            {
                ImageMagick.MagickImage originalMagickImage;
                originalMagickImage = new ImageMagick.MagickImage((Bitmap)sourceimg);
                originalMagickImage.Emboss();
                Bitmap bitmap = originalMagickImage.ToBitmap();
                return bitmap;
            }
            else
                return (Bitmap)sourceimg;
        }

        public static Bitmap charcoal(Image sourceimg)
        {
            if (sourceimg != null)
            {
                ImageMagick.MagickImage originalMagickImage;
            originalMagickImage = new ImageMagick.MagickImage((Bitmap)sourceimg);
            originalMagickImage.Charcoal(5, 0);
            Bitmap bitmap = originalMagickImage.ToBitmap();
            return bitmap;
            }
            else
                return (Bitmap)sourceimg;
        }

        public static Bitmap cannyedge(Image sourceimg)
        {
            if (sourceimg != null)
            {
                ImageMagick.MagickImage originalMagickImage;
            originalMagickImage = new ImageMagick.MagickImage((Bitmap)sourceimg);
            originalMagickImage.CannyEdge();
            Bitmap bitmap = originalMagickImage.ToBitmap();
            return bitmap;
            }
            else
                return (Bitmap)sourceimg;
        }

        public static Bitmap negate(Image sourceimg)
        {
            if (sourceimg != null)
            {
                ImageMagick.MagickImage originalMagickImage;
            originalMagickImage = new ImageMagick.MagickImage((Bitmap)sourceimg);
            originalMagickImage.Negate();
            Bitmap bitmap = originalMagickImage.ToBitmap();
            return bitmap;
            }
            else
                return (Bitmap) sourceimg;
    }

        public static Bitmap spread(Image sourceimg)
        {
            if (sourceimg != null)
            {
                ImageMagick.MagickImage originalMagickImage;
                originalMagickImage = new ImageMagick.MagickImage((Bitmap)sourceimg);
                originalMagickImage.Spread();
                Bitmap bitmap = originalMagickImage.ToBitmap();
                return bitmap;
            }
            else
                return (Bitmap)sourceimg;
        }

        public static Bitmap polar(Image sourceimg)
        {
            if (sourceimg != null)
            {
                ImageMagick.MagickImage originalMagickImage;
            originalMagickImage = new ImageMagick.MagickImage((Bitmap)sourceimg);
            originalMagickImage.Distort(DistortMethod.Polar, 0);
            Bitmap bitmap = originalMagickImage.ToBitmap();
            return bitmap;
            }
            else
                return (Bitmap)sourceimg;
        }

        public static Bitmap arc(Image sourceimg)
        {
            if (sourceimg != null)
            {
                ImageMagick.MagickImage originalMagickImage;
            originalMagickImage = new ImageMagick.MagickImage((Bitmap)sourceimg);
            originalMagickImage.Distort(DistortMethod.Arc, 360);
            Bitmap bitmap = originalMagickImage.ToBitmap();
            return bitmap;
            }
            else
                return (Bitmap)sourceimg;
        }

        public static Bitmap sharpen(Image sourceimg)
        {
            if (sourceimg != null)
            {
                ImageMagick.MagickImage originalMagickImage;
                originalMagickImage = new ImageMagick.MagickImage((Bitmap)sourceimg);
                originalMagickImage.Sharpen();
                Bitmap bitmap = originalMagickImage.ToBitmap();
                return bitmap;
            }
            else
                return (Bitmap)sourceimg;
        }

        public static Bitmap wave(Image sourceimg)
        {
            if (sourceimg != null)
            {
                ImageMagick.MagickImage originalMagickImage;
            originalMagickImage = new ImageMagick.MagickImage((Bitmap)sourceimg);
            originalMagickImage.Wave();
            Bitmap bitmap = originalMagickImage.ToBitmap();
            return bitmap;
        }
            else
                return (Bitmap) sourceimg;
    }

        public static Bitmap sepiatone(Image sourceimg)
        {
            if (sourceimg != null)
            {
                ImageMagick.MagickImage originalMagickImage;
            originalMagickImage = new ImageMagick.MagickImage((Bitmap)sourceimg);
            originalMagickImage.SepiaTone();
            Bitmap bitmap = originalMagickImage.ToBitmap();
            return bitmap;
            }
            else
                return (Bitmap)sourceimg;
        }

        /// <summary>
        /// 随机数组
        /// </summary>
        /// <param name="n">随机选取效果的数量</param>
        /// <returns></returns>
        public static int[] getRan(int n)//给随机数组赋值
        {
            Random ra = new Random(unchecked((int)DateTime.Now.Ticks));
            int[] arrNum = new int[5] { 0, 0, 0, 0, 0 };
            int tmp = 0;
            for (int j = 0; j < n; j++)
            {
                tmp = ra.Next(1, 10); //随机取数
                arrNum[j] = getNum(arrNum, tmp, ra); //取出值赋到数组中
            }
            return arrNum;
        }

        public static int getNum(int[] arrNum, int tmp, Random ra)//取随机数循环检测其是否重复，重复则重新取值
        {
            int n = 0;
            while (n <= arrNum.Length - 1)
            {
                if (arrNum[n] == tmp) //利用循环判断是否有重复
                {
                    tmp = ra.Next(1, 10); //重新随机获取。
                    getNum(arrNum, tmp, ra);//递归:如果取出来的数字和已取得的数字有重复就重新随机获取。
                }
                n++;
            }
            return tmp;
        }

        public static Bitmap effect(Image sourceimg, int[] array)//由随机数组取值情况添加效果
        {
            datas.showeffect = new string[5];
            Image tmp = datas.desImage;
            for (int i = 0; i <= 4; i++)
            {
                switch (array[i])
                {
                    case 1:
                        tmp = oilpaint(tmp);
                        datas.showeffect[i] = "油画效果";
                        break;
                    case 2:
                        tmp = emboss(tmp);
                        datas.showeffect[i] = "浮雕效果";
                        break;
                    case 3:
                        tmp = charcoal(tmp);
                        datas.showeffect[i] = "素描效果";
                        break;
                    case 4:
                        tmp = cannyedge(tmp);
                        datas.showeffect[i] = "描边效果";
                        break;
                    case 5:
                        tmp = negate(tmp);
                        datas.showeffect[i] = "反向效果";
                        break;
                    case 6:
                        tmp = polar(tmp);
                        datas.showeffect[i] = "极面效果";
                        break;
                    case 7:
                        tmp = arc(tmp);
                        datas.showeffect[i] = "圆弧效果";
                        break;
                    case 8:
                        tmp = wave(tmp);
                        datas.showeffect[i] = "波浪效果";
                        break;
                    case 9:
                        tmp = sepiatone(tmp);
                        datas.showeffect[i] = "褐色效果";
                        break;
                    case 10:
                        tmp = sepiatone(tmp);
                        datas.showeffect[i] = "扩散效果";
                        break;
                    default:
                        break;
                }
            }
            return (Bitmap)tmp;
        }
        public static Bitmap KiRotateY(Bitmap img)//竖直反转
        {
            try
            {
                img.RotateFlip(RotateFlipType.Rotate180FlipX);
                return img;
            }
            catch
            {
                return null;
            }
        }
        public static Bitmap KiRotateX(Bitmap img)//水平翻转
        {
            try
            {
                img.RotateFlip(RotateFlipType.Rotate180FlipY);
                return img;
            }
            catch
            {
                return null;
            }
        }
        public static Bitmap KiRotate270(Bitmap img)//逆时针旋转90
        {
            try
            {
                img.RotateFlip(RotateFlipType.Rotate270FlipNone);
                return img;
            }
            catch
            {
                return null;
            }
        }
        public static Bitmap KiRotate90(Bitmap img)//顺时针旋转90
        {
            try
            {
                img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                return img;
            }
            catch
            {
                return null;
            }
        }
        public static Bitmap Image_Sharpen(this Bitmap sourceBitmap)
        {
            if (sourceBitmap != null)
            {
                int Height = sourceBitmap.Height;
                int Width = sourceBitmap.Width;
                Bitmap bitmap = new Bitmap(Width, Height, PixelFormat.Format32bppRgb);
                Bitmap MyBitmap = (Bitmap)sourceBitmap;

                BitmapData oldData = MyBitmap.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppRgb);
                BitmapData newData = bitmap.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
                unsafe
                {
                    byte* pin = (byte*)(oldData.Scan0.ToPointer());
                    byte* pout = (byte*)(newData.Scan0.ToPointer());
                    //拉普拉斯模板
                    int[] Laplacian = { -1, -1, -1, -1, 9, -1, -1, -1, -1 };
                    for (int i = 1; i < Width - 1; i++)
                    {
                        for (int j = 1; j < Height - 1; j++)
                        {
                            int r = 0, g = 0, b = 0;
                            int Index = 0;

                            for (int col = -1; col <= 1; col++)
                            {
                                for (int row = -1; row <= 1; row++)
                                {
                                    int off = ((j + row) * (Width) + (i + col)) * 4;
                                    r += pin[off + 0] * Laplacian[Index];
                                    g += pin[off + 1] * Laplacian[Index];
                                    b += pin[off + 2] * Laplacian[Index];
                                    Index++;
                                }
                            }

                            if (r < 0) r = 0;
                            if (r > 255) r = 255;
                            if (g < 0) g = 0;
                            if (g > 255) g = 255;
                            if (b < 0) b = 0;
                            if (b > 255) b = 255;
                            int off2 = (j * Width + i) * 4;
                            pout[off2 + 0] = (byte)r;
                            pout[off2 + 1] = (byte)g;
                            pout[off2 + 2] = (byte)b;
                        }
                    }
                    bitmap.UnlockBits(newData);
                    MyBitmap.UnlockBits(oldData);
                return bitmap;
                }
            }
            else
                return sourceBitmap;
        }

            public static Bitmap Image_Soften(this Bitmap sourceBitmap)
        {
            if (sourceBitmap != null)
            {
            int Height = sourceBitmap.Height;
            int Width = sourceBitmap.Width;
            Bitmap bitmap = new Bitmap(Width, Height, PixelFormat.Format32bppRgb);
            Bitmap MyBitmap = (Bitmap)sourceBitmap;

            BitmapData oldData = MyBitmap.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppRgb);
            BitmapData newData = bitmap.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
            unsafe
                {
                    byte* pin = (byte*)(oldData.Scan0.ToPointer());
                    byte* pout = (byte*)(newData.Scan0.ToPointer());
                    //高斯模板
                    int[] Gauss = { 1, 2, 1, 2, 4, 2, 1, 2, 1 };
                    for (int i = 1; i < Width - 1; i++)
                    {
                        for (int j = 1; j < Height - 1; j++)
                        {
                            int r = 0, g = 0, b = 0;
                            int Index = 0;

                            for (int col = -1; col <= 1; col++)
                            {
                                for (int row = -1; row <= 1; row++)
                                {
                                    int off = ((j + row) * (Width) + (i + col)) * 4;
                                    r += pin[off + 0] * Gauss[Index];
                                    g += pin[off + 1] * Gauss[Index];
                                    b += pin[off + 2] * Gauss[Index];
                                    Index++;
                                }
                            }
                            r /= 16;
                            g /= 16;
                            b /= 16;
                            //处理颜色值溢出
                            if (r < 0) r = 0;
                            if (r > 255) r = 255;
                            if (g < 0) g = 0;
                            if (g > 255) g = 255;
                            if (b < 0) b = 0;
                            if (b > 255) b = 255;
                            int off2 = (j * Width + i) * 4;
                            pout[off2 + 0] = (byte)r;
                            pout[off2 + 1] = (byte)g;
                            pout[off2 + 2] = (byte)b;
                        }
                    }
                    bitmap.UnlockBits(newData);
                    MyBitmap.UnlockBits(oldData);
                    return bitmap;
                }
            }
            else
                return sourceBitmap;
        }
        public static Bitmap encode(Image sourceimg,string code)
        {
            if (sourceimg != null)
            {
                ImageMagick.MagickImage originalMagickImage;
                originalMagickImage = new ImageMagick.MagickImage((Bitmap)sourceimg);
                originalMagickImage.Encipher(code);
                Bitmap bitmap = originalMagickImage.ToBitmap();
                return bitmap;
            }
            else
                return (Bitmap)sourceimg;
        }
        public static Bitmap decode(Image sourceimg, string code)
        {
            if (sourceimg != null)
            {
                ImageMagick.MagickImage originalMagickImage;
            originalMagickImage = new ImageMagick.MagickImage((Bitmap)sourceimg);
            originalMagickImage.Decipher(code);
            Bitmap bitmap = originalMagickImage.ToBitmap();
            return bitmap;
            }
            else
                return (Bitmap)sourceimg;
        }
        /// <summary>
        /// 色相、饱和度、亮度、对比度
        /// </summary>
        /// <param name="sourceimg"></param>
        /// <param name="threshold"></param>
        /// <returns></returns>
        public static Bitmap HSLC(Image sourceimg, int H, int S, int L, int C)
        {
            if (sourceimg != null)
            {
                ImageMagick.MagickImage originalMagickImage;
                originalMagickImage = new ImageMagick.MagickImage((Bitmap)sourceimg);
                // 只调整图像的Hue色相值
                ImageMagick.Percentage brightness = new ImageMagick.Percentage(L); // 100%表示不改变该属性
                ImageMagick.Percentage saturation = new ImageMagick.Percentage(S);
                ImageMagick.Percentage hue = new ImageMagick.Percentage(H); // 滑动条范围值0%~200%
                ImageMagick.MagickImage newImage = new ImageMagick.MagickImage(originalMagickImage); // 相当于深复制
                newImage.Modulate(brightness, saturation, hue);
                // 重新给Image控件赋值新图像
                Bitmap bitmap1 = newImage.ToBitmap();
                Bitmap bitmap = Contrast(bitmap1, C);
                return bitmap;
            }
            else
                return (Bitmap)sourceimg;

        }

        /// <summary>
        /// 饱和度
        /// </summary>
        /// <param name="sourceBitmap"></param>
        /// <param name="threshold"></param>
        /// <returns></returns> 


        public static Bitmap Contrast(this Bitmap sourceBitmap, int threshold)
        {
            if (sourceBitmap != null)
            {
                BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0,
                                            sourceBitmap.Width, sourceBitmap.Height),
                                            ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];

                Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);

                sourceBitmap.UnlockBits(sourceData);

                double contrastLevel = Math.Pow((100.0 + threshold) / 100.0, 2);

                double blue = 0;
                double green = 0;
                double red = 0;

                for (int k = 0; k + 4 < pixelBuffer.Length; k += 4)
                {
                    blue = ((((pixelBuffer[k] / 255.0) - 0.5) *
                                contrastLevel) + 0.5) * 255.0;

                    green = ((((pixelBuffer[k + 1] / 255.0) - 0.5) *
                                contrastLevel) + 0.5) * 255.0;

                    red = ((((pixelBuffer[k + 2] / 255.0) - 0.5) *
                                contrastLevel) + 0.5) * 255.0;

                    if (blue > 255)
                    { blue = 255; }
                    else if (blue < 0)
                    { blue = 0; }

                    if (green > 255)
                    { green = 255; }
                    else if (green < 0)
                    { green = 0; }

                    if (red > 255)
                    { red = 255; }
                    else if (red < 0)
                    { red = 0; }

                    pixelBuffer[k] = (byte)blue;
                    pixelBuffer[k + 1] = (byte)green;
                    pixelBuffer[k + 2] = (byte)red;
                }

                Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);

                BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0,
                                            resultBitmap.Width, resultBitmap.Height),
                                            ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

                Marshal.Copy(pixelBuffer, 0, resultData.Scan0, pixelBuffer.Length);
                resultBitmap.UnlockBits(resultData);
                return resultBitmap;
            }
            else
                return sourceBitmap;
        }
        public static Bitmap Light_change(this Bitmap sourceBitmap, int degree)
        {
            if (sourceBitmap != null)
            {
                if (degree < -255) degree = -255;
                if (degree > 255) degree = 255;
                BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0,
                                            sourceBitmap.Width, sourceBitmap.Height),
                                            ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];

                Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);

                sourceBitmap.UnlockBits(sourceData);



                double blue = 0;
                double green = 0;
                double red = 0;

                for (int k = 0; k + 4 < pixelBuffer.Length; k += 4)
                {
                    blue = pixelBuffer[k] + degree;

                    green = pixelBuffer[k + 1] + degree;

                    red = pixelBuffer[k + 2] + degree;

                    if (blue > 255)
                    { blue = 255; }
                    else if (blue < 0)
                    { blue = 0; }

                    if (green > 255)
                    { green = 255; }
                    else if (green < 0)
                    { green = 0; }

                    if (red > 255)
                    { red = 255; }
                    else if (red < 0)
                    { red = 0; }

                    pixelBuffer[k] = (byte)blue;
                    pixelBuffer[k + 1] = (byte)green;
                    pixelBuffer[k + 2] = (byte)red;
                }

                Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);

                BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0,
                                            resultBitmap.Width, resultBitmap.Height),
                                            ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

                Marshal.Copy(pixelBuffer, 0, resultData.Scan0, pixelBuffer.Length);
                resultBitmap.UnlockBits(resultData);
                return resultBitmap;
            }
            else
                return sourceBitmap;
        }

        internal static Image encode(string strText)
        {
            throw new NotImplementedException();
        }
    }

    public static class InputDialog
    {
        public static DialogResult Show(out string strText)
        {
            string strTemp = string.Empty;

           encode inputDialog = new encode();
            inputDialog.TextHandler = (str) => { strTemp = str; };

            DialogResult result = inputDialog.ShowDialog();
            strText = strTemp;

            return result;
        }
    }
    public static class ChooseDialog
    {
        public static DialogResult Show(out string strText)
        {

            choose inputDialog = new choose();

            DialogResult result = inputDialog.ShowDialog();
            strText = choose.choice;

            return result;
        }
    }

}

