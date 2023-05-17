using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace OnlineTravel.ViewComponents.Comments
{
    public class CommentsInShowDestDetails : ViewComponent
    {
        private readonly ICommentService _commentService;
        Context c = new Context();

        public CommentsInShowDestDetails(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IViewComponentResult Invoke(int id)
        {
            ViewBag.numofComments = c.Comments.Where(x => x.DestinationID == id).Count();
            var comments = _commentService.TGetCommentsWithUserByDestinationId(id);
            return View(comments);
        }
    }
}
