using Microsoft.OpenApi.Models;
using MJ.ThirdParty.NBIotCard.Recharge.Client.Extentions;
namespace MJIotRecharge.Debug
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddIotOmpService(builder.Configuration);
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "½Ó¿Ú", Version = "v1" });

                var folder = AppContext.BaseDirectory;
                foreach (var xml in Directory.GetFiles(folder, "*.xml", SearchOption.TopDirectoryOnly))
                {
                    c.IncludeXmlComments(xml, true);
                }

            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
