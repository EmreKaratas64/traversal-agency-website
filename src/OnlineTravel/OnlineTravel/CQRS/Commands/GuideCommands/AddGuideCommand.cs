using MediatR;

namespace OnlineTravel.CQRS.Commands.GuideCommands
{
    public class AddGuideCommand : IRequest
    {
        public string? Name { get; set; }

        public string? Description { get; set; }
    }
}
