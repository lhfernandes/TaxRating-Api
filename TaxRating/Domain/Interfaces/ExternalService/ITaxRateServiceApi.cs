using Domain.Entities;

namespace Domain.Interfaces.ExternalService
{
    public interface ITaxRateServiceApi
    {
        Task<TaxRate> GetRateByPrefixAsync(string prefix);
    }
}
