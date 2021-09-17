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
    public class ProductPartManager : IProductPartService
    {
        private readonly IProductPartDal _productPartDal;

        public ProductPartManager(IProductPartDal productPartDal)
        {
            _productPartDal = productPartDal;
        }

        [CacheAspect]
        public ProductPart Get_ById(int id)
        {
            return _productPartDal.Get(x => x.Id == id);
        }

        [CacheAspect]
        public Task<ProductPart> Get_ById_Async(int id)
        {
            return _productPartDal.GetAsync(x => x.Id == id);
        }

        [CacheAspect]
        public IList<ProductPart> GetList_All()
        {
            return _productPartDal.GetList();
        }

        [CacheAspect]
        public async Task<IList<ProductPart>> GetList_All_Async()
        {
            return await _productPartDal.GetListAsync();
        }

        [SecuredOperation("productPart.add,admin")]
        [ValidationAspect(typeof(ProductPartValidator))]
        [CacheRemoveAspect("IProductPartService.Get")]
        public void Add(ProductPart productPart)
        {
            _productPartDal.Add(productPart);
        }

        [SecuredOperation("productPart.add,admin")]
        [ValidationAspect(typeof(ProductPartValidator))]
        [CacheRemoveAspect("IProductPartService.Get")]
        public async void Add_Async(ProductPart productPart)
        {
            await Task.Run(() => _productPartDal.AddAsync(productPart));
        }

        [SecuredOperation("productPart.add,admin")]
        [ValidationAspect(typeof(ProductPartValidator))]
        [CacheRemoveAspect("IProductPartService.Get")]
        public void AddList(IList<ProductPart> productParts)
        {
            _productPartDal.AddList(productParts);
        }

        [SecuredOperation("productPart.add,admin")]
        [ValidationAspect(typeof(ProductPartValidator))]
        [CacheRemoveAspect("IProductPartService.Get")]
        public async void AddList_Async(IList<ProductPart> productParts)
        {
            await Task.Run(() => _productPartDal.AddListAsync(productParts));
        }

        [SecuredOperation("productPart.update,admin")]
        [ValidationAspect(typeof(ProductPartValidator))]
        [CacheRemoveAspect("IProductPartService.Get")]
        public void Update(ProductPart productPart)
        {
            _productPartDal.Update(productPart);
        }

        [SecuredOperation("productPart.update,admin")]
        [ValidationAspect(typeof(ProductPartValidator))]
        [CacheRemoveAspect("IProductPartService.Get")]
        public async void Update_Async(ProductPart productPart)
        {
            await Task.Run(() => _productPartDal.UpdateAsync(productPart));
        }

        [SecuredOperation("productPart.update,admin")]
        [ValidationAspect(typeof(ProductPartValidator))]
        [CacheRemoveAspect("IProductPartService.Get")]
        public void UpdateList(IList<ProductPart> productParts)
        {
            _productPartDal.UpdateList(productParts);
        }

        [SecuredOperation("productPart.update,admin")]
        [ValidationAspect(typeof(ProductPartValidator))]
        [CacheRemoveAspect("IProductPartService.Get")]
        public async void UpdateList_Async(IList<ProductPart> productParts)
        {
            await Task.Run(() => _productPartDal.UpdateListAsync(productParts));
        }

        [SecuredOperation("productPart.delete,admin")]
        [ValidationAspect(typeof(ProductPartValidator))]
        [CacheRemoveAspect("IProductPartService.Get")]
        public void Delete(ProductPart productPart)
        {
            _productPartDal.Delete(productPart);
        }

        [SecuredOperation("productPart.delete,admin")]
        [ValidationAspect(typeof(ProductPartValidator))]
        [CacheRemoveAspect("IProductPartService.Get")]
        public async void Delete_Async(ProductPart productPart)
        {
            await Task.Run(() => _productPartDal.DeleteAsync(productPart));
        }

        [SecuredOperation("productPart.delete,admin")]
        [ValidationAspect(typeof(ProductPartValidator))]
        [CacheRemoveAspect("IProductPartService.Get")]
        public void DeleteList(IList<ProductPart> productParts)
        {
            _productPartDal.DeleteList(productParts);
        }

        [SecuredOperation("productPart.delete,admin")]
        [ValidationAspect(typeof(ProductPartValidator))]
        [CacheRemoveAspect("IProductPartService.Get")]
        public async void DeleteList_Async(IList<ProductPart> productParts)
        {
            await Task.Run(() => _productPartDal.DeleteListAsync(productParts));
        }
    }
}