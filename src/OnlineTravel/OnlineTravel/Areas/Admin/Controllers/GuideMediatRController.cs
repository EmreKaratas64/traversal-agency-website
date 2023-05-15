using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineTravel.CQRS.Commands.GuideCommands;
using OnlineTravel.CQRS.Queries.GuideQueries;

namespace OnlineTravel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class GuideMediatRController : Controller
    {
        private readonly IMediator _mediator;

        public GuideMediatRController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> ShowGuides()
        {
            var guides = await _mediator.Send(new GetGuideQuery());
            return View(guides);
        }

        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddGuide(AddGuideCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("ShowGuides");
        }

        [HttpGet]
        public async Task<IActionResult> GetGuide(int id)
        {
            var value = await _mediator.Send(new GetGuideByIDQuery(id));
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> GetGuide(UpdateGuideCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("ShowGuides");
        }
    }
}
