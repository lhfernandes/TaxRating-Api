using Domain.Entities;
using Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface ISegmentService
    {
        Task<ApiResponse<IEnumerable<Segment>>> GetAll();
        Task<ApiResponse<Segment>> GetById(int id);
        Task<ApiResponse<Segment>> Add(Segment segment);
        Task<ApiResponse<Segment>> Update(int id, Segment segment);
        Task<ApiResponse<Segment>> Delete(int id);
        Task<ApiResponse<IEnumerable<Segment>>> GetAllActive();
    }
}
