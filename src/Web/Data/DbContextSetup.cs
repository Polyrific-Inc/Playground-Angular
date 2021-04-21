using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Web.Data
{
    public static class DbContextSetup
    {
        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services)
        {
            services
                .AddDbContext<DbContext, ApplicationDbContext>(options =>
                {
                    options.UseInMemoryDatabase("playground-angular");
                })
                .AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseInMemoryDatabase("playground-angular");
                });

            return services;
        }
    }
}
