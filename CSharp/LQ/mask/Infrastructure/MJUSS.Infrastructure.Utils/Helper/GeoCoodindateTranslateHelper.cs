using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MJUSS.Infrastructure.Utils.Helper
{
    public class GeoCoodindateTranslateHelper
    {
        public async Task<GeoCoordinateData> TranslateBaiduToQQLocation(GeoCoordinateData loc)
        {
            var url = string.Format("http://apis.map.qq.com/ws/coord/v1/translate?locations={0},{1}&type=3&key={2}",
                loc.Latitude, loc.Longitude, "G6OBZ-4YVKF-AEZJ6-NSL43-47AS6-WIBXL");

            var result = await HttpGetTools.GetJsonAsync<RespondGetQQLocationDTO>(url);
            if (result.status == 0 && result.locations.Count == 1)
            {
                var qqLoc = result.locations.First();
                return new GeoCoordinateData(qqLoc.lat, qqLoc.lng);
            }
            return new GeoCoordinateData(0, 0);
        }

        public async Task<GeoCoordinateData> TranslateToBaiduLocation(GeoCoordinateData reqData)
        {

            if (reqData.Latitude == 0 || reqData.Longitude == 0)
            {
                return new GeoCoordinateData(30.592108, 104.063545);
            }
            else
            {
                GeoCoordinateData result = new GeoCoordinateData(0,0);
                var add = await HttpGetTools.GetJsonAsync<RespondTranslateToBaiduLocationDTO>(
                    string.Format("http://api.map.baidu.com/geoconv/v1/?coords={0},{1}&from=1&to=5&ak=IdynWbDBfDOHPFGHRYMuTeecFAHm1NEq&output=json",
                    reqData.Longitude,
                    reqData.Latitude));
                if(add == null | add.result == null)
                {
                    return new GeoCoordinateData(30.592108, 104.063545);
                }
                if (add.status == 0 && add.result.Count == 1)
                {
                    var newAdd = add.result.First();
                    result.Longitude = newAdd.x;
                    result.Latitude = newAdd.y;
                }
                return result;
            }


        }
    }

    public class GeoCoordinateData
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public GeoCoordinateData(double latitude, double longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }
    }

    [Serializable]
    public class RespondGetQQLocationDTO
    {
        public int status { get; set; }
        public string message { get; set; }

        public List<QqLocation> locations { get; set; }

    }

    [Serializable]
    public class QqLocation
    {
        public double lng { get; set; }
        public double lat { get; set; }
    }

    [Serializable]
    public class RespondTranslateToBaiduLocationDTO
    {
        public int status { get; set; }


        public List<RespondTranslateToBaiduLocationItemDTO> result { get; set; }

        //{"status":0,"result":[{"x":114.23075141604,"y":29.579082111635}]}
    }

    public class RespondTranslateToBaiduLocationItemDTO
    {
        public double x { get; set; }

        public double y { get; set; }
    }
}
