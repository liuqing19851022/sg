using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;
using ZXing.QrCode;
using ZXing.QrCode.Internal;
using ZXing.Common;


namespace MJUSS.Infrastructure.Utils.QrCodeTool
{
    //    /// <summary>
    //    /// 二维码二维码helper (ThoughtWorks组件)
    //    /// </summary>
    //    public class QrCodeTool
    //    {
    //        /// <summary>  
    //        /// 保存图片  
    //        /// </summary>  
    //        /// <param name="strPath">保存路径</param>  
    //        /// <param name="img">图片</param>  
    //        public static void SaveImg(string strPath, Bitmap img, string qrcid)
    //        {
    //            //当前目录不存在，则创建  
    //            if (!Directory.Exists(strPath))
    //                Directory.CreateDirectory(strPath);

    //            //文件名称  
    //            //string guid = Guid.NewGuid().ToString().Replace("-", "") + ".png";
    //            string filename = qrcid + ".png";
    //            img.Save(strPath + "/" + filename, System.Drawing.Imaging.ImageFormat.Png);
    //        }
    //        public static void SaveImg(string strPath, Image img, string qrcid)
    //        {
    //            //当前目录不存在，则创建  
    //            if (!Directory.Exists(strPath))
    //                Directory.CreateDirectory(strPath);

    //            //文件名称  
    //            //string guid = Guid.NewGuid().ToString().Replace("-", "") + ".png";
    //            string filename = qrcid + ".png";
    //            img.Save(strPath + "/" + filename, System.Drawing.Imaging.ImageFormat.Png);
    //        }
    //        /// <summary>  
    //        /// 生成二维码图片  
    //        /// </summary>  
    //        /// <param name="codeNumber">要生成二维码的字符串</param>       
    //        /// <param name="size">大小尺寸</param>  
    //        /// <returns>二维码图片</returns>  
    //        public static Bitmap Create_ImgCode(string codeNumber, int size)
    //        {
    //            //创建二维码生成类  
    //            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
    //            //设置编码模式  
    //            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
    //            //设置编码测量度  
    //            qrCodeEncoder.QRCodeScale = size;
    //            //设置编码版本  
    //            qrCodeEncoder.QRCodeVersion = 0;
    //            //设置编码错误纠正  
    //            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
    //            //生成二维码图片  
    //            System.Drawing.Bitmap image = qrCodeEncoder.Encode("http://zcl.mjzhcl.com/QrCode/" + codeNumber);
    //            return image;
    //        }

    //        /// <summary>  
    //        /// /打开指定目录  
    //        /// </summary>  
    //        /// <param name="path"></param>  
    //        public static void Open_File(string path)
    //        {
    //            System.Diagnostics.Process.Start("explorer.exe", path);
    //        }
    //        /// <summary>  
    //        /// 删除目录下所有文件  
    //        /// </summary>  
    //        /// <param name="aimPath">路径</param>  
    //        public static void DeleteDir(string aimPath)
    //        {
    //            try
    //            {
    //                //目录是否存在  
    //                if (Directory.Exists(aimPath))
    //                {
    //                    // 检查目标目录是否以目录分割字符结束如果不是则添加之  
    //                    if (aimPath[aimPath.Length - 1] != Path.DirectorySeparatorChar)
    //                        aimPath += Path.DirectorySeparatorChar;
    //                    // 得到源目录的文件列表，该里面是包含文件以及目录路径的一个数组  
    //                    // 如果你指向Delete目标文件下面的文件而不包含目录请使用下面的方法  
    //                    string[] fileList = Directory.GetFiles(aimPath);
    //                    //string[] fileList = Directory.GetFileSystemEntries(aimPath);  
    //                    // 遍历所有的文件和目录  
    //                    foreach (string file in fileList)
    //                    {
    //                        // 先当作目录处理如果存在这个目录就递归Delete该目录下面的文件  
    //                        if (Directory.Exists(file))
    //                        {
    //                            DeleteDir(aimPath + Path.GetFileName(file));
    //                        }
    //                        // 否则直接Delete文件  
    //                        else
    //                        {
    //                            File.Delete(aimPath + Path.GetFileName(file));
    //                        }
    //                    }
    //                }
    //            }
    //            catch (Exception e)
    //            {
    //                throw e;
    //            }
    //        }

