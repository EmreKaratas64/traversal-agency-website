using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SubAboutManager : ISubAboutService
    {
        ISubAboutDal _subAboutDal;

        public SubAboutManager(ISubAboutDal subAboutDal)
        {
            _subAboutDal = subAboutDal;
        }

        public SubAbout GetById(int id)
        {
            return _subAboutDal.Get(id);
        }

        public void TAdd(SubAbout entity)
        {
            _subAboutDal.Insert(entity);
        }

        public List<SubAbout> TGetAll()
        {
            return _subAboutDal.GetAll();
        }

        public void TUpdate(SubAbout entity)
        {
            _subAboutDal.Update(entity);
        }
    }
}
