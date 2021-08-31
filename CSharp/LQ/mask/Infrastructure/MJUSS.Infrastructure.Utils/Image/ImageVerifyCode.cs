using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MJUSS.Infrastructure.Utils.Image
{
    public class ImageVerifyCode
    {
        private Random random;

        public ImageVerifyCode()
        {
            this.random = new Random(DateTime.Now.Millisecond);
        }


        public Bitmap CreateVerifyCodeImage(string code)
        {
            return TwistImage(GetImageVerifyCode(code), true, 5, 1.2);
        }

        private Bitmap GetImageVerifyCode(string code)
        {
            Bitmap bitmap = new Bitmap(80, 40);
            Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);
            for (int i = 0; i < code.Length; i++)
            {
                Font font = new Font("宋体", random.Next(25, 27), FontStyle.Bold);
                var codeItem = code[i];
                var charSize = g.MeasureString(codeItem.ToString(), font);
                float left = i * (font.Size - 10) + 5;
                float top = bitmap.Height / 2f - charSize.Height / 2f + this.random.Next(-5, 5);
                g.DrawString(codeItem.ToString(), font, new SolidBrush(Color.Black), left, top);
            }
            return bitmap;

        }

        private System.Drawing.Bitmap TwistImage(Bitmap srcBmp, bool bXDir, double dMultValue, double dPhase)
        {
            var PI2 = 6.28318530717958647692528676655;
            System.Drawing.Bitmap destBmp = new Bitmap(srcBmp.Width, srcBmp.Height);
            System.Drawing.Graphics graph = System.Drawing.Graphics.FromImage(destBmp);
            graph.FillRectangle(new SolidBrush(System.Drawing.Color.White), 0, 0, destBmp.Width, destBmp.Height);
            graph.Dispose();

            double dBaseAxisLen = bXDir ? (double)destBmp.Height : (double)destBmp.Width;

            for (int i = 0; i < destBmp.Width; i++)
            {
                for (int j = 0; j < destBmp.Height; j++)
                {
                    double dx = 0;
                    dx = bXDir ? (PI2 * (double)j) / dBaseAxisLen : (PI2 * (double)i) / dBaseAxisLen;
                    dx += dPhase;
                    double dy = Math.Sin(dx);

                    // 取得当前点的颜色
                    int nOldX = 0, nOldY = 0;
                    nOldX = bXDir ? i + (int)(dy * dMultValue) : i;
                    nOldY = bXDir ? j : j + (int)(dy * dMultValue);

                    System.Drawing.Color color = srcBmp.GetPixel(i, j);
                    if (nOldX >= 0 && nOldX < destBmp.Width
                     && nOldY >= 0 && nOldY < destBmp.Height)
                    {
                        destBmp.SetPixel(nOldX, nOldY, color);
                    }
                }
            }

            return destBmp;
        }
    }
}