    //        /// <summary>
    //        /// 调用此函数后使此两种图片合并，类似相册，有个
    //        /// 背景图，中间贴自己的目标图片
    //        /// </summary>
    //        /// <param name="imgBack">粘贴的源图片</param>
    //        /// <param name="destImg">粘贴的目标图片</param>
    //        public static Image CombinImage(Image imgBack, string destImg)
    //        {
    //            Image img = Image.FromFile(destImg);    //照片图片
    //            if (img.Height != 65 || img.Width != 65)
    //            {
    //                img = KiResizeImage(img, 65, 65, 0);
    //            }
    //            Graphics g = Graphics.FromImage(imgBack);
    //            g.DrawImage(imgBack, 0, 0, imgBack.Width, imgBack.Height);   //g.DrawImage(imgBack, 0, 0, 相框宽, 相框高);
    //                                                                         //g.FillRectangle(System.Drawing.Brushes.White, imgBack.Width / 2 - img.Width / 2 - 1, imgBack.Width / 2 - img.Width / 2 - 1,1,1);//相片四周刷一层黑色边框
    //                                                                         //g.DrawImage(img, 照片与相框的左边距, 照片与相框的上边距, 照片宽, 照片高);
    //            g.DrawImage(img, imgBack.Width / 2 - img.Width / 2, imgBack.Width / 2 - img.Width / 2, img.Width, img.Height);
    //            GC.Collect();
    //            return imgBack;
    //        }

    //        public static Bitmap CombinImage(Bitmap imgBack, string destImg)
    //        {
    //            Image img = Bitmap.FromFile(destImg);    //照片图片
    //            if (img.Height != 65 || img.Width != 65)
    //            {
    //                img = KiResizeImage(img, 65, 65, 0);
    //            }
    //            Graphics g = Graphics.FromImage(imgBack);
    //            g.DrawImage(imgBack, 0, 0, imgBack.Width, imgBack.Height);   //g.DrawImage(imgBack, 0, 0, 相框宽, 相框高);
    //                                                                         //g.FillRectangle(System.Drawing.Brushes.White, imgBack.Width / 2 - img.Width / 2 - 1, imgBack.Width / 2 - img.Width / 2 - 1,1,1);//相片四周刷一层黑色边框
    //                                                                         //g.DrawImage(img, 照片与相框的左边距, 照片与相框的上边距, 照片宽, 照片高);
    //            g.DrawImage(img, imgBack.Width / 2 - img.Width / 2, imgBack.Width / 2 - img.Width / 2, img.Width, img.Height);
    //            GC.Collect();
    //            return imgBack;
    //        }
    //        /// <summary>
    //        /// Resize图片
    //        /// </summary>
    //        /// <param name="bmp">原始Bitmap</param>
    //        /// <param name="newW">新的宽度</param>
    //        /// <param name="newH">新的高度</param>
    //        /// <param name="Mode">保留着，暂时未用</param>
    //        /// <returns>处理以后的图片</returns>
    //        public static Image KiResizeImage(Image bmp, int newW, int newH, int Mode)
    //        {
    //            try
    //            {
    //                Bitmap b = new Bitmap(newW, newH);
    //                Graphics g = Graphics.FromImage(b);
    //                // 插值算法的质量
    //                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
    //                g.DrawImage(bmp, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
    //                g.Dispose();
    //                return b;
    //            }
    //            catch
    //            {
    //                return null;
    //            }
    //        }
    //    }

