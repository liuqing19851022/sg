
using Elasticsearch.Net;

using Nest;

using PushPgToES.Imps;
using PushPgToES.Interfaces;

namespace PushPgToES
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<ElasticClient>((s) =>
            {
                var connStr = builder.Configuration.GetConnectionString("Es");
                var pool = new SingleNodeConnectionPool(new Uri(connStr!));
                var settings = new ConnectionSettings(pool);
                settings.DefaultFieldNameInferrer(c => c);
                //settings.BasicAuthentication();

                var client = new ElasticClient(settings);
                return client;

            });
            builder.Services.AddSingleton<IPushDbToEs, PgSqlPushToEs>();

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
