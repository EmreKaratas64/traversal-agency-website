using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public Contact TGetByID(int id)
        {
            return _contactDal.GetByID(id);
        }

        public void TAdd(Contact entity)
        {
            _contactDal.Insert(entity);
        }

        public List<Contact> TGetAll()
        {
            return _contactDal.GetAll();
        }

        public void TUpdate(Contact entity)
        {
            _contactDal.Update(entity);
        }
    }
}
