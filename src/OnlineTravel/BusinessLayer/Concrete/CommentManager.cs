

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
            throw new NotImplementedException();
        }

        public void TAdd(Comment entity)
        {
            _commentDal.Insert(entity);
        }

        public List<Comment> TGetAll()
        {
            throw new NotImplementedException();
        }

        public List<Comment> TGetByFilter(int id)
        {
            return _commentDal.GetListByFilter(x => x.DestinationID == id);
        }

        public void TUpdate(Comment entity)
        {
            throw new NotImplementedException();
        }
    }
}
