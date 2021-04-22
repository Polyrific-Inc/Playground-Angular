using Microsoft.Extensions.DependencyInjection;
using Web.API.Category;
using Web.API.Product;

namespace Web
{
    public static class ApplicationServiceSetup
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICategoryService, CategoryService>();

            return services;
        }
    }
}
