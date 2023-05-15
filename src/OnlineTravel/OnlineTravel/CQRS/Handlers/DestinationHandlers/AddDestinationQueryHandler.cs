using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using OnlineTravel.CQRS.Commands.DestinationCommands;

namespace OnlineTravel.CQRS.Handlers.DestinationHandlers
{
    public class AddDestinationQueryHandler
    {
        private readonly Context _context;

        public AddDestinationQueryHandler(Context context)
        {
            _context = context;
        }

        public void Handle(AddDestinationCommand command)
        {
            _context.Add(new Destination
            {
                City = command.City,
                DayNight = command.DayNight,
                Capacity = command.Capacity,
                Price = command.Price,
                Status = true
            });
            _context.SaveChanges();
        }
    }
}
