using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface ICommentService : IGenericService<Comment>
    {
        List<Comment> TGetCommentsWithDestinationsandUser();

        List<Comment> TGetCommentsWithUserByDestinationId(int DestinationId);
    }
}
