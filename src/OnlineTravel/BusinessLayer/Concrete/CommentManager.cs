

using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public Comment TGetByID(int id)
        {
            return _commentDal.GetByID(id);
        }

        public void TAdd(Comment entity)
        {
            _commentDal.Insert(entity);
        }

        public List<Comment> TGetAll()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Comment entity)
        {
            throw new NotImplementedException();
        }

        public List<Comment> TGetCommentsWithDestinationsandUser()
        {
            return _commentDal.GetCommentsWithDestinationsandUser();
        }

        public void TDelete(Comment entity)
        {
            _commentDal.Delete(entity);
        }

        public List<Comment> TGetCommentsWithUserByDestinationId(int DestinationId)
        {
            return _commentDal.GetCommentsWithUserByDestinationId(DestinationId);
        }
    }
}
