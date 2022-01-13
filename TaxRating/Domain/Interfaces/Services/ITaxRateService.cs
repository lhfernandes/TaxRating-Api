using Domain.Entities;
using Domain.Helpers;

namespace Domain.Interfaces.Services
{
    public interface ITaxRateService
    {
        public Task<ApiResponse<TaxRate>>  GetTaxRateByPrefix(string prefix);
    }
}
