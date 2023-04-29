using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace OnlineTravel.Controllers
{
    public class CommentsController : Controller
    {
        CommentManager commentManager = new CommentManager(new EfCommentDal());

        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult AddComment(Comment comment)
        {
            comment.CommentDate = DateTime.Now;
            comment.CommentStatus = true;
            comment.DestinationID = comment.DestinationID;
            commentManager.TAdd(comment);
            TempData["CommentSuccess"] = "Your comment is saved. Thanks for the comment!";
            return RedirectToAction("ShowHome", "Home");
        }
    }
}
