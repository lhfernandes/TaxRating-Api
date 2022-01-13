using AutoMapper;
using Domain.Entities;
using Domain.Helpers;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaxRating.ViewModels.ConverterTax;

namespace TaxRating.Controllers
{
    [Route("v1/converter-tax")]
    
    public class ConverterTaxController : ApplicationController
    {
        private readonly IConverterTaxService _converterTaxService;
        private readonly IMapper _mapper;

        public ConverterTaxController(
            IConverterTaxService converterTaxService,
            IMapper mapper,
            INotificator notificador) : base(notificador)
        {
            _converterTaxService = converterTaxService;
            _mapper = mapper;
        }

        /// <summary>
        /// Execute Converter.
        /// </summary>
        /// <param name="converter"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<ConverterTax>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<ConverterTax>))]
        public async Task<ActionResult<ApiResponse<ConverterTax>>> Post(
            [FromBody] GetConverterTaxViewModel converter)
            => CustomResponse(await _converterTaxService.Converter(_mapper.Map<ConverterTax>(converter)));
    }
}
