using DataAccessLayer.Concrete;
using DataAccessLayer.UOWAbstract;

namespace DataAccessLayer.Repository
{
    public class UOWGenericRepository<T> : IUOWGenericDal<T> where T : class
    {
        private readonly Context _context;

        public UOWGenericRepository(Context context)
        {
            _context = context;
        }

        public T GetByID(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Insert(T entity)
        {
            _context.Add(entity);
        }

        public void MultiUpdate(List<T> entity)
        {
            _context.UpdateRange(entity);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }
    }
}
