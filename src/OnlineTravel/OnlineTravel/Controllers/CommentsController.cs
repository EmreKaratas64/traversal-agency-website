using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace OnlineTravel.Controllers
{
    [AllowAnonymous]
    public class CommentsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICommentService _commentService;
        Context c = new Context();

        public CommentsController(UserManager<AppUser> userManager, ICommentService commentService)
        {
            _userManager = userManager;
            _commentService = commentService;
        }

        [HttpGet]
        public PartialViewResult AddComment(int Id)
        {
            ViewBag.Id = Id;
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(Comment comment)
        {
            if (User.Identity?.IsAuthenticated == false) return RedirectToAction("SignUp", "Account");
            bool exists = c.Destinations.Any(x => x.DestinationID == comment.DestinationID);
            if (!exists)
            {
                TempData["NotExists"] = "Invalid data!";
                return RedirectToAction("ShowHome", "Home");
            }
            var currentUser = await _userManager.FindByNameAsync(User.Identity?.Name);
            comment.CommentDate = DateTime.Now;
            comment.CommentStatus = false;
            comment.DestinationID = comment.DestinationID;
            comment.AppUserID = currentUser.Id;
            _commentService.TAdd(comment);
            TempData["CommentSuccess"] = "Your comment is saved. Thanks for the comment!";
            return RedirectToAction("ShowHome", "Home");
        }
    }
}
