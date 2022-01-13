using Domain.Interfaces.ExternalService;
using Domain.Interfaces.Repositories;
using Infrastructure.ExternalService;
using Infrastructure.Repository;

namespace TaxRating.Extensions.Configuration
{
    public static class RepositoryConfigurationExtension
    {
        public static void AddRepositoryDependencyGroup(this IServiceCollection services)
        {
            services.AddScoped<ITaxRateServiceApi, TaxRateServiceApi>();
            services.AddScoped<ISegmentRepositoty, SegmentRepositoty>();
        }
    }
}
