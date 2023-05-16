using BusinessLayer.UOWAbstract;
using DataAccessLayer.UnitOfWork;
using DataAccessLayer.UOWAbstract;
using EntityLayer.Concrete;

namespace BusinessLayer.UOWConcrete
{
    public class AccountManager : IAccountService
    {
        private readonly IAccountDal _accountDal;
        private readonly IUnitOfWorkDal _unitOfWorkDal;

        public AccountManager(IAccountDal accountDal, IUnitOfWorkDal unitOfWorkDal)
        {
            _accountDal = accountDal;
            _unitOfWorkDal = unitOfWorkDal;
        }

        public Account TGetByID(int id)
        {
            return _accountDal.GetByID(id);
        }

        public void TInsert(Account entity)
        {
            _accountDal.Insert(entity);
            _unitOfWorkDal.Save();
        }

        public void TMultiUpdate(List<Account> entity)
        {
            _accountDal.MultiUpdate(entity);
            _unitOfWorkDal.Save();
        }

        public void TUpdate(Account entity)
        {
            _accountDal.Update(entity);
            _unitOfWorkDal.Save();
        }
    }
}
