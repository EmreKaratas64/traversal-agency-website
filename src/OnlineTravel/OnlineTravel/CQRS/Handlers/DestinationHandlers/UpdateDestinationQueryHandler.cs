using DataAccessLayer.Concrete;
using OnlineTravel.CQRS.Results.DestinationResults;

namespace OnlineTravel.CQRS.Handlers.DestinationHandlers
{
    public class UpdateDestinationQueryHandler
    {
        private readonly Context _context;

        public UpdateDestinationQueryHandler(Context context)
        {
            _context = context;
        }

        public void Handle(GetDestinationByIDQueryResult dest)
        {
            var destination = _context.Destinations.Find(dest.DestinationID);
            destination.City = dest.City;
            destination.DayNight = dest.DayNight;
            destination.Price = dest.Price;
            destination.Capacity = dest.Capacity;
            _context.Destinations.Update(destination);
            _context.SaveChanges();

        }
    }
}
