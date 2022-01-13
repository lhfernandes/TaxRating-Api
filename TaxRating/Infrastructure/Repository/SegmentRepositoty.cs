using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Context;

namespace Infrastructure.Repository
{
    public class SegmentRepositoty : BaseRepository<Segment>, ISegmentRepositoty
    {
        private readonly TaxRatingContext _context;
        public SegmentRepositoty(TaxRatingContext context) : base(context)
        {
            _context = context;
        }
    }
}
