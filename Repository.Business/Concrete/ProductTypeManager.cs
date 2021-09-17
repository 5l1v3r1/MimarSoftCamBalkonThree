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
    public class ProductTypeManager : IProductTypeService
    {
        private readonly IProductTypeDal _productTypeDal;

        public ProductTypeManager(IProductTypeDal productTypeDal)
        {
            _productTypeDal = productTypeDal;
        }

        [CacheAspect]
        public ProductType Get_ById(short id)
        {
            return _productTypeDal.Get(x => x.Id == id);
        }

        [CacheAspect]
        public Task<ProductType> Get_ById_Async(short id)
        {
            return _productTypeDal.GetAsync(x => x.Id == id);
        }

        [CacheAspect]
        public IList<ProductType> GetList_All()
        {
            return _productTypeDal.GetList();
        }

        [CacheAspect]
        public async Task<IList<ProductType>> GetList_All_Async()
        {
            return await _productTypeDal.GetListAsync();
        }

        [SecuredOperation("productType.add,admin")]
        [ValidationAspect(typeof(ProductTypeValidator))]
        [CacheRemoveAspect("IProductTypeService.Get")]
        public void Add(ProductType productType)
        {
            _productTypeDal.Add(productType);
        }

        [SecuredOperation("productType.add,admin")]
        [ValidationAspect(typeof(ProductTypeValidator))]
        [CacheRemoveAspect("IProductTypeService.Get")]
        public async void Add_Async(ProductType productType)
        {
            await Task.Run(() => _productTypeDal.AddAsync(productType));
        }

        [SecuredOperation("productType.add,admin")]
        [ValidationAspect(typeof(ProductTypeValidator))]
        [CacheRemoveAspect("IProductTypeService.Get")]
        public void AddList(IList<ProductType> productTypes)
        {
            _productTypeDal.AddList(productTypes);
        }

        [SecuredOperation("productType.add,admin")]
        [ValidationAspect(typeof(ProductTypeValidator))]
        [CacheRemoveAspect("IProductTypeService.Get")]
        public async void AddList_Async(IList<ProductType> productTypes)
        {
            await Task.Run(() => _productTypeDal.AddListAsync(productTypes));
        }

        [SecuredOperation("productType.update,admin")]
        [ValidationAspect(typeof(ProductTypeValidator))]
        [CacheRemoveAspect("IProductTypeService.Get")]
        public void Update(ProductType productType)
        {
            _productTypeDal.Update(productType);
        }

        [SecuredOperation("productType.update,admin")]
        [ValidationAspect(typeof(ProductTypeValidator))]
        [CacheRemoveAspect("IProductTypeService.Get")]
        public async void Update_Async(ProductType productType)
        {
            await Task.Run(() => _productTypeDal.UpdateAsync(productType));
        }

        [SecuredOperation("productType.update,admin")]
        [ValidationAspect(typeof(ProductTypeValidator))]
        [CacheRemoveAspect("IProductTypeService.Get")]
        public void UpdateList(IList<ProductType> productTypes)
        {
            _productTypeDal.UpdateList(productTypes);
        }

        [SecuredOperation("productType.update,admin")]
        [ValidationAspect(typeof(ProductTypeValidator))]
        [CacheRemoveAspect("IProductTypeService.Get")]
        public async void UpdateList_Async(IList<ProductType> productTypes)
        {
            await Task.Run(() => _productTypeDal.UpdateListAsync(productTypes));
        }

        [SecuredOperation("productType.delete,admin")]
        [ValidationAspect(typeof(ProductTypeValidator))]
        [CacheRemoveAspect("IProductTypeService.Get")]
        public void Delete(ProductType productType)
        {
            _productTypeDal.Delete(productType);
        }

        [SecuredOperation("productType.delete,admin")]
        [ValidationAspect(typeof(ProductTypeValidator))]
        [CacheRemoveAspect("IProductTypeService.Get")]
        public async void Delete_Async(ProductType productType)
        {
            await Task.Run(() => _productTypeDal.DeleteAsync(productType));
        }

        [SecuredOperation("productType.delete,admin")]
        [ValidationAspect(typeof(ProductTypeValidator))]
        [CacheRemoveAspect("IProductTypeService.Get")]
        public void DeleteList(IList<ProductType> productTypes)
        {
            _productTypeDal.DeleteList(productTypes);
        }

        [SecuredOperation("productType.delete,admin")]
        [ValidationAspect(typeof(ProductTypeValidator))]
        [CacheRemoveAspect("IProductTypeService.Get")]
        public async void DeleteList_Async(IList<ProductType> productTypes)
        {
            await Task.Run(() => _productTypeDal.DeleteListAsync(productTypes));
        }
    }
}