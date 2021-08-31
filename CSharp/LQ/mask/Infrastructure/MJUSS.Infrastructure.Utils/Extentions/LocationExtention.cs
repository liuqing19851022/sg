using MJUSS.Infrastructure.Core.BaseInterface;
using System;

namespace MJUSS.Infrastructure.Utils.Extentions
{
    public static class LocationExtention
    {
        /// <summary>
        /// 获取两个位置的距离（米）
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static int GetDistance(this ILocation p1, ILocation p2)
        {

            var pk = 180 / Math.PI;
            var a1 = p1.Latitude / pk;
            var a2 = p1.Longitude / pk;
            var b1 = p2.Latitude / pk;
            var b2 = p2.Longitude / pk;

            var t1 = Math.Cos(a1) * Math.Cos(a2) * Math.Cos(b1) * Math.Cos(b2);
            var t2 = Math.Cos(a1) * Math.Sin(a2) * Math.Cos(b1) * Math.Sin(b2);
            var t3 = Math.Sin(a1) * Math.Sin(b1);

            return (int)(6366000 * Math.Acos(t1 + t2 + t3));
        }

        /// <summary>
        /// 获取两个位置的距离（米/千米）
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static string GetDistanceStr(this ILocation p1, ILocation p2)
        {

            var result = GetDistance(p1, p2);

            if (result < 1000) return string.Concat(result, "m");

            return string.Concat(Math.Round(result / 1000.0, 1).ToString("N1"), "km");

        }



        #region 新的计算两个经纬度坐标的距离
        /// <summary>
        /// 地球半径
        /// </summary>
        private const double EarthRadius = 6378.137;


        /// <summary>
        /// 经纬度转化成弧度
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        private static double Rad(double d)
        {
            return d * Math.PI / 180d;
        }


        /// <summary>
        /// 计算两个坐标点之间的距离
        /// </summary>
        /// <param name="firstLatitude">第一个坐标的纬度</param>
        /// <param name="firstLongitude">第一个坐标的经度</param>
        /// <param name="secondLatitude">第二个坐标的纬度</param>
        /// <param name="secondLongitude">第二个坐标的经度</param>
        /// <returns>返回两点之间的距离，单位：米</returns>
        public static double GetDistance(double firstLatitude, double firstLongitude, double secondLatitude, double secondLongitude)
        {
            var firstRadLat = Rad(firstLatitude);
            var firstRadLng = Rad(firstLongitude);
            var secondRadLat = Rad(secondLatitude);
            var secondRadLng = Rad(secondLongitude);

            var a = firstRadLat - secondRadLat;
            var b = firstRadLng - secondRadLng;
            var cal = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) + Math.Cos(firstRadLat)
              * Math.Cos(secondRadLat) * Math.Pow(Math.Sin(b / 2), 2))) * EarthRadius;
            var result = Math.Round(cal * 10000) / 10;
            return result;
        }


        /// <summary>
        /// 计算两个坐标点之间的距离
        /// </summary>
        /// <param name="firstPoint">第一个坐标点的（纬度,经度）</param>
        /// <param name="secondPoint">第二个坐标点的（纬度,经度）</param>
        /// <returns>返回两点之间的距离，单位：米</returns>
        public static double GetPointDistance(string firstPoint, string secondPoint)
        {
            var firstArray = firstPoint.Split(',');
            var secondArray = secondPoint.Split(',');
            var firstLatitude = Convert.ToDouble(firstArray[0].Trim());
            var firstLongitude = Convert.ToDouble(firstArray[1].Trim());
            var secondLatitude = Convert.ToDouble(secondArray[0].Trim());
            var secondLongitude = Convert.ToDouble(secondArray[1].Trim());
            return GetDistance(firstLatitude, firstLongitude, secondLatitude, secondLongitude);
        }

        public static int GetNewDistance(this ILocation p1, ILocation p2)
        {
            var result = GetDistance(p1.Latitude, p1.Longitude, p2.Latitude, p2.Longitude);
            return Math.Round(result, 1).ToString().ToInt();
        }
        /// <summary>
        /// 两个坐标的距离（返回带单位的文字）
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static string GetNewDistanceStr(this ILocation p1, ILocation p2)
        {
            var result = GetDistance(p1.Latitude, p1.Longitude, p2.Latitude, p2.Longitude);
            if (result < 1000) return string.Concat(Math.Round(result, 1), "米");
            return string.Concat(Math.Round(result / 1000.0, 1).ToString("N1"), "公里");
        } 
        #endregion

    }
}
