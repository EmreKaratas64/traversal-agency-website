using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using OnlineTravel.CQRS.Results.DestinationResults;

namespace OnlineTravel.CQRS.Handlers.DestinationHandlers
{
    public class GetDestinationQueryHandler
    {
        private readonly Context _context;

        public GetDestinationQueryHandler(Context context)
        {
            _context = context;
        }

        public List<GetDestinationQueryResult> Handle()
        {
            var values = _context.Destinations.Select(x => new GetDestinationQueryResult
            {
                id = x.DestinationID,
                city = x.City,
                daynight = x.DayNight,
                price = x.Price,
                capacity = x.Capacity
            }).AsNoTracking().ToList();

            return values;
        }
    }
}
