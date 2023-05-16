using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using DataAccessLayer.UOWAbstract;
using EntityLayer.Concrete;

namespace DataAccessLayer.UOWEntityFramework
{
    public class EfAccountDal : UOWGenericRepository<Account>, IAccountDal
    {
        public EfAccountDal(Context context) : base(context)
        {
        }
    }
}
