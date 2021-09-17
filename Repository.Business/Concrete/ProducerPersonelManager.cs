using Repository.Business.Abstract;
using Repository.DataAccess.Abstract;
using Repository.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Business.Concrete
{
    public class ProducerPersonelManager : IProducerPersonelService
    {
        private readonly IProducerPersonelDal _ppDal;

        public ProducerPersonelManager(IProducerPersonelDal ppDal)
        {
            _ppDal = ppDal;
        }

        public IList<ProducerPersonel> GetList_All()
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<ProducerPersonel>> GetList_All_Async()
        {
            throw new System.NotImplementedException();
        }

        public void Add(ProducerPersonel entity)
        {
            throw new System.NotImplementedException();
        }

        public void Add_Async(ProducerPersonel entity)
        {
            throw new System.NotImplementedException();
        }

        public void AddList(IList<ProducerPersonel> entities)
        {
            throw new System.NotImplementedException();
        }

        public void AddList_Async(IList<ProducerPersonel> entities)
        {
            throw new System.NotImplementedException();
        }

        public void Update(ProducerPersonel entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update_Async(ProducerPersonel entity)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateList(IList<ProducerPersonel> entities)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateList_Async(IList<ProducerPersonel> entities)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(ProducerPersonel entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete_Async(ProducerPersonel entity)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteList(IList<ProducerPersonel> entities)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteList_Async(IList<ProducerPersonel> entities)
        {
            throw new System.NotImplementedException();
        }

        public ProducerPersonel Get_ById(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ProducerPersonel> Get_ById_Async(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}