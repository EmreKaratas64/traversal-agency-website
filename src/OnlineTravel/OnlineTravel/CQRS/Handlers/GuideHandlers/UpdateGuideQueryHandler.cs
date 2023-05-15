using DataAccessLayer.Concrete;
using MediatR;
using OnlineTravel.CQRS.Commands.GuideCommands;

namespace OnlineTravel.CQRS.Handlers.GuideHandlers
{
    public class UpdateGuideQueryHandler : IRequestHandler<UpdateGuideCommand>
    {
        private readonly Context _context;

        public UpdateGuideQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateGuideCommand request, CancellationToken cancellationToken)
        {
            var guide = await _context.Guides.FindAsync(request.GuideID);
            guide.Name = request.Name;
            guide.Description = request.Description;
            _context.Guides.Update(guide);
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
