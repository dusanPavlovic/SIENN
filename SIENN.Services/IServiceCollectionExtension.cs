using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SIENN.DbAccess;
using SIENN.Services.Models;
using SIENN.Services.Services;

namespace SIENN.Services
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddServiceCollection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbAccessCollection(configuration);
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IGenericService<ProductDto>, ProductService>();
            services.AddScoped<IGenericService<TypeDto>, TypeService>();
            services.AddScoped<IGenericService<CategoryDto>, CategoryService>();
            services.AddScoped<IGenericService<UnitDto>, UnitService>();

            return services;
        }
    }
}