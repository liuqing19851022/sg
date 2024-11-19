using MJ.Payment.Core.Extentions;
using MJ.Payment.Core.ViewModel;
//using MJ.SmartPlug.EWeLink;
//using MJ.SmartPlug.EWeLink.Grpc;

namespace MJThirdParty.Debug
{
    public class Program
    {
        public static IConfigurationRoot BuildJsonConfig<T>(string path = "Config") where T : class
        {
            string configName = $"{typeof(T).Name}.json";
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), path);
            var configBuilder = new ConfigurationBuilder();
            configBuilder.SetBasePath(filePath);
            configBuilder.AddJsonFile(configName, false, true);
            var configuration = configBuilder.Build();
            return configuration;
        }

        public static void MjJsonConfigure<T>(IServiceCollection service) where T : class
        {
            var configuration = BuildJsonConfig<T>();
            service.Configure<T>(configuration);
        }

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //builder.Services.AddEWeLinkSmartPlug(builder.Configuration);

            //builder.Services.AddEWeLinkGrpcService(builder.Configuration);

            //builder.Services.AddXinBoRuiSpeaker(builder.Configuration);

            //builder.Services.AddServerSideBlazor();

            builder.Services.AddCors(option =>
            {
                option.AddPolicy("all", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();

                });
            });
            //MjJsonConfigure<LvMiDeceiveTypeMapConfig>(builder.Services);

            //builder.Services.AddLvMiSmartPlug(builder.Configuration);
            //builder.Services.AddTongTongLock(builder.Configuration);

            //builder.Services.UseDirectPayModule(builder.Configuration.GetSection("Payment"), new List<System.Reflection.Assembly>(), null);


            builder.Services.UseMJPaymentModule(builder.Configuration.GetSection("Payment"));

            builder.Services.Configure<MerchantPaymentSetting>(builder.Configuration.GetSection("MerchantPaymentSetting"));
            //builder.Services.AddIotOmpService(builder.Configuration);
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.UseCors("all");
            app.MapControllers();

            app.Run();
        }
    }
}