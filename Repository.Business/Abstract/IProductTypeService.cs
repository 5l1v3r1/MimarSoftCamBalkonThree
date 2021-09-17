using Core.Business;
using Repository.Entities.Concrete;
using System.Threading.Tasks;

namespace Repository.Business.Abstract
{
    public interface IProductTypeService : IServiceRepository<ProductType>
    {
        ProductType Get_ById(short id);

        Task<ProductType> Get_ById_Async(short id);
    }
}