using MJUSS.Infrastructure.Core.BaseClass;
using MJUSS.Infrastructure.Core.Error;
using MJUSS.Infrastructure.Core.Exceptions;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace MJUSS.Infrastructure.Utils.Extentions
{
    public static class StringExtention
    {
        /// <summary>
        /// 将字符串转为整形
        /// </summary>
        /// <param name="strSource"></param>
        /// <param name="defVal"></param>
        /// <returns></returns>
        public static int ToInt(this string strSource, int defVal = 0)
        {
            if (string.IsNullOrEmpty(strSource)) return defVal;
            var intParseSuccess = int.TryParse(strSource, out int outInt);
            if (intParseSuccess)
            {
                return outInt;
            }
            else
            {
                var parseSucess = decimal.TryParse(strSource, out decimal outDecimal);
                if (parseSucess)
                {
                    return (int)outDecimal;
                }
            }
            return defVal;
        }

        public static float ToFloat(this string strSource, int defVal = 0)
        {
            if (string.IsNullOrEmpty(strSource)) return defVal;
            return float.TryParse(strSource, out float intQuery) ? intQuery : defVal;
        }

        /// <summary>
        /// 手机保密处理
        /// </summary>
        /// <param name="cellPhone"></param>
        /// <returns></returns>
        public static string MobileProtection(this string cellPhone)
        {
            return cellPhone.Length != 11 ? cellPhone : $"{cellPhone.Substring(0, 3)}****{cellPhone.Substring(7, 4)}";
        }

        /// <summary>
        /// 截断固定长度的字符
        /// </summary>
        /// <param name="srcString"></param>
        /// <param name="fixedLength"></param>
        /// <returns></returns>
        public static string StrFixLength(this string srcString, int fixedLength)
        {
            if (srcString == null)
            {
                return string.Empty;
            }
            else if (srcString.Length <= fixedLength)
            {
                return srcString;
            }
            else
            {
                return $"{srcString.Substring(0, fixedLength)}...";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strSource">服务器端版本号</param>
        /// <param name="IOSClientVersion">ios版本号</param>
        /// <returns></returns>
        public static bool CheckIOSClientVersionIsNew(this string strSource, string IOSClientVersion)
        {
            if (string.IsNullOrEmpty(strSource))
            {
                return true;
            }
            if (string.IsNullOrEmpty(IOSClientVersion))
            {
                return true;
            }
            var serviceVersion = strSource.Replace(".", "");
            var newIOSClientVersion = IOSClientVersion.Replace(".", "");
            if (newIOSClientVersion.ToDecimal() < 254)//2.5.4版本后ios才有强制更新的功能
            {
                return true;
            }
            return serviceVersion.ToDecimal() == newIOSClientVersion.ToDecimal();
        }

        /// <summary>
        /// 检查null字符串
        /// </summary>
        /// <param name="strSource"></param>
        /// <returns></returns>
        public static string CheckNullStr(this string strSource)
        {
            if (string.IsNullOrEmpty(strSource)) return "";
            return strSource;
        }

        public static decimal ToDecimal(this string strSource, decimal defVal = 0)
        {
            if (string.IsNullOrEmpty(strSource)) return defVal;
            return decimal.TryParse(strSource, out decimal decQuery) ? decQuery : defVal;
        }

        public static double ToDouble(this string strSource, double defVal = 0)
        {
            if (string.IsNullOrEmpty(strSource)) return defVal;
            return double.TryParse(strSource, out double decQuery) ? decQuery : defVal;
        }

        public static Guid ToGuid(this string strSource, Guid defVal = new Guid())
        {
            if (string.IsNullOrEmpty(strSource)) return defVal;
            return Guid.TryParse(strSource, out Guid guidQuery) ? guidQuery : defVal;
        }

        public static long ToLong(this string strSource, long defVal = 0)
        {
            if (string.IsNullOrEmpty(strSource)) return defVal;
            return long.TryParse(strSource, out long longQuery) ? longQuery : defVal;
        }

        public static byte ToByte(this string strSource, byte defVal = 0)
        {
            if (string.IsNullOrEmpty(strSource)) return defVal;
            return byte.TryParse(strSource, out byte result) ? result : defVal;
        }

        /// <summary>
        /// 去掉图片地址后面的参数
        /// </summary>
        /// <param name="strSource"></param>
        /// <returns></returns>
        public static string GetImageOriginalUrl(this string strSource)
        {
            var regex = new Regex("\\?.+");
            return regex.Replace(strSource, "");
        }

        /// <summary>
        /// 是否是手机号
        /// </summary>
        /// <param name="strSource"></param>
        /// <param name="defVal"></param>
        /// <returns></returns>
        public static bool IsMobile(this string strSource, bool defVal = false)
        {
            if (string.IsNullOrEmpty(strSource)) return defVal;
            return Regex.IsMatch(strSource, @"^1\d{10}$");
        }

        /// <summary>
        /// 跳转到https
        /// </summary>
        /// <param name="strSource"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string ToHttps(this string strSource)
        {
            const string httpPre = "http:";
            if (string.IsNullOrEmpty(strSource))
            {
                return string.Empty;
            }
            if (strSource.StartsWith(httpPre))
            {
                strSource = strSource.Substring(httpPre.Length);
            }
            return strSource;
        }

        /// <summary>
        /// 将字符串转为日期格式
        /// </summary>
        /// <param name="strSource"></param>
        /// <param name="defVal"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string strSource, DateTime defVal = new DateTime())
        {
            if (string.IsNullOrEmpty(strSource)) return defVal;
            return DateTime.TryParse(strSource, out DateTime dtQuery) ? dtQuery : defVal;
        }

        public static TimeSpan ToTimeSpan(this string strSource, TimeSpan defVal = new TimeSpan())
        {
            if (string.IsNullOrEmpty(strSource)) return defVal;
            return TimeSpan.TryParse(strSource, out TimeSpan dtQuery) ? dtQuery : defVal;
        }

        /// <summary>
        /// 将只有年份的字符串转为日期格式，如：2018,转换成2018-01-01的日期
        /// </summary>
        /// <param name="strSource"></param>
        /// <param name="defVal"></param>
        /// <returns></returns>
        public static DateTime ToYearDate(this string strSource, DateTime defVal = new DateTime())
        {
            if (string.IsNullOrEmpty(strSource)) return defVal;
            if (strSource.Length < 4)
            {
                throw new Exception("年份必须是4位");
            }
            if (strSource.Length == 4)
            {
                strSource += "-01-01";
            }
            return DateTime.TryParse(strSource, out DateTime dtQuery) ? dtQuery : defVal;
        }


        /// <summary>
        /// 过滤HTML标签
        /// </summary>
        /// <param name="strSource"></param>
        /// <returns></returns>
        public static string FilterHtml(this string strSource)
        {
            return string.IsNullOrEmpty(strSource) ? string.Empty : strSource.Replace("<", "").Replace(">", "");
        }


        /// <summary>
        /// 过滤HTML标签
        /// </summary>
        /// <param name="strSource"></param>
        /// <param name="replaceValue"></param>
        /// <returns></returns>
        public static string FilterHtml(this string strSource, string replaceValue)
        {
            var reg = new Regex(@"<(\w+)(.+)?>");
            return string.IsNullOrEmpty(strSource) ? string.Empty : reg.Replace(strSource, replaceValue);
        }


        public static string UrlEncodeUnicode(this string strSource)
        {
            var urlEncode = HttpUtility.UrlEncode(HttpUtility.UrlEncode(strSource));
            if (urlEncode != null)
            {
                return string.IsNullOrWhiteSpace(strSource)
                           ? ""
                           : urlEncode.Replace("+", "%20");
            }
            return string.Empty;
        }

        public static string encodeURIComponent(this string strSource)
        {
            return HttpUtility.UrlEncode(strSource, Encoding.UTF8);
        }

        public static string UrlEncodeUnicodeAddSpace(this string strSource)
        {
            var urlEncode = HttpUtility.UrlEncode(HttpUtility.UrlEncode(strSource));
            if (urlEncode != null)
            {
                return string.IsNullOrWhiteSpace(strSource)
                           ? ""
                           : urlEncode.Replace("%2b%", "%2520%");
            }
            return string.Empty;
        }

        /// <summary>
        /// 转为拼音
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToPinYinString(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }
            return StringToPinYinExtention.GetFirst(str).ToUpper();
            //var result = new StringBuilder();
            //foreach (var t in str)
            //{
            //    result.Append(GetIsChineseChar(t) ? ChineseToPinyinFirstSpell(t.ToString()) : t.ToString());
            //}
            //return result.ToString().ToUpper();
        }

        /// <summary>
        /// 获取第一个汉字的首字母（大写）；
        /// </summary>
        /// <param name="charChinese"></param>
        /// <returns></returns>
        private static string ChineseToPinyinFirstSpell(string charChinese)
        {
            var arrCN = Encoding.Default.GetBytes(charChinese);
            if (arrCN.Length <= 1)
            {
                return charChinese;
            }
            int area = arrCN[0];
            int pos = arrCN[1];
            var code = (area << 8) + pos;
            int[] areacode = { 45217, 45253, 45761, 46318, 46826, 47010, 47297, 47614, 48119, 48119, 49062, 49324, 49896, 50371, 50614, 50622, 50906, 51387, 51446, 52218, 52698, 52698, 52698, 52980, 53689, 54481 };
            for (var i = 0; i < 26; i++)
            {
                var max = 55290;
                if (i != 25) max = areacode[i + 1];
                if (areacode[i] > code || code >= max)
                {
                    continue;
                }
                var bytes = new[] { (byte)(65 + i) };
                return Encoding.Default.GetString(bytes, 0, bytes.Length);
            }
            return "*";
        }

        private static bool GetIsChineseChar(char charData)
        {
            if (charData >= 0x4E00 && charData <= 0x9FBB)
            {
                return true;
            }
            return false;
        }

        public static string ProtectRealName(this string realName)
        {
            if (realName == null || realName.Length < 2) return "*";
            return string.Concat("*", realName.Substring(1));
        }

        public static string ProtectIdCard(this string idCard)
        {
            if (idCard == null || idCard.Length < 10) return "*";
            return string.Concat(idCard.Substring(0, 1), "****************", idCard.Substring(idCard.Length - 1));
        }
        /// <summary>
        /// 银行卡
        /// </summary>
        /// <param name="bankCardNumber"></param>
        /// <returns></returns>
        public static string ProtectSettleBankCard(this string bankCardNumber)
        {
            if (bankCardNumber == null || bankCardNumber.Length < 4) return bankCardNumber;
            return bankCardNumber.Substring(bankCardNumber.Length - 4, 4);
        }

        public static string LocalUrl(this string url)
        {
            if (string.IsNullOrEmpty(url)) return string.Empty;
            if (!url.StartsWith("http", true, CultureInfo.CurrentCulture) || url.Length < 11) return url;
            var idx = url.IndexOf('/', 11);
            if (idx < 1) return url;
            return url.Substring(idx);
        }



        /// <summary>
        /// 校验字符串中是否包含除中英文数字的特殊字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool CheckSpecilChar(this string str)
        {
            Regex reg = new Regex("[a-zA-Z0-9\u4e00-\u9fa5]+$");
            return reg.Match(str).Groups[0].ToString().Length != str.Length;
        }

        /// <summary>
        /// 首字符大写
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string UpperFirst(this string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            if (s.Length > 1)
            {
                return char.ToUpper(s[0]) + s.Substring(1);
            }
            return char.ToUpper(s[0]).ToString();
        }
        /// <summary>
        /// 首字符小写
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string LowerFirst(this string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            if (s.Length > 1)
            {
                return char.ToLower(s[0]) + s.Substring(1);
            }
            return char.ToLower(s[0]).ToString();
        }

        /// <summary>
        /// ES模糊查询的字符串
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string WildcardQueryForEs(this string s)
        {
            var maxLen = 12;
            if (s.Length > maxLen)
            {
                throw new Exception($"模糊查询的字符长度不能超过{maxLen}");
            }
            return $"*{s}*";
        }
        ///// <summary>
        ///// 验证ES模糊查询的字符串长度
        ///// </summary>
        ///// <param name="s"></param>
        ///// <returns></returns>
        //public static string WildcardQueryForEsCheck(this string s)
        //{
        //    var maxLen = 30;
        //    if (s.Length > maxLen)
        //    {
        //        throw new Exception($"模糊查询的字符长度不能超过{maxLen}");
        //    }
        //    return s;
        //}
        /// <summary>
        /// 计算短信条数
        /// </summary>
        /// <param name="smsContent">短信完整内容</param>
        /// <param name="signName">签名(如：店铺名)</param>
        /// <param name="perSmsWordsCount">每条短信的最大字数</param>
        /// <returns></returns>
        public static int CalcSmsCount(this string smsContent, string signName, int perSmsWordsCount = 70)
        {
            var result = 1;
            var lastSmsContent = string.Format("【{0}】{1}", signName, smsContent);
            if (lastSmsContent.Length % perSmsWordsCount > 0)
            {
                result = (lastSmsContent.Length / perSmsWordsCount) + 1;
            }
            else
            {
                result = lastSmsContent.Length / perSmsWordsCount;
            }
            return result;
        }
        /// <summary>
        /// 短信附加签名
        /// </summary>
        /// <param name="smsContent">短信内容</param>
        /// <param name="signName">签名</param>
        /// <returns></returns>
        public static string SmsAttachSign(this string smsContent, string signName)
        {
            return string.Format("【{0}】{1}", signName, smsContent);
        }
        /// <summary>
        /// 计算短信条数
        /// </summary>
        /// <param name="smsContent">短信完整内容</param>
        /// <param name="perSmsWordsCount">每条短信的最大字数</param>
        /// <returns></returns>
        public static int CalcSmsCount(this string smsContent, int perSmsWordsCount = 70)
        {
            var result = 1;
            if (smsContent.Length % perSmsWordsCount > 0)
            {
                result = (smsContent.Length / perSmsWordsCount) + 1;
            }
            else
            {
                result = smsContent.Length / perSmsWordsCount;
            }
            return result;
        }

        /// <summary>
        /// 获取md5值
        /// </summary>
        /// <param name="srcStr"></param>
        /// <returns></returns>
        public static string GetMd5String(this string srcStr)
        {
            byte[] hashBuffer = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(srcStr));
            StringBuilder result = new StringBuilder();
            foreach (var item in hashBuffer)
            {
                result.Append(item.ToString("X2"));
            }
            return result.ToString();
        }

        ///// <summary>
        ///// 获取统计报表开始时间
        ///// </summary>
        ///// <param name="beginTimeStr"></param>
        ///// <param name="type">统计日期类型</param>
        ///// <returns></returns>
        //public static DateTime GetReportBeginTime(this string beginTimeStr, int type)
        //{
        //    var beginTime = DateTime.MinValue;
        //    if (type == (int)StatisticsTypeEnum.每日)
        //    {
        //        beginTime = beginTimeStr.ToDateTime();
        //        if (beginTime == DateTime.MinValue)
        //        {
        //            beginTime = DateTime.Now.AddDays(-6).Date;
        //        }
        //    }
        //    else if (type == (int)StatisticsTypeEnum.每月)
        //    {
        //        beginTime = beginTimeStr.ToDateTime().ToMonthFirstDate();
        //        if (beginTime == DateTime.MinValue)
        //        {
        //            beginTime = DateTime.Now.ToMonthFirstDate();
        //        }
        //    }
        //    else if (type == (int)StatisticsTypeEnum.每年)
        //    {
        //        beginTime = beginTimeStr.ToYearDate();
        //        if (beginTime == DateTime.MinValue)
        //        {
        //            beginTime = DateTime.Now.ToYearFirstDate();
        //        }
        //    }
        //    return beginTime;
        //}

        ///// <summary>
        ///// 获取统计报表结束时间
        ///// </summary>
        ///// <param name="endTimeStr"></param>
        ///// <param name="type">统计日期类型</param>
        ///// <returns></returns>
        //public static DateTime GetReportEndTime(this string endTimeStr, int type)
        //{
        //    var endTime = DateTime.MinValue;
        //    if (type == (int)StatisticsTypeEnum.每日)
        //    {
        //        endTime = endTimeStr.ToDateTime();
        //        if (endTime == DateTime.MinValue)
        //        {
        //            endTime = DateTime.Now.Date;
        //        }
        //    }
        //    else if (type == (int)StatisticsTypeEnum.每月)
        //    {
        //        endTime = endTimeStr.ToDateTime();
        //        if (endTime == DateTime.MinValue)
        //        {
        //            endTime = DateTime.Now.ToMonthLastDate();
        //        }
        //        endTime = endTime.ToMonthLastDate();
        //    }
        //    else if (type == (int)StatisticsTypeEnum.每年)
        //    {
        //        endTime = endTimeStr.ToYearDate();
        //        if (endTime == DateTime.MinValue)
        //        {
        //            endTime = DateTime.Now.ToYearLastDate();
        //        }
        //        endTime = endTime.ToYearLastDate();
        //    }
        //    return endTime;
        //}

        /// <summary>
        /// 检查字符串是否大于0，否则抛出异常
        /// </summary>
        /// <param name="longString"></param>
        public static void CheckGreaterThan0(this string longString)
        {
            if (longString.ToLong() <= 0)
            {
                throw new BaseValidationException(MJErrorCode.DataFormatError.ErrorCode, "数字必须大于0");
            }
        }
        /// <summary>
        /// 反序列化MessageApply的响应数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="respondDataString"></param>
        /// <returns></returns>
        public static T DeserializeFromMessageApply<T>(this string respondDataString) where T : RespondDataBase
        {
            var orgResult = JsonConvert.DeserializeObject<T>(respondDataString);
            orgResult.IsDuplicateExecute = true;
            return orgResult;
        }
        //public static string ToStandPrintHtml(this string html, int printType)
        //{

        //    if (printType == (int)PrintTypeEnum.浏览器打印)
        //    {
        //        //露肚皮 & 原生打印
        //        html = html.Replace(">@@2", " class=\"rem2\">");
        //    }
        //    else
        //    {
        //        //云打印机&本地打印

        //        html = html.Replace("\r", "").Replace("\n", "");
        //        html = html.Replace("\r\r", "\r");
        //        html = html.Replace("<p class=\"line\"></p>", "--------------------------------\r");
        //        html = html.Replace("<p>", "").Replace("</p>", "\r")
        //            .Replace("</center>", "</center>\r")
        //            .Replace("</table>", "</table>\r");
        //        //html = html.Replace("<table class=\"line\"", "<table");
        //        //html = html.Replace("<table", "\r<table");
        //        if (printType == (int)PrintTypeEnum.云打印)
        //        {

        //            //处理表格,云打印的表格不能有空格
        //            var regTable = new Regex(@"<table.*?>[\s\S]*?<\/table>", RegexOptions.IgnoreCase);
        //            var regTr = new Regex(@"\s+(<tr>)", RegexOptions.IgnoreCase);
        //            var matchs = regTable.Matches(html);

        //            if (matchs.Count == 0) return html;
        //            var start = 0;
        //            var len = matchs[0].Index;

        //            var sb = new StringBuilder();


        //            for (var i = 0; i < matchs.Count; i++)
        //            {

        //                len = matchs[i].Index - start;
        //                sb.Append(html.Substring(start, len));
        //                start = matchs[i].Index;
        //                len = matchs[i].Length;
        //                sb.Append(regTr.Replace(html.Substring(start, len), "$1").Replace("\r", ""));


        //                start = start + len;

        //            }

        //            sb.Append(html.Substring(start));
        //            html = sb.ToString();
        //        }
        //        //else
        //        //{
        //        //    html = html.Replace("<p class=\"line\">", "<table><tr><th></th></tr></table>");
        //        //}
        //    }
        //    return html;
        //}


    }
}