    /// <summary>
    /// 二维码helper(ZXing组件)
    /// </summary>
    public class ZXingQrCodeHelper
    {
        public static Bitmap GetThumbnail(System.Drawing.Image b, int destHeight, int destWidth)
        {
            System.Drawing.Image imgSource = b;
            System.Drawing.Imaging.ImageFormat thisFormat = imgSource.RawFormat;
            int sW = 0, sH = 0;
            // 按比例缩放 
            int sWidth = imgSource.Width;
            int sHeight = imgSource.Height;
            if (sHeight > destHeight || sWidth > destWidth)
            {
                if ((sWidth * destHeight) > (sHeight * destWidth))
                {
                    sW = destWidth;
                    sH = (destWidth * sHeight) / sWidth;
                }
                else
                {
                    sH = destHeight;
                    sW = (sWidth * destHeight) / sHeight;
                }
            }
            else
            {
                sW = sWidth;
                sH = sHeight;
            }
            Bitmap outBmp = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage(outBmp);
            g.Clear(Color.Transparent);
            // 设置画布的描绘质量 
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(imgSource, new Rectangle((destWidth - sW) / 2, (destHeight - sH) / 2, sW, sH), 0, 0, imgSource.Width, imgSource.Height, GraphicsUnit.Pixel);
            g.Dispose();
            // 以下代码为保存图片时，设置压缩质量 
            EncoderParameters encoderParams = new EncoderParameters();
            long[] quality = new long[1];
            quality[0] = 100;
            EncoderParameter encoderParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            encoderParams.Param[0] = encoderParam;
            imgSource.Dispose();
            return outBmp;
        }
        public static Bitmap Create(string content, int size)
        {
            try
            {
                var writer = new BarcodeWriter<Bitmap>
                {
                    Format = BarcodeFormat.QR_CODE
                };
                QrCodeEncodingOptions options = new QrCodeEncodingOptions()
                {
                    DisableECI = true,//设置内容编码
                    CharacterSet = "UTF-8",  //设置二维码的宽度和高度
                    Width = size,
                    Height = size,
                    Margin = 1//设置二维码的边距,单位不是固定像素
                };

                writer.Options = options;
                Bitmap map = writer.Write(content);
                return map;
            }
            catch
            {
                return null;
            }
        }
    }

    public class ImageUtility
    {
        #region 合并用户QR图片和用户头像
        /// <summary>
        /// 合并用户QR图片和底部文字
        /// </summary>
        /// <param name="qrImg">QR图片</param>
        /// <param name="bottomCode">二维码底部写的内容</param>
        /// <param name="n">缩放比例</param>
        /// <returns></returns>
        public static Bitmap MergeQrImg(Bitmap qrImg, string bottomCode, double n = 0.23)
        {
            //二维码底部写字
            var bottom = 50;
            float dpix = qrImg.HorizontalResolution;
            float dpiy = qrImg.VerticalResolution;

            Bitmap backgroudImg2 = new Bitmap(qrImg.Width, qrImg.Height + bottom);
            backgroudImg2.MakeTransparent();
            backgroudImg2.SetResolution(dpix, dpiy);
            Graphics g3 = Graphics.FromImage(backgroudImg2);
            g3.Clear(Color.Transparent);
            g3.DrawImage(qrImg, 0, 0);

            Font myFont = new Font("宋体", 20, FontStyle.Bold);
            Brush fontbrush = new SolidBrush(Color.Black);
            SizeF sizeF = g3.MeasureString(bottomCode, myFont);
            var marginLeft = qrImg.Width - sizeF.Width <= 0 ? 0 : (qrImg.Width - sizeF.Width) / 2;
            var marginHeight = qrImg.Height + (bottom - sizeF.Height <= 0 ? 0 : (bottom - sizeF.Height) / 2);
            PointF center3 = new PointF(marginLeft, marginHeight);
            g3.DrawString(bottomCode, myFont, fontbrush, center3);
            g3.Dispose();

            return backgroudImg2;
        }

