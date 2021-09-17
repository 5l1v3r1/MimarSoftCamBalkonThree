using Core.DataAccess.EFCore;
using Repository.DataAccess.Abstract;
using Repository.DataAccess.Concrete.EFCore.DbContexts;
using Repository.Entities.Concrete;

namespace Repository.DataAccess.Concrete.EFCore
{
    public class EfProductTypeDal : EfEntityRepositoryBase<ProductType, RepositoryContext>, IProductTypeDal
    {
    }
}