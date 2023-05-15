using DataAccessLayer.Concrete;
using OnlineTravel.CQRS.Queries.DestinationQueries;
using OnlineTravel.CQRS.Results.DestinationResults;

namespace OnlineTravel.CQRS.Handlers.DestinationHandlers
{
    public class GetDestinationByIDQueryHandler
    {
        private readonly Context _context;

        public GetDestinationByIDQueryHandler(Context context)
        {
            _context = context;
        }

        public GetDestinationByIDQueryResult Handle(GetDestinationByIDQuery query)
        {
            var values = _context.Destinations.Find(query.id);
            return new GetDestinationByIDQueryResult
            {
                DestinationID = values.DestinationID,
                City = values.City,
                DayNight = values.DayNight,
                Capacity = values.Capacity,
                Price = values.Price
            };
        }
    }
}
