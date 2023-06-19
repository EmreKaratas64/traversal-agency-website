using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineTravel.CQRS.Commands.DestinationCommands;
using OnlineTravel.CQRS.Handlers.DestinationHandlers;
using OnlineTravel.CQRS.Queries.DestinationQueries;
using OnlineTravel.CQRS.Results.DestinationResults;

namespace OnlineTravel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [Authorize(Roles = "Admin")]
    public class DestinationCQRSController : Controller
    {
        private readonly GetDestinationQueryHandler _handler;
        private readonly GetDestinationByIDQueryHandler _getDestinationByIDQueryHandler;
        private readonly AddDestinationQueryHandler _addDestinationByIDQueryHandler;
        private readonly UpdateDestinationQueryHandler _updateDestinationByIDQueryHandler;

        public DestinationCQRSController(GetDestinationQueryHandler handler, GetDestinationByIDQueryHandler getDestinationByIDQueryHandler, AddDestinationQueryHandler addDestinationByIDQueryHandler, UpdateDestinationQueryHandler updateDestinationByIDQueryHandler)
        {
            _handler = handler;
            _getDestinationByIDQueryHandler = getDestinationByIDQueryHandler;
            _addDestinationByIDQueryHandler = addDestinationByIDQueryHandler;
            _updateDestinationByIDQueryHandler = updateDestinationByIDQueryHandler;
        }

        public IActionResult ShowDestinations()
        {
            var values = _handler.Handle();
            return View(values);
        }

        [HttpGet]
        public IActionResult GetDestinationById(int id)
        {
            if (id == 0) return NotFound();
            var value = _getDestinationByIDQueryHandler.Handle(new GetDestinationByIDQuery(id));
            return View(value);
        }

        [HttpPost]
        public IActionResult GetDestinationById(GetDestinationByIDQueryResult dest)
        {
            _updateDestinationByIDQueryHandler.Handle(dest);
            return RedirectToAction("ShowDestinations");
        }

        [HttpGet]
        public IActionResult AddDestination()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDestination(AddDestinationCommand command)
        {
            _addDestinationByIDQueryHandler.Handle(command);
            return RedirectToAction("ShowDestinations");
        }


    }
}
