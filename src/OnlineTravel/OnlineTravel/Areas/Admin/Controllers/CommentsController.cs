using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace OnlineTravel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/Admin/[controller]/[action]/{id?}")]
    public class CommentsController : Controller
    {
        // aşağıdaki servis tabanlı constructor işlemi EF bağımlılığını kaldırmak için. Direkt böyle kullanılıdığında hata verir, çünkü program.cs de konfigürasyonları yapılmalıdır.
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult ListComments()
        {
            var comments = _commentService.GetCommentswithDestinations();
            return View(comments);
        }

        public IActionResult DeleteComment(int id)
        {
            var item = _commentService.TGetByID(id);
            _commentService.TDelete(item);
            return RedirectToAction("ListComments");
        }
    }
}
