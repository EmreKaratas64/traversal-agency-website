
namespace BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        void TAdd(T entity);

        void TUpdate(T entity);

        T TGetByID(int id);

        List<T> TGetAll();
    }
}
