using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EfCommentDal : GenericRepository<Comment>, ICommentDal
    {
        public List<Comment> GetCommentsWithUserByDestinationId(int DestinationId)
        {
            using (var c = new Context())
            {
                return c.Comments.Where(x => x.DestinationID == DestinationId).Include(y => y.AppUser).ToList();
            }
        }

        public List<Comment> GetCommentsWithDestinationsandUser()
        {
            using (var c = new Context())
            {
                return c.Comments.Include(x => x.Destination).Include(y => y.AppUser).ToList();
            }
        }
    }
}
