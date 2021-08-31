using System;
using System.Drawing;
using System.IO;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using ZXing.Windows.Compatibility;

namespace MJUSS.Infrastructure.Utils.QrCodeTool
{
    public class BarcodeHelper
    {
        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="text">内容</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <returns></returns>
        public static Bitmap GenerateQrCode(string text, int width, int height)
        {
            BarcodeWriter<Bitmap> writer = new BarcodeWriter<Bitmap>
            {
                Format = BarcodeFormat.QR_CODE
            };
            writer.Renderer = new BitmapRenderer();
            QrCodeEncodingOptions options = new QrCodeEncodingOptions()
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = width,
                Height = height,
                Margin = 1
            };
            writer.Options = options;
            Bitmap map = writer.Write(text);
            return map;
        }

        /// <summary>
        /// 获取图片的Base64
        /// </summary>
        /// <param name="bmp"></param>
        /// <returns></returns>
        public static string GetBitMapBase64(Bitmap bmp)
        {
            using var ms = new MemoryStream();
            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return Convert.ToBase64String(ms.ToArray());
        }

        /// <summary>
        /// 生成一维条形码
        /// </summary>
        /// <param name="text">内容</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <returns></returns>
        public static Bitmap GenerateBarCode(string text, int width, int height)
        {
            BarcodeWriter<Bitmap> writer = new BarcodeWriter<Bitmap>
            {
                Format = BarcodeFormat.CODE_39
            };
            writer.Renderer = new BitmapRenderer();
            EncodingOptions options = new EncodingOptions()
            {
                Width = width,
                Height = height,
                Margin = 2
            };
            writer.Options = options;
            Bitmap map = writer.Write(text);
            return map;
        }
    }
}
