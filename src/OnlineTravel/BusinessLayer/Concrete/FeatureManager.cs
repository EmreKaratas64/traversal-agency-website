using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;


namespace BusinessLayer.Concrete
{
    public class FeatureManager : IFeatureService
    {
        IFeatureDal _featureDal;

        public FeatureManager(IFeatureDal featureDal)
        {
            _featureDal = featureDal;
        }

        public Feature GetById(int id)
        {
            return _featureDal.Get(id);
        }

        public void TAdd(Feature entity)
        {
            _featureDal.Insert(entity);
        }

        public List<Feature> TGetAll()
        {
            return _featureDal.GetAll();    
        }

        public void TUpdate(Feature entity)
        {
            _featureDal.Update(entity);
        }
    }
}
