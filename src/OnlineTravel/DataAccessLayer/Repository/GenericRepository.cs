using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {

        public T Get(int entityId)
        {
            using var c = new Context();
            return c.Set<T>().Find(entityId);
        }

        public List<T> GetAll()
        {
            using var c = new Context();
            return c.Set<T>().ToList();
        }

        public void Insert(T entity)
        {
            using (var c = new Context())
            {
                c.Add(entity);
            }
        }

        public void Update(T entity)
        {
            using var c = new Context();
            c.Update(entity);
        }
    }
}
