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

            //���� DI ����
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);  //ע����ַ�����

            //����DI�������� serviceProvider, Ȼ��ͨ�� serviceProvider ��ȡMain Form��ע��ʵ��
            var serviceProvider = services.BuildServiceProvider();

            var formMain = serviceProvider.GetRequiredService<frmMain>();   //�����������л�ȡFormMainʵ��, ���Ǽ��д��
                                                                             // var formMain = (FormMain)serviceProvider.GetService(typeof(FormMain));  //��������д��
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