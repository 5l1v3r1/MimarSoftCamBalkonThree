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
    public class DealerManager : IDealerService
    {
        private readonly IDealerDal _dealerDal;

        public DealerManager(IDealerDal dealerDal)
        {
            _dealerDal = dealerDal;
        }

        [CacheAspect]
        public Dealer Get_ById(int id)
        {
            return _dealerDal.Get(x => x.Id == id);
        }

        [CacheAspect]
        public Task<Dealer> Get_ById_Async(int id)
        {
            return _dealerDal.GetAsync(x => x.Id == id);
        }

        [CacheAspect]
        public IList<Dealer> GetList_All()
        {
            return _dealerDal.GetList();
        }

        [CacheAspect]
        public async Task<IList<Dealer>> GetList_All_Async()
        {
            return await _dealerDal.GetListAsync();
        }

        [SecuredOperation("dealer.add,admin")]
        [ValidationAspect(typeof(DealerValidator))]
        [CacheRemoveAspect("IDealerService.Get")]
        public void Add(Dealer dealer)
        {
            _dealerDal.Add(dealer);
        }

        [SecuredOperation("dealer.add,admin")]
        [ValidationAspect(typeof(DealerValidator))]
        [CacheRemoveAspect("IDealerService.Get")]
        public async void Add_Async(Dealer dealer)
        {
            await Task.Run(() => _dealerDal.AddAsync(dealer));
        }

        [SecuredOperation("dealer.add,admin")]
        [ValidationAspect(typeof(DealerValidator))]
        [CacheRemoveAspect("IDealerService.Get")]
        public void AddList(IList<Dealer> dealers)
        {
            _dealerDal.AddList(dealers);
        }

        [SecuredOperation("dealer.add,admin")]
        [ValidationAspect(typeof(DealerValidator))]
        [CacheRemoveAspect("IDealerService.Get")]
        public async void AddList_Async(IList<Dealer> dealers)
        {
            await Task.Run(() => _dealerDal.AddListAsync(dealers));
        }

        [SecuredOperation("dealer.update,admin")]
        [ValidationAspect(typeof(DealerValidator))]
        [CacheRemoveAspect("IDealerService.Get")]
        public void Update(Dealer dealer)
        {
            _dealerDal.Update(dealer);
        }

        [SecuredOperation("dealer.update,admin")]
        [ValidationAspect(typeof(DealerValidator))]
        [CacheRemoveAspect("IDealerService.Get")]
        public async void Update_Async(Dealer dealer)
        {
            await Task.Run(() => _dealerDal.UpdateAsync(dealer));
        }

        [SecuredOperation("dealer.update,admin")]
        [ValidationAspect(typeof(DealerValidator))]
        [CacheRemoveAspect("IDealerService.Get")]
        public void UpdateList(IList<Dealer> dealers)
        {
            _dealerDal.UpdateList(dealers);
        }

        [SecuredOperation("dealer.update,admin")]
        [ValidationAspect(typeof(DealerValidator))]
        [CacheRemoveAspect("IDealerService.Get")]
        public async void UpdateList_Async(IList<Dealer> dealers)
        {
            await Task.Run(() => _dealerDal.UpdateListAsync(dealers));
        }

        [SecuredOperation("dealer.delete,admin")]
        [ValidationAspect(typeof(DealerValidator))]
        [CacheRemoveAspect("IDealerService.Get")]
        public void Delete(Dealer dealer)
        {
            _dealerDal.Delete(dealer);
        }

        [SecuredOperation("dealer.delete,admin")]
        [ValidationAspect(typeof(DealerValidator))]
        [CacheRemoveAspect("IDealerService.Get")]
        public async void Delete_Async(Dealer dealer)
        {
            await Task.Run(() => _dealerDal.DeleteAsync(dealer));
        }

        [SecuredOperation("dealer.delete,admin")]
        [ValidationAspect(typeof(DealerValidator))]
        [CacheRemoveAspect("IDealerService.Get")]
        public void DeleteList(IList<Dealer> dealers)
        {
            _dealerDal.DeleteList(dealers);
        }

        [SecuredOperation("dealer.delete,admin")]
        [ValidationAspect(typeof(DealerValidator))]
        [CacheRemoveAspect("IDealerService.Get")]
        public async void DeleteList_Async(IList<Dealer> dealers)
        {
            await Task.Run(() => _dealerDal.DeleteListAsync(dealers));
        }
    }
}