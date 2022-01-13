using Domain.Interfaces.Services;
using Domain.Services;

namespace TaxRating.Extensions.Configuration
{
    public static class ServiceConfigurationExtension
    {
        public static void AddServicesDependencyGroup(this IServiceCollection services)
        {
            services.AddScoped<ITaxRateService, TaxRateService>();
            services.AddScoped<ISegmentService, SegmentService>();
            services.AddScoped<IConverterTaxService, ConverterTaxService>();
        }
    }
}
