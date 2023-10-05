using FIAP.CitySolutions.Data.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace FIAP.CitySolutions.API.Extensions
{
    public static class DataContextConfigurationExtension
    {
        public static void AddDataContextConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<DataContext>(options =>
                options.UseMySql(connectionString,
                ServerVersion.AutoDetect(connectionString)));
        }
        public static void UseDataContextConfiguration(this WebApplication app)
        {
            var serviceScopeFactory = (IServiceScopeFactory) app.Services.GetService(typeof(IServiceScopeFactory));

            using (var scope = serviceScopeFactory.CreateScope())
            {
                var services = scope.ServiceProvider;
                var dbContext = services.GetRequiredService<DataContext>();

                dbContext.Database.Migrate();
            }
        }
    }
}
