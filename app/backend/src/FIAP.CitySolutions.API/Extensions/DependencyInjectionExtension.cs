using FIAP.CitySolutions.Business.Apps;
using FIAP.CitySolutions.Business.Apps.Interfaces;
using FIAP.CitySolutions.Data.Repositories;
using FIAP.CitySolutions.Data.Repositories.Interfaces;

namespace FIAP.CitySolutions.API.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<HttpClient>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IResponsibleRepository, ResponsibleRepository>();
            services.AddScoped<IIncidentAttachmentRepository, IncidentAttachmentRepository>();
            services.AddScoped<IncidentRepository, IncidentRepository>();

            services.AddScoped<IUserApp, UserApp>();
        }
    }
}
