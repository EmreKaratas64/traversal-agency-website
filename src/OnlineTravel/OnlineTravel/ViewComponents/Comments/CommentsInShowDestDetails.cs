using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace OnlineTravel.ViewComponents.Comments
{
    public class CommentsInShowDestDetails : ViewComponent
    {
        CommentManager commentManager = new CommentManager(new EfCommentDal());

        public IViewComponentResult Invoke(int id)
        {
            var comments = commentManager.TGetByFilter(id);
            return View(comments);
        }
    }
}
