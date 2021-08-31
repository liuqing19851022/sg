namespace MJUSS.Infrastructure.Utils.Extentions
{
    using System;
    using System.Globalization;

    public static class DecimalExtention
    {
        /// <summary>
        /// 转化成自定义格式的字符串
        /// </summary>
        /// <param name="decValue"></param>
        /// <param name="numberFormat">数字格式</param>
        /// <param name="customerFormat">输出文本格式，必须带{0},{1}.{0}代表整数部分;{1}代表小数部分</param>
        /// <returns></returns>
        public static string ToCustomerString(this decimal decValue,string numberFormat = "N2",string customerFormat="<span class=\"red f30\">{0}<i class=\"f18 n\">{1}</i></span>")
        {
            var strNum = decValue.ToString(numberFormat);
            var dotIndex = strNum.IndexOf('.');

            if (dotIndex <= -1) return string.Format(customerFormat, strNum, "");

            var intPart = strNum.Substring(0, dotIndex);
            var decPart = strNum.Substring(dotIndex);
            return string.Format(customerFormat, intPart, decPart);
        }

        /// <summary>
        /// 四舍五入
        /// </summary>
        /// <param name="decValue"></param>
        /// <returns></returns>
        public static decimal ToRounding(this decimal decValue, int precision=1)
        {
            return Math.Round(decValue, precision, MidpointRounding.AwayFromZero);
        }


        /// <summary>
        /// 保留两位小数
        /// </summary>
        /// <param name="decValue"></param>
        /// <returns></returns>
        public static string ToStandardString(this decimal decValue)
        {
            return decValue.ToString("#0.00");
        }

        /// <summary>
        /// 保留1位小数
        /// </summary>
        /// <param name="decValue"></param>
        /// <returns></returns>
        public static string ToMoneyString(this decimal decValue)
        {
            return decValue.ToString("f1");
        }

        /// <summary>
        /// 保留2位小数（百分比小数）
        /// </summary>
        /// <param name="decValue"></param>
        /// <returns></returns>
        public static string ToRateString(this decimal decValue)
        {
            return decValue.ToString("f2");
        }

        /// <summary>
        /// 保留4位小数
        /// </summary>
        /// <param name="decValue"></param>
        /// <returns></returns>
        public static string ToMoneyString4(this decimal decValue)
        {
            var resultArray = decValue.ToString().Split('.');
            if(resultArray.Length > 1 && resultArray[1].Length <= 1)
            {
                return decValue.ToString("f1");
            }
            return decValue.ToAutoRemoveZeroString();
        }

        /// <summary>
        /// 自动舍去后面的0，支持小数点后4位
        /// </summary>
        /// <param name="decValue"></param>
        /// <returns></returns>
        public static string ToAutoRemoveZeroString(this decimal decValue)
        {
            return decValue.ToString("0.####");
        }

        /// <summary>
        /// 分钟转小时分钟显示
        /// </summary>
        /// <param name="minutes"></param>
        /// <returns></returns>
        public static string ToHourMinutes(this int minutes)
        {
            var hours = minutes / 60;
            var mins = minutes % 60;
            if (mins > 0)
            {
                return $"{hours}小时{mins}分钟";
            }
            else
            {
                return $"{hours}小时";
            }
        }

        /// <summary>
        /// 折扣
        /// </summary>
        /// <param name="decValue"></param>
        /// <returns></returns>
        public static string ToDiscountString(this decimal decValue)
        {
            var returnVal = "无折扣";
            if (decValue < 1 && decValue > 0)
            {
                returnVal = (decValue * 10).ToString("0.#") + "折";
            }
            if (decValue == 0)
            {
                returnVal = "免费";
            }
            return returnVal;
        }

        /// <summary>
        /// 转为百分比n%
        /// </summary>
        /// <param name="decValue"></param>
        /// <returns></returns>
        public static string ToPercentString(this decimal decValue)
        {
            return decValue.ToString("P2");
        }
    }
}
