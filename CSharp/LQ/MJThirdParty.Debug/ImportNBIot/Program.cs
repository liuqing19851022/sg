using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MJ.ThirdParty.NBIotCard.Recharge.Client.Extentions;
using MJSamrtDevice.NetWork.GrpcClient.Interfaces;
namespace ImportNBIot
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //Application.Run(new frmMain());

            //生成 DI 容器
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);  //注册各种服务类

            //先用DI容器生成 serviceProvider, 然后通过 serviceProvider 获取Main Form的注册实例
            var serviceProvider = services.BuildServiceProvider();

            var formMain = serviceProvider.GetRequiredService<frmMain>();   //主动从容器中获取FormMain实例, 这是简洁写法
                                                                             // var formMain = (FormMain)serviceProvider.GetService(typeof(FormMain));  //更繁琐的写法
            Application.Run(formMain);
        }

        private static void ConfigureServices(ServiceCollection services) {

            IConfigurationBuilder cfgBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                //.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")}.json", optional: true, reloadOnChange: false)
                ;
            IConfiguration configuration = cfgBuilder.Build();
            services.AddSingleton<IConfiguration>(configuration);
            services.AddIotOmpService(configuration);

            services.UseMJSmartDeviceGrpcClient(configuration);

            services.AddScoped<frmMain>();
            

        }
    }
}