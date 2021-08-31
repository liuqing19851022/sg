//using Microsoft.Extensions.Caching.Memory;
//using Orleans;
//using System;
//using System.Threading.Tasks;

//namespace MJUSS.Infrastructure.Utils.Caches.OrleansCache
//{
//    public class OreansCacheGrain : Grain, IOreansCacheGrain
//    {
//        private string key;
//        private string value;
//        private DateTime setDateTime { get; set; }
//        private TimeSpan sliderExpirationTime;

//        public override Task OnActivateAsync()
//        {
//            this.key = this.GetPrimaryKeyString();
//            return base.OnActivateAsync();
//        }

//        public Task<string> GetCache()
//        {
//            string result = null;
//            if(setDateTime.Add(sliderExpirationTime) > DateTime.Now)
//            {
//                result = value;
//            }
//            return Task.FromResult(result);
//        }

//        public Task SetCache(string value, TimeSpan sliderExpirationTime)
//        {
//            this.value = value;
//            this.sliderExpirationTime = sliderExpirationTime;
//            setDateTime = DateTime.Now;
//            return Task.CompletedTask;
//        }
//    }
    
//}
