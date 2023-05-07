using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface ICommentDal : IGenericDal<Comment>
    {
        List<Comment> GetCommentsWithDestinations();
    }
}
