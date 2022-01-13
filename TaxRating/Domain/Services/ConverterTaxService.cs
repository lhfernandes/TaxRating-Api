using Domain.Entities;
using Domain.Helpers;
using Domain.Interfaces.ExternalService;
using Domain.Interfaces.Services;
using Domain.Validations;

namespace Domain.Services
{
    public class ConverterTaxService : NotificationService, IConverterTaxService
    {
        private readonly INotificator _notificator;
        private readonly ITaxRateServiceApi _taxRateServiceApi;
        private readonly ISegmentService _segmentService;

        public ConverterTaxService(INotificator notificator,
             ITaxRateServiceApi taxRateServiceApi,
             ISegmentService segmentService) : base(notificator)
        {
            _notificator = notificator;
            _taxRateServiceApi = taxRateServiceApi;
            _segmentService = segmentService;

        }

        public async Task<ApiResponse<ConverterTax>> Converter(ConverterTax convert)
        {
            if (!ExecuteValidation(new ConverterTaxValidator(), convert))
                return ApiResponse<ConverterTax>.FailValidation(_notificator.GetNotifications());

            var segment = await _segmentService.GetById(convert.Segment);

            if (segment.Data is null)
                return ApiResponse<ConverterTax>.FailNotFound(convert.Segment);
           

            TaxRate result = await _taxRateServiceApi.GetRateByPrefixAsync(convert.SymbolToUpper());

            if (result is null)
                return ApiResponse<ConverterTax>.FailNotFound(convert.SymbolToUpper());


            convert.Convert(result.ValueRate, segment.Data.Tax);

            return ApiResponse<ConverterTax>.Success(convert);
        }
    }
}
