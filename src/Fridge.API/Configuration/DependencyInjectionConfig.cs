using Fridge.Repository.Context;
using Fridge.Repository.Repositories;
using Fridge.Service.Interfaces;
using Fridge.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Fridge.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<FridgeDbContext>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}
