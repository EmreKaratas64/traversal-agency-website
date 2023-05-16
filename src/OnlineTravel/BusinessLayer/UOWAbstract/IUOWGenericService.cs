namespace BusinessLayer.UOWAbstract
{
    public interface IUOWGenericService<T> where T : class
    {

        void TInsert(T entity);

        void TUpdate(T entity);

        void TMultiUpdate(List<T> entity);

        T TGetByID(int id);
    }
}
