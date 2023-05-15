using DataAccessLayer.Concrete;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineTravel.CQRS.Queries.GuideQueries;
using OnlineTravel.CQRS.Results.GuideResults;

namespace OnlineTravel.CQRS.Handlers.GuideHandlers
{
    public class GetGuideQueryHandler : IRequestHandler<GetGuideQuery, List<GetGuideQueryResult>>
    {
        private readonly Context _context;

        public GetGuideQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<List<GetGuideQueryResult>> Handle(GetGuideQuery request, CancellationToken cancellationToken)
        {
            return await _context.Guides.Select(x => new GetGuideQueryResult
            {
                GuideID = x.GuideID,
                Description = x.Description,
                Name = x.Name
            }).AsNoTracking().ToListAsync();
        }
    }
}
