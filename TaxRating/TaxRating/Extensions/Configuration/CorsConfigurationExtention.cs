namespace TaxRating.Extensions.Configuration
{
    public static class CorsConfigurationExtention
    {
        public static void AddCorsConfiguration(this IServiceCollection services)
        {
            services.AddCors(o =>
            {
                o.AddPolicy("CorsPolicy", b => b 
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()                             
                );
               
            });
        }
    }
}
