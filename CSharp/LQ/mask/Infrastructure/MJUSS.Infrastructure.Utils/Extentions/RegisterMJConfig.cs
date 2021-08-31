using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MJUSS.Infrastructure.Utils.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MJUSS.Infrastructure.Utils.Extentions
{
    public static class RegisterMJConfig
    {
        public static void MjConfigure<T>(this IServiceCollection serviceCollection) where T : class
        {
            var configuration = ConfigHandler.BuildConfig<T>();
            serviceCollection.Configure<T>(configuration);
        }

        public static void MjJsonConfigure<T>(this IServiceCollection service) where T : class {
            var configuration = ConfigHandler.BuildJsonConfig<T>();
            service.Configure<T>(configuration);
        }
    }
}
