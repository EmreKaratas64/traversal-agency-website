using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using MediatR;
using OnlineTravel.CQRS.Commands.GuideCommands;

namespace OnlineTravel.CQRS.Handlers.GuideHandlers
{
    public class AddGuideQueryHandler : IRequestHandler<AddGuideCommand>
    {
        private readonly Context _context;

        public AddGuideQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(AddGuideCommand request, CancellationToken cancellationToken)
        {
            _context.Guides.Add(new Guide
            {
                Name = request.Name,
                Description = request.Description,
                status = true
            });
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
