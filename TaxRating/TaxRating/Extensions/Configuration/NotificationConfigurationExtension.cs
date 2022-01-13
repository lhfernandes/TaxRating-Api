using Domain.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace TaxRating.Extensions.Configuration
{
    public static class NotificationConfigurationExtension
    {
        public static void AddNotificationConfiguration(this IServiceCollection services)
        {
            services.AddScoped<INotificator, Notificator>();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
        }
    }
}