        /// <summary>
        /// 合并用户QR图片和logo
        /// </summary>
        /// <param name="qrImg">QR图片</param>
        /// <param name="logo">用户头像</param>
        /// <param name="n">缩放比例</param>
        /// <returns></returns>
        public static Bitmap MergeQrImg(Bitmap qrImg, Bitmap logo, double n = 0.23)
        {
            int margin = 2;
            float dpix = qrImg.HorizontalResolution;
            float dpiy = qrImg.VerticalResolution;
            var _newWidth = (10 * qrImg.Width - 50 * margin) * 1.0f / 50;
            var _headerImg = ZoomPic(logo, _newWidth / logo.Width);
            //处理头像
            int newImgWidth = _headerImg.Width + margin;
            Bitmap headerBgImg = new Bitmap(newImgWidth, newImgWidth);
            headerBgImg.MakeTransparent();
            Graphics g = Graphics.FromImage(headerBgImg);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.Clear(Color.Transparent);
            Pen p = new Pen(new SolidBrush(Color.White));
            Rectangle rect = new Rectangle(0, 0, newImgWidth - 1, newImgWidth - 1);
            using (GraphicsPath path = CreateRoundedRectanglePath(rect, 7))
            {
                g.DrawPath(p, path);
                g.FillPath(new SolidBrush(Color.White), path);
            }
            //画头像
            Bitmap img1 = new Bitmap(_headerImg.Width, _headerImg.Width);
            Graphics g1 = Graphics.FromImage(img1);
            g1.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g1.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g1.Clear(Color.Transparent);
            Pen p1 = new Pen(new SolidBrush(Color.Gray));
            Rectangle rect1 = new Rectangle(0, 0, _headerImg.Width - 1, _headerImg.Width - 1);
            using (GraphicsPath path1 = CreateRoundedRectanglePath(rect1, 7))
            {
                g1.DrawPath(p1, path1);
                TextureBrush brush = new TextureBrush(_headerImg);
                g1.FillPath(brush, path1);
            }
            g1.Dispose();
            PointF center = new PointF((newImgWidth - _headerImg.Width) / 2, (newImgWidth - _headerImg.Height) / 2);
            g.DrawImage(img1, center.X, center.Y, _headerImg.Width, _headerImg.Height);
            g.Dispose();
            Bitmap backgroudImg = new Bitmap(qrImg.Width, qrImg.Height);
            backgroudImg.MakeTransparent();
            backgroudImg.SetResolution(dpix, dpiy);
            headerBgImg.SetResolution(dpix, dpiy);
            Graphics g2 = Graphics.FromImage(backgroudImg);
            g2.Clear(Color.Transparent);
            g2.DrawImage(qrImg, 0, 0);
            PointF center2 = new PointF((qrImg.Width - headerBgImg.Width) / 2, (qrImg.Height - headerBgImg.Height) / 2);
            g2.DrawImage(headerBgImg, center2);
            g2.Dispose();
            return backgroudImg;
        }

        /// <summary>
        /// 合并用户QR图片和logo以及底部写文字
        /// </summary>
        /// <param name="qrImg">QR图片</param>
        /// <param name="logo">用户头像</param>
        /// <param name="bottomCode">二维码底部写的内容</param>
        /// <param name="n">缩放比例</param>
        /// <returns></returns>
        public static Bitmap MergeQrImg(Bitmap qrImg, Bitmap logo, string bottomCode, double n = 0.23)
        {
            int margin = 2;
            float dpix = qrImg.HorizontalResolution;
            float dpiy = qrImg.VerticalResolution;
            var _newWidth = (10 * qrImg.Width - 50 * margin) * 1.0f / 50;
            var _headerImg = ZoomPic(logo, _newWidth / logo.Width);
            //处理头像
            int newImgWidth = _headerImg.Width + margin;
            Bitmap headerBgImg = new Bitmap(newImgWidth, newImgWidth);
            headerBgImg.MakeTransparent();
            Graphics g = Graphics.FromImage(headerBgImg);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.Clear(Color.Transparent);
            Pen p = new Pen(new SolidBrush(Color.White));
            Rectangle rect = new Rectangle(0, 0, newImgWidth - 1, newImgWidth - 1);
            using (GraphicsPath path = CreateRoundedRectanglePath(rect, 7))
            {
                g.DrawPath(p, path);
                g.FillPath(new SolidBrush(Color.White), path);
            }
            //画logo
            Bitmap img1 = new Bitmap(_headerImg.Width, _headerImg.Width);
            Graphics g1 = Graphics.FromImage(img1);
            g1.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g1.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g1.Clear(Color.Transparent);
            Pen p1 = new Pen(new SolidBrush(Color.Gray));
            Rectangle rect1 = new Rectangle(0, 0, _headerImg.Width - 1, _headerImg.Width - 1);
            using (GraphicsPath path1 = CreateRoundedRectanglePath(rect1, 7))
            {
                g1.DrawPath(p1, path1);
                TextureBrush brush = new TextureBrush(_headerImg);
                g1.FillPath(brush, path1);
            }
            g1.Dispose();
            PointF center = new PointF((newImgWidth - _headerImg.Width) / 2, (newImgWidth - _headerImg.Height) / 2);
            g.DrawImage(img1, center.X, center.Y, _headerImg.Width, _headerImg.Height);
            g.Dispose();

            Bitmap backgroudImg = new Bitmap(qrImg.Width, qrImg.Height);
            backgroudImg.MakeTransparent();
            backgroudImg.SetResolution(dpix, dpiy);
            headerBgImg.SetResolution(dpix, dpiy);
            Graphics g2 = Graphics.FromImage(backgroudImg);
            g2.Clear(Color.Transparent);
            g2.DrawImage(qrImg, 0, 0);
            PointF center2 = new PointF((qrImg.Width - headerBgImg.Width) / 2, (qrImg.Height - headerBgImg.Height) / 2);
            g2.DrawImage(headerBgImg, center2);
            g2.Dispose();

            //二维码底部写字
            var bottom = 50;
            Bitmap backgroudImg2 = new Bitmap(qrImg.Width, qrImg.Height + bottom);
            if (!string.IsNullOrEmpty(bottomCode))
            {
                backgroudImg2.MakeTransparent();
                backgroudImg2.SetResolution(dpix, dpiy);
                Graphics g3 = Graphics.FromImage(backgroudImg2);
                g3.Clear(Color.Transparent);
                g3.DrawImage(qrImg, 0, 0);

                Font myFont = new Font("宋体", 20, FontStyle.Bold);
                Brush fontbrush = new SolidBrush(Color.Black);
                SizeF sizeF = g3.MeasureString(bottomCode, myFont);
                var marginLeft = qrImg.Width - sizeF.Width <= 0 ? 0 : (qrImg.Width - sizeF.Width) / 2;
                var marginHeight = qrImg.Height + (bottom - sizeF.Height <= 0 ? 0 : (bottom - sizeF.Height) / 2);
                PointF center3 = new PointF(marginLeft, marginHeight);
                g3.DrawImage(headerBgImg, center2);
                g3.DrawString(bottomCode, myFont, fontbrush, center3);
                g3.Dispose();
            }
            return string.IsNullOrEmpty(bottomCode) ? backgroudImg : backgroudImg2;
        }
        #endregion

