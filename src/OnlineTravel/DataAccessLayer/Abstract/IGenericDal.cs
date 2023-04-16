

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        void Insert(T entity);

        void Update(T entity);

        T Get(int entityId);

        List<T> GetAll();
    }
}
