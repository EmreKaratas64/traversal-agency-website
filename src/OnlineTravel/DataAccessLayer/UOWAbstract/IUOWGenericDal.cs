

namespace DataAccessLayer.UOWAbstract
{
    public interface IUOWGenericDal<T> where T : class
    {
        void Insert(T entity);

        void Update(T entity);

        void MultiUpdate(List<T> entity);

        T GetByID(int id);
    }
}
