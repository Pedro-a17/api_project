using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PokeShop.Infra.Repositories;

namespace PokeShop.Infra
{
    public static class InfrasctructureExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("AppDbConnectionString");
            services.AddDbContext<AppDbContext>(options =>
            {
                var serverVersion = new MySqlServerVersion(new Version(8, 0, 0));

                options.UseMySql(connectionString, serverVersion, x => 
                    x.MigrationsAssembly("PokeShop.Infra"));
            });
            
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<ICenterRepository, CenterRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IStorageRepository, StorageRepository>();

            return services;
        }
    }
}