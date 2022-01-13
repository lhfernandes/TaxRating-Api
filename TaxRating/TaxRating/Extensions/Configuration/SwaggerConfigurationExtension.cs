using Microsoft.OpenApi.Models;
using System.Reflection;

namespace TaxRating.Extensions.Configuration
{
    public static class SwaggerConfigurationExtension
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {  
                    Title = "Tax Rating",
                    Version = "v1"
                });               
            });
        }
    }
}
