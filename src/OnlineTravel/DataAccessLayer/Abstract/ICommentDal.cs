using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface ICommentDal : IGenericDal<Comment>
    {
        List<Comment> GetCommentsWithDestinationsandUser();

        List<Comment> GetCommentsWithUserByDestinationId(int DestinationId);
    }
}
