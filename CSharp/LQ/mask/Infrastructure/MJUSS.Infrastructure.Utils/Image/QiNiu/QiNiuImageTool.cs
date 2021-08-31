using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MJUSS.Infrastructure.Utils.Image.QiLiu
{
    /// <summary>
    /// 七牛云图片url生成
    /// </summary>
    public class QiNiuImageTool
    {
        /// <summary>
        /// 图片宽度
        /// </summary>
        public int ImageWidth { get; set; }
        /// <summary>
        /// 图片高度
        /// </summary>
        public int ImageHeight { get; set; }

        /// <summary>
        /// 裁剪模式
        /// </summary>
        public QiLiuImageCropModeEnum CropMode { get; set; }

        /// <summary>
        /// 是否支持渐进显示
        /// </summary>
        public bool IsInterlace { get; set; }

        public QiNiuImageTool(int imageWidth, int imageHeight, QiLiuImageCropModeEnum cropMode = QiLiuImageCropModeEnum.模式1, bool isInterlace = false)
        {
            ImageWidth = imageWidth;
            ImageHeight = imageHeight;
            CropMode = cropMode;
            IsInterlace = isInterlace;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("imageView2");
            stringBuilder.Append($"/{(int)CropMode}");
            
            if(ImageWidth > 0)
            {
                stringBuilder.Append($"/w/{ImageWidth}");
            }
            if(ImageHeight > 0)
            {
                stringBuilder.Append($"/h/{ImageHeight}");
            }
            if(IsInterlace)
            {
                stringBuilder.Append($"/interlace/1");
            }
            return stringBuilder.ToString();
        }

    }

    public enum QiLiuImageCropModeEnum
    {
        /// <summary>
        /// 限定缩略图的长边最多为<LongEdge>，短边最多为<ShortEdge>，进行等比缩放，不裁剪 
        /// </summary>
        /// <remarks>
        /// 限定缩略图的长边最多为<LongEdge>，短边最多为<ShortEdge>，进行等比缩放，不裁剪。如果只指定 w 参数则表示限定长边（短边自适应），只指定 h 参数则表示限定短边（长边自适应）。
        /// </remarks>
        模式0 = 0,
        /// <summary>
        /// 限定缩略图的宽最少为<Width>，高最少为<Height>，进行等比缩放，居中裁剪
        /// </summary>
        /// <remarks>
        /// 限定缩略图的宽最少为<Width>，高最少为<Height>，进行等比缩放，居中裁剪。转后的缩略图通常恰好是 <Width>x<Height> 的大小（有一个边缩放的时候会因为超出矩形框而被裁剪掉多余部分）。如果只指定 w 参数或只指定 h 参数，代表限定为长宽相等的正方图。
        /// </remarks>
        模式1 = 1,
        /// <summary>
        /// 限定缩略图的宽最多为<Width>，高最多为<Height>，进行等比缩放，不裁剪
        /// </summary>
        /// <remarks>
        /// 限定缩略图的宽最多为<Width>，高最多为<Height>，进行等比缩放，不裁剪。如果只指定 w 参数则表示限定宽（长自适应），只指定 h 参数则表示限定长（宽自适应）。它和模式0类似，区别只是限定宽和高，不是限定长边和短边。从应用场景来说，模式0适合移动设备上做缩略图，模式2适合PC上做缩略图。
        /// </remarks>
        模式2 = 2,
        /// <summary>
        /// 限定缩略图的宽最少为<Width>，高最少为<Height>，进行等比缩放，不裁剪
        /// </summary>
        /// <remarks>
        /// 限定缩略图的宽最少为<Width>，高最少为<Height>，进行等比缩放，不裁剪。如果只指定 w 参数或只指定 h 参数，代表长宽限定为同样的值。你可以理解为模式1是模式3的结果再做居中裁剪得到的。
        /// </remarks>
        模式3 = 3,
        /// <summary>
        /// 限定缩略图的长边最少为<LongEdge>，短边最少为<ShortEdge>，进行等比缩放，不裁剪
        /// </summary>
        /// <remarks>
        /// 限定缩略图的长边最少为<LongEdge>，短边最少为<ShortEdge>，进行等比缩放，不裁剪。如果只指定 w 参数或只指定 h 参数，表示长边短边限定为同样的值。这个模式很适合在手持设备做图片的全屏查看（把这里的长边短边分别设为手机屏幕的分辨率即可），生成的图片尺寸刚好充满整个屏幕（某一个边可能会超出屏幕）。
        /// </remarks>
        模式4 = 4,
        /// <summary>
        /// 限定缩略图的长边最少为<LongEdge>，短边最少为<ShortEdge>，进行等比缩放，居中裁剪
        /// </summary>
        /// <remarks>
        /// 限定缩略图的长边最少为<LongEdge>，短边最少为<ShortEdge>，进行等比缩放，居中裁剪。如果只指定 w 参数或只指定 h 参数，表示长边短边限定为同样的值。同上模式4，但超出限定的矩形部分会被裁剪。
        /// </remarks>
        模式5 = 5,

    }

    
}
