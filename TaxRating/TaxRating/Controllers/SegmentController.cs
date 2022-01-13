using AutoMapper;
using Domain.Entities;
using Domain.Helpers;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using TaxRating.ViewModels.Segment;


namespace TaxRating.Controllers
{
    [Route("v1/segments")]   
    public class SegmentController : ApplicationController
    {
        private readonly ISegmentService _segmentService;
        private readonly IMapper _mapper;

        public SegmentController(
            ISegmentService segmentService,
            IMapper mapper,
            INotificator notificador) : base(notificador)
        {
            _segmentService = segmentService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all Segments.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ApiResponse<GetSegmentViewModel>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<GetSegmentViewModel>))]
        public async Task<ActionResult<ApiResponse<Segment>>> GetAll()
            => CustomResponse(await _segmentService.GetAll());

        /// <summary>
        /// Get all Segments.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ApiResponse<GetSegmentViewModel>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<GetSegmentViewModel>))]
        public async Task<ActionResult<ApiResponse<Segment>>> GetAllActive()
            => CustomResponse(await _segmentService.GetAllActive());

        /// <summary>
        /// Get by identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<GetSegmentViewModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<GetSegmentViewModel>))]
        public async Task<ActionResult<ApiResponse<Segment>>> GetById(int id)
            => CustomResponse(_mapper.Map<ApiResponse<Segment>>(await _segmentService.GetById(id)));

        /// <summary>
        /// Create Segment.
        /// </summary>
        /// <param name="segment"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ApiResponse<Segment>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<Segment>))]
        public async Task<ActionResult<ApiResponse<Segment>>> Post(
            [FromBody] CreateSegmentViewModel segment)
            => CustomResponse(await _segmentService.Add(_mapper.Map<Segment>(segment)));

        /// <summary>
        /// Update Type of Insurance.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="segment"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<Segment>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<Segment>))]
        public async Task<ActionResult<ApiResponse<Segment>>> Put(int id,
            [FromBody] UpdateSegmentViewModel segment)
            => CustomResponse(await _segmentService.Update(id, _mapper.Map<Segment>(segment)));

        /// <summary>
        /// Inactivate Type of Insurance.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<Segment>))]
        public async Task<ActionResult<ApiResponse<Segment>>> Delete(int id)
            => CustomResponse(await _segmentService.Delete(id));
    }
}
