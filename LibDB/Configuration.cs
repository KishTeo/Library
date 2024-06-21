using LibDB.data;
using LibDB.Interfaces;
using LibDB.models;
using LibDB.repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.CodeDom;

namespace libDB
{
    public static class Configuration
    {
        public static void ConfigureDALServices(this IServiceCollection services)
        {
            services.AddDbContext<LibContext>(options =>
            options.UseInMemoryDatabase("Library"));

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
