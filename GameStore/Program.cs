using DataAccess;

namespace GameStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
            builder.Services.AddEFDataAccess(connectionString);


            var app = builder.Build();

            app.UseStaticFiles();

            app.Run();

        }
    }
}
