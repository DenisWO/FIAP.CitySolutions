namespace FIAP.CitySolutions.API.Extensions
{
    public static class AppConfigurationExtension
    {
        public static void AddAppConfiguration(this IServiceCollection services)
        {
            services.AddControllers();

            services.AddEndpointsApiExplorer();
        }
        public static void UseAppConfiguration(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FIAP.CitySolutions v1"));
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
