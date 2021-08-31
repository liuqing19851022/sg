using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MJUSS.Infrastructure.Utils.Helper
{
    public class LocationHelper
    {
        public static int GetDistance(GeoCoordinateData p1, GeoCoordinateData p2)
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

        public static string GetDistanceStr(GeoCoordinateData p1, GeoCoordinateData p2)
        {

            var result = GetDistance(p1, p2);

            if (result < 1000) return string.Concat(result, "m");

            return string.Concat(Math.Round(result / 1000.0, 1).ToString("N1"), "km");


        }
    }
}
