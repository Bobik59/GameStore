using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess//
{
    public static class Extensions
    {
        public static IServiceCollection AddEFDataAccess(this IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddDbContext<AppDbContext>(x => x.UseSqlServer(connectionString));

            serviceCollection.AddScoped<IGameRepository, EFGameRepository>();

            return serviceCollection;
        }
    }
}
