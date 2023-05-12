
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class NotificationManager : INotificationService
    {
        INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public void TAdd(Notification entity)
        {
            _notificationDal.Insert(entity);
        }

        public void TDelete(Notification entity)
        {
            _notificationDal.Delete(entity);
        }

        public List<Notification> TGetAll()
        {
            return _notificationDal.GetAll();
        }

        public Notification TGetByID(int id)
        {
            return _notificationDal.GetByID(id);
        }

        public void TUpdate(Notification entity)
        {
            _notificationDal.Update(entity);
        }
    }
}
