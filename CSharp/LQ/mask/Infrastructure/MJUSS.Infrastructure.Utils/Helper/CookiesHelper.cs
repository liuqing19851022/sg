//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Web;

//namespace MJUSS.Infrastructure.Utils.Helper
//{
//    public class CookiesHelper
//    {
//        private static string domain;
//        public static string Domain {
//            get {
//                if (domain != null) return domain;
//                domain = ConfigurationManager.AppSettings["Domain"];
//                return domain;
//            }
//            set {
//                domain = value;
//            }
//        }
//        private static string SessionKey = "MJSessionID";


//        static CookiesHelper(){
//            var sessionkey = ConfigurationManager.AppSettings["SessionKey"];
//            if (!string.IsNullOrEmpty(sessionkey))
//            {
//                SessionKey = sessionkey;
//            }
//        }

//        public static void AddCookies(string key,string val,DateTime ?expires = null) {
//            var cookie = new HttpCookie(key)
//            {
//                Value = val,
//                HttpOnly = true,
//                Domain = Domain,
//                Path = "/"
//            };

//            if (expires.HasValue)
//                cookie.Expires = expires.Value;
//            HttpContext.Current.Response.SetCookie(cookie);

//        }

//        public static string GetSessionid()
//        {
//            //var cookies = HttpContext.Current.Request.Cookies;
//            //for (var i = cookies.Count - 1; i>= 0; i--) {
//            //    if (cookies[i].Name.Equals(SessionKey)) return cookies[i].Value;
//            //}
//            //var cookie = HttpContext.Current.Request.Cookies[SessionKey];
//            //if (cookie != null)
//            //{
//            //    return cookie.Value;
//            //}
//            //else
//            //{
//            //    var newCookies = Guid.NewGuid().ToString("N");
//            //    AddCookies(SessionKey, newCookies);
//            //    return newCookies;
//            //}
//            return GetSessionid(out bool isGenSessionID);
//        }

//        public static string GetSessionid(out bool IsGenSessionID)
//        {
//            IsGenSessionID = false;
//            var cookies = HttpContext.Current.Request.Cookies;
//            for (var i = cookies.Count - 1; i >= 0; i--)
//            {
//                if (cookies[i].Name.Equals(SessionKey)) return cookies[i].Value;
//            }
//            var cookie = HttpContext.Current.Request.Cookies[SessionKey];
//            if (cookie != null)
//            {
//                return cookie.Value;
//            }
//            else
//            {
//                var newCookies = Guid.NewGuid().ToString("N");
//                AddCookies(SessionKey, newCookies);
//                IsGenSessionID = true;
//                return newCookies;
//            }
//        }

//        public static void SetSessionId(string sessionId, DateTime? expires = null) {
//            AddCookies(SessionKey, sessionId, expires);
//        }
//    }
//}
