

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        void TAdd(T entity);

        void TUpdate(T entity);

        T GetById(int id);

        List<T> TGetAll();
    }
}
