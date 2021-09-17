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
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [CacheAspect]
        public Product Get_ById(int id)
        {
            return _productDal.Get(x => x.ProductId == id);
        }

        [CacheAspect]
        public Task<Product> Get_ById_Async(int id)
        {
            return _productDal.GetAsync(x => x.ProductId == id);
        }

        [CacheAspect]
        public IList<Product> GetList_All()
        {
            return _productDal.GetList();
        }

        [CacheAspect]
        public async Task<IList<Product>> GetList_All_Async()
        {
            return await _productDal.GetListAsync();
        }

        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public async void Add_Async(Product product)
        {
            await Task.Run(() => _productDal.AddAsync(product));
        }

        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public void AddList(IList<Product> products)
        {
            _productDal.AddList(products);
        }

        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public async void AddList_Async(IList<Product> products)
        {
            await Task.Run(() => _productDal.AddListAsync(products));
        }

        [SecuredOperation("product.update,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public void Update(Product product)
        {
            _productDal.Update(product);
        }

        [SecuredOperation("product.update,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public async void Update_Async(Product product)
        {
            await Task.Run(() => _productDal.UpdateAsync(product));
        }

        [SecuredOperation("product.update,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public void UpdateList(IList<Product> products)
        {
            _productDal.UpdateList(products);
        }

        [SecuredOperation("product.update,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public async void UpdateList_Async(IList<Product> products)
        {
            await Task.Run(() => _productDal.UpdateListAsync(products));
        }

        [SecuredOperation("product.delete,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public void Delete(Product product)
        {
            _productDal.Delete(product);
        }

        [SecuredOperation("product.delete,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public async void Delete_Async(Product product)
        {
            await Task.Run(() => _productDal.DeleteAsync(product));
        }

        [SecuredOperation("product.delete,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public void DeleteList(IList<Product> products)
        {
            _productDal.DeleteList(products);
        }

        [SecuredOperation("product.delete,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public async void DeleteList_Async(IList<Product> products)
        {
            await Task.Run(() => _productDal.DeleteListAsync(products));
        }
    }
}