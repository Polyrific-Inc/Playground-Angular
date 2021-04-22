using Microsoft.Extensions.DependencyInjection;
using Polyrific.Project.Core;
using Polyrific.Project.Data;
using Web.API.Category;
using Web.API.Product;

namespace Web.Data
{
    public static class DataRepositorySetup
    {
        public static IServiceCollection AddDataRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository<ProductEntity>, DataRepository<ProductEntity>>();
            services.AddScoped<IRepository<CategoryEntity>, DataRepository<CategoryEntity>>();

            return services;
        }
    }
}
