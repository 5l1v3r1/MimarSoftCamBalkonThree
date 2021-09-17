using Core.Utilities.Aspects.Autofac.Caching;
using Core.Utilities.Aspects.Autofac.Validation;
using Repository.Business.Abstract;
using Repository.Business.Rules.FluentValidation;
using Repository.Business.Utilities.Aspects;
using Repository.DataAccess.Abstract;
using Repository.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Business.Concrete
{
    public class ProducerManager : IProducerService
    {
        private readonly IProducerDal _producerDal;

        public ProducerManager(IProducerDal producerDal)
        {
            _producerDal = producerDal;
        }

        [CacheAspect]
        public Producer Get_ById(short id)
        {
            return _producerDal.Get(x => x.Id == id);
        }

        [CacheAspect]
        public Task<Producer> Get_ById_Async(short id)
        {
            return _producerDal.GetAsync(x => x.Id == id);
        }

        [CacheAspect]
        public IList<Producer> GetList_All()
        {
            return _producerDal.GetList();
        }

        [CacheAspect]
        public async Task<IList<Producer>> GetList_All_Async()
        {
            return await _producerDal.GetListAsync();
        }

        [SecuredOperation("producer.add,admin")]
        [ValidationAspect(typeof(ProducerValidator))]
        [CacheRemoveAspect("IProducerService.Get")]
        public void Add(Producer producer)
        {
            _producerDal.Add(producer);
        }

        [SecuredOperation("producer.add,admin")]
        [ValidationAspect(typeof(ProducerValidator))]
        [CacheRemoveAspect("IProducerService.Get")]
        public async void Add_Async(Producer producer)
        {
            await Task.Run(() => _producerDal.AddAsync(producer));
        }

        [SecuredOperation("producer.add,admin")]
        [ValidationAspect(typeof(ProducerValidator))]
        [CacheRemoveAspect("IProducerService.Get")]
        public void AddList(IList<Producer> producers)
        {
            _producerDal.AddList(producers);
        }

        [SecuredOperation("producer.add,admin")]
        [ValidationAspect(typeof(ProducerValidator))]
        [CacheRemoveAspect("IProducerService.Get")]
        public async void AddList_Async(IList<Producer> producers)
        {
            await Task.Run(() => _producerDal.AddListAsync(producers));
        }

        [SecuredOperation("producer.update,admin")]
        [ValidationAspect(typeof(ProducerValidator))]
        [CacheRemoveAspect("IProducerService.Get")]
        public void Update(Producer producer)
        {
            _producerDal.Update(producer);
        }

        [SecuredOperation("producer.update,admin")]
        [ValidationAspect(typeof(ProducerValidator))]
        [CacheRemoveAspect("IProducerService.Get")]
        public async void Update_Async(Producer producer)
        {
            await Task.Run(() => _producerDal.UpdateAsync(producer));
        }

        [SecuredOperation("producer.update,admin")]
        [ValidationAspect(typeof(ProducerValidator))]
        [CacheRemoveAspect("IProducerService.Get")]
        public void UpdateList(IList<Producer> producers)
        {
            _producerDal.UpdateList(producers);
        }

        [SecuredOperation("producer.update,admin")]
        [ValidationAspect(typeof(ProducerValidator))]
        [CacheRemoveAspect("IProducerService.Get")]
        public async void UpdateList_Async(IList<Producer> producers)
        {
            await Task.Run(() => _producerDal.UpdateListAsync(producers));
        }

        [SecuredOperation("producer.delete,admin")]
        [ValidationAspect(typeof(ProducerValidator))]
        [CacheRemoveAspect("IProducerService.Get")]
        public void Delete(Producer producer)
        {
            _producerDal.Delete(producer);
        }

        [SecuredOperation("producer.delete,admin")]
        [ValidationAspect(typeof(ProducerValidator))]
        [CacheRemoveAspect("IProducerService.Get")]
        public async void Delete_Async(Producer producer)
        {
            await Task.Run(() => _producerDal.DeleteAsync(producer));
        }

        [SecuredOperation("producer.delete,admin")]
        [ValidationAspect(typeof(ProducerValidator))]
        [CacheRemoveAspect("IProducerService.Get")]
        public void DeleteList(IList<Producer> producers)
        {
            _producerDal.DeleteList(producers);
        }

        [SecuredOperation("producer.delete,admin")]
        [ValidationAspect(typeof(ProducerValidator))]
        [CacheRemoveAspect("IProducerService.Get")]
        public async void DeleteList_Async(IList<Producer> producers)
        {
            await Task.Run(() => _producerDal.DeleteListAsync(producers));
        }
    }
}