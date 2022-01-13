using Domain.Entities;
using Domain.Helpers;
using Domain.Interfaces.ExternalService;
using Domain.Interfaces.Services;

namespace Domain.Services
{
    public class TaxRateService : NotificationService,ITaxRateService
    {
        private readonly INotificator _notificator;
        private readonly ITaxRateServiceApi _taxRateServiceApi;
        public TaxRateService(INotificator notificator,
            ITaxRateServiceApi taxRateServiceApi) : base(notificator)
        {
            _notificator = notificator;
            _taxRateServiceApi = taxRateServiceApi;
        }       

        public async Task<ApiResponse<TaxRate>> GetTaxRateByPrefix(string prefix)
        {
            prefix = prefix.ToUpper();

            TaxRate result = await _taxRateServiceApi.GetRateByPrefixAsync(prefix);

            return ApiResponse<TaxRate>.Success(result);
        }
    }
}
