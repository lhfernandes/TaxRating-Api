using Domain.Entities;
using Domain.Helpers;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaxRating.ViewModels;

namespace TaxRating.Controllers
{
    [Route("v1/tax-rating")]    
    public class TaxRatingController : ApplicationController
    {
        private readonly ITaxRateService _taxRateService;
        public TaxRatingController(   
            ITaxRateService taxRateService,
            INotificator notificador) : base(notificador)
        {
          _taxRateService = taxRateService;
        }

        #region Método GetTaxRateByRatePrefix
        /// <summary>
        /// Get Rating by prefix of money
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        [HttpGet("{prefix}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ApiResponse<GetAllTaxRatingViewModel>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<GetAllTaxRatingViewModel>))]
        public async Task<ActionResult<ApiResponse<TaxRate>>> GetTaxRateByPrefix(string prefix)
            => CustomResponse(await _taxRateService.GetTaxRateByPrefix(prefix));


        [HttpGet("{segment:int}/{prefix}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ApiResponse<GetAllTaxRatingViewModel>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<GetAllTaxRatingViewModel>))]
        public async Task<ActionResult<ApiResponse<TaxRate>>> GetTaxRateBySegmentPrefix(int segment,string prefix)
            => CustomResponse(await _taxRateService.GetTaxRateByPrefix(prefix));

        #endregion

        //#region Método GETID
        ///// <summary>
        ///// Get by identifier
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //[HttpGet("{id:int}")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<GetAllVehicleTypeViewModel>))]
        //[ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<GetAllVehicleTypeViewModel>))]
        //public async Task<ActionResult<ApiResponse<VehicleType>>> GetById(int id)
        //    => CustomResponse(_mapper.Map<ApiResponse<VehicleType>>(await _vehicleTypeService.GetById(id)));

        //#endregion

        //#region Método POST
        ///// <summary>
        ///// Create Insurance.
        ///// </summary>
        ///// <param name="vehicleType"></param>
        ///// <param name="userId"></param>
        ///// <returns></returns>
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ApiResponse<VehicleType>))]
        //[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<VehicleType>))]
        //public async Task<ActionResult<ApiResponse<VehicleType>>> Post(
        //    [FromBody] CreateVehicleTypeViewModel vehicleType, [FromHeader] string userId)
        //    => CustomResponse(await _vehicleTypeService.Add(_mapper.Map<VehicleType>(vehicleType), userId));

        //#endregion

        //#region Método PUT
        ///// <summary>
        ///// Update Insurance.
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="vehicleType"></param>
        ///// <param name="userId"></param>
        ///// <returns></returns>
        //[HttpPut("{id:int}")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<VehicleType>))]
        //[ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<VehicleType>))]

        //public async Task<ActionResult<ApiResponse<VehicleType>>> Put(int id, [FromBody] UpdateVehicleTypeViewModel vehicleType, [FromHeader] string userId)
        //    => CustomResponse(await _vehicleTypeService.Update(id, _mapper.Map<VehicleType>(vehicleType), userId));

        //#endregion

        //#region Método DELETE
        ///// <summary>
        ///// Inactivate Insurance.
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="userId"></param>
        ///// <returns></returns>
        //[HttpDelete("{id:int}")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<VehicleType>))]
        //public async Task<ActionResult<ApiResponse<VehicleType>>> Delete(int id, [FromHeader] string userId)
        //    => CustomResponse(await _vehicleTypeService.Delete(id, userId));

        //#endregion

    }
}
