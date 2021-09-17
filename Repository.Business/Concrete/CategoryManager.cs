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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        [CacheAspect]
        public Category Get_ById(short id)
        {
            return _categoryDal.Get(x => x.Id == id);
        }

        [CacheAspect]
        public Task<Category> Get_ById_Async(short id)
        {
            return _categoryDal.GetAsync(x => x.Id == id);
        }

        [CacheAspect]
        public IList<Category> GetList_All()
        {
            return _categoryDal.GetList();
        }

        [CacheAspect]
        public async Task<IList<Category>> GetList_All_Async()
        {
            return await _categoryDal.GetListAsync();
        }

        [SecuredOperation("category.add,admin")]
        [ValidationAspect(typeof(CategoryValidator))]
        [CacheRemoveAspect("ICategoryService.Get")]
        public void Add(Category category)
        {
            _categoryDal.Add(category);
        }

        [SecuredOperation("category.add,admin")]
        [ValidationAspect(typeof(CategoryValidator))]
        [CacheRemoveAspect("ICategoryService.Get")]
        public async void Add_Async(Category category)
        {
            await Task.Run(() => _categoryDal.AddAsync(category));
        }

        [SecuredOperation("category.add,admin")]
        [ValidationAspect(typeof(CategoryValidator))]
        [CacheRemoveAspect("ICategoryService.Get")]
        public void AddList(IList<Category> categories)
        {
            _categoryDal.AddList(categories);
        }

        [SecuredOperation("category.add,admin")]
        [ValidationAspect(typeof(CategoryValidator))]
        [CacheRemoveAspect("ICategoryService.Get")]
        public async void AddList_Async(IList<Category> categories)
        {
            await Task.Run(() => _categoryDal.AddListAsync(categories));
        }

        [SecuredOperation("category.update,admin")]
        [ValidationAspect(typeof(CategoryValidator))]
        [CacheRemoveAspect("ICategoryService.Get")]
        public void Update(Category category)
        {
            _categoryDal.Update(category);
        }

        [SecuredOperation("category.update,admin")]
        [ValidationAspect(typeof(CategoryValidator))]
        [CacheRemoveAspect("ICategoryService.Get")]
        public async void Update_Async(Category category)
        {
            await Task.Run(() => _categoryDal.UpdateAsync(category));
        }

        [SecuredOperation("category.update,admin")]
        [ValidationAspect(typeof(CategoryValidator))]
        [CacheRemoveAspect("ICategoryService.Get")]
        public void UpdateList(IList<Category> categories)
        {
            _categoryDal.UpdateList(categories);
        }

        [SecuredOperation("category.update,admin")]
        [ValidationAspect(typeof(CategoryValidator))]
        [CacheRemoveAspect("ICategoryService.Get")]
        public async void UpdateList_Async(IList<Category> categories)
        {
            await Task.Run(() => _categoryDal.UpdateListAsync(categories));
        }

        [SecuredOperation("category.delete,admin")]
        [ValidationAspect(typeof(CategoryValidator))]
        [CacheRemoveAspect("ICategoryService.Get")]
        public void Delete(Category category)
        {
            _categoryDal.Delete(category);
        }

        [SecuredOperation("category.delete,admin")]
        [ValidationAspect(typeof(CategoryValidator))]
        [CacheRemoveAspect("ICategoryService.Get")]
        public async void Delete_Async(Category category)
        {
            await Task.Run(() => _categoryDal.DeleteAsync(category));
        }

        [SecuredOperation("category.delete,admin")]
        [ValidationAspect(typeof(CategoryValidator))]
        [CacheRemoveAspect("ICategoryService.Get")]
        public void DeleteList(IList<Category> categories)
        {
            _categoryDal.DeleteList(categories);
        }

        [SecuredOperation("category.delete,admin")]
        [ValidationAspect(typeof(CategoryValidator))]
        [CacheRemoveAspect("ICategoryService.Get")]
        public async void DeleteList_Async(IList<Category> categories)
        {
            await Task.Run(() => _categoryDal.DeleteListAsync(categories));
        }
    }
}