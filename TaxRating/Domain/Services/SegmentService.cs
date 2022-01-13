using Domain.Entities;
using Domain.Helpers;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Validations;

namespace Domain.Services
{
    public class SegmentService : NotificationService, ISegmentService
    {
        private readonly ISegmentRepositoty _segmentRepositoty;
        private readonly INotificator _notificator;

        public SegmentService(ISegmentRepositoty segmentRepositoty,
            INotificator notificator) : base(notificator)
        {
            _segmentRepositoty = segmentRepositoty;
            _notificator = notificator;
        }

        #region Método GETALL
        public async Task<ApiResponse<IEnumerable<Segment>>> GetAll()
        {
            var response = await _segmentRepositoty.GetAll();
            if (!response.Any())
                return ApiResponse<IEnumerable<Segment>>.FailEmpty();

            return ApiResponse<IEnumerable<Segment>>.Success(response);
        }
        #endregion

        #region Método GETALL Active
        public async Task<ApiResponse<IEnumerable<Segment>>> GetAllActive()
        {
            var response = await _segmentRepositoty.Find(s => s.IsActive);
            if (!response.Any())
                return ApiResponse<IEnumerable<Segment>>.FailEmpty();

            return ApiResponse<IEnumerable<Segment>>.Success(response);
        }
        #endregion

        #region Método GET por Id
        public async Task<ApiResponse<Segment>> GetById(int id)
        {
            var response = await _segmentRepositoty.GetById(id);
            if (response is null)
                return ApiResponse<Segment>.FailNotFound(id);

            return ApiResponse<Segment>.Success(response);
        }
        #endregion

        #region Método POST
        public async Task<ApiResponse<Segment>> Add(Segment segment)
        {
            if (!ExecuteValidation(new SegmentValidator(), segment))
                return ApiResponse<Segment>.FailValidation(_notificator.GetNotifications());

            await _segmentRepositoty.Add(segment);

            return ApiResponse<Segment>.Success(segment);
        }

        #endregion

        #region Método UPDATE
        public async Task<ApiResponse<Segment>> Update(int id, Segment segment)
        {
            var response = await _segmentRepositoty.GetById(id);

            if (response is null)
                return ApiResponse<Segment>.FailNotFound(id);

            if (!ExecuteValidation(new SegmentValidator(), segment))
            {
                return ApiResponse<Segment>.FailValidation(_notificator.GetNotifications());
            }

            response.ChangeSegment(segment.Name, segment.Tax, segment.IsActive);
            await _segmentRepositoty.Update(response);
            return ApiResponse<Segment>.Success(response);
        }
        #endregion

        #region Método DELETE por Id
        public async Task<ApiResponse<Segment>> Delete(int id)
        {
            var response = await _segmentRepositoty.GetById(id);

            if (response is null)
                return ApiResponse<Segment>.FailNotFound(id);

            response.ChangeActive(false);
            await _segmentRepositoty.Update(response);
            return ApiResponse<Segment>.Success(response);
        }
        #endregion
    }
}