        #region 图形处理
        /// <summary>
        /// 创建圆角矩形
        /// </summary>
        /// <param name="rect">区域</param>
        /// <param name="cornerRadius">圆角角度</param>
        /// <returns></returns>
        private static GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int cornerRadius)
        {
            //下午重新整理下，圆角矩形
            GraphicsPath roundedRect = new GraphicsPath();
            roundedRect.AddArc(rect.X, rect.Y, cornerRadius * 2, cornerRadius * 2, 180, 90);
            roundedRect.AddLine(rect.X + cornerRadius, rect.Y, rect.Right - cornerRadius * 2, rect.Y);
            roundedRect.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y, cornerRadius * 2, cornerRadius * 2, 270, 90);
            roundedRect.AddLine(rect.Right, rect.Y + cornerRadius * 2, rect.Right, rect.Y + rect.Height - cornerRadius * 2);
            roundedRect.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y + rect.Height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
            roundedRect.AddLine(rect.Right - cornerRadius * 2, rect.Bottom, rect.X + cornerRadius * 2, rect.Bottom);
            roundedRect.AddArc(rect.X, rect.Bottom - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);
            roundedRect.AddLine(rect.X, rect.Bottom - cornerRadius * 2, rect.X, rect.Y + cornerRadius * 2);
            roundedRect.CloseFigure();
            return roundedRect;
        }
        /// <summary>
        /// 图片按比例缩放
        /// </summary>
        private static System.Drawing.Image ZoomPic(System.Drawing.Image initImage, double n)
        {
            //缩略图宽、高计算
            double newWidth = initImage.Width;
            double newHeight = initImage.Height;
            newWidth = n * initImage.Width;
            newHeight = n * initImage.Height;
            //生成新图
            //新建一个bmp图片
            System.Drawing.Image newImage = new System.Drawing.Bitmap((int)newWidth, (int)newHeight);
            //新建一个画板
            System.Drawing.Graphics newG = System.Drawing.Graphics.FromImage(newImage);
            //设置质量
            newG.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            newG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //置背景色
            newG.Clear(Color.Transparent);
            //画图
            newG.DrawImage(initImage, new System.Drawing.Rectangle(0, 0, newImage.Width, newImage.Height), new System.Drawing.Rectangle(0, 0, initImage.Width, initImage.Height), System.Drawing.GraphicsUnit.Pixel);
            newG.Dispose();
            return newImage;
        }
        #endregion
    }


}
