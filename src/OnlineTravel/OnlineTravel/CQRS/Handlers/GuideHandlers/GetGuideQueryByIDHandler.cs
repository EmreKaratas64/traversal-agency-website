using DataAccessLayer.Concrete;
using MediatR;
using OnlineTravel.CQRS.Queries.GuideQueries;
using OnlineTravel.CQRS.Results.GuideResults;

namespace OnlineTravel.CQRS.Handlers.GuideHandlers
{
    public class GetGuideQueryByIDHandler : IRequestHandler<GetGuideByIDQuery, GetGuideByIDQueryResult>
    {
        private readonly Context _context;

        public GetGuideQueryByIDHandler(Context context)
        {
            _context = context;
        }

        public async Task<GetGuideByIDQueryResult> Handle(GetGuideByIDQuery request, CancellationToken cancellationToken)
        {
            var guide = await _context.Guides.FindAsync(request.id);
            return new GetGuideByIDQueryResult
            {
                GuideID = guide.GuideID,
                Name = guide.Name,
                Description = guide.Description
            };
        }
    }
}
