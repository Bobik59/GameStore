using DataAccess;
using GamesStore.Endpoints;
using GamesStore.Services;

namespace GameStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
            builder.Services.AddEFDataAccess(connectionString);

            builder.Services.AddTransient<RequestHandlerService>();

            var app = builder.Build();

            app.UseStaticFiles();

            app.MapGet("/", (RequestHandlerService requestHandler) => requestHandler.ShowHtml("Index.html"));
            app.MapApiGameEndpoints();
            app.MapGameEndpoints();

            app.Run();
        }
    }
}
