using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SIENN.DbAccess.Entities;
using SIENN.DbAccess.Repositories;

namespace SIENN.DbAccess
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddDbAccessCollection(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ProductDatabase");
            services
                .AddEntityFrameworkSqlServer()
                .AddDbContext<SIENNContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<DbContext, SIENNContext>();

            services.AddScoped<IGenericRepository<Product>, ProductRepository>();
            services.AddScoped<IGenericRepository<Category>, CategoryRepository>();
            services.AddScoped<IGenericRepository<Type>, TypeRepository>();
            services.AddScoped<IGenericRepository<Unit>, UnitRepository>();

            return services;
        }
    }
}