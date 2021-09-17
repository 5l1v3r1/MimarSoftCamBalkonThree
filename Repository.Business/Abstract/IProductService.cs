using Core.Business;
using Repository.Entities.Concrete;
using System.Threading.Tasks;

namespace Repository.Business.Abstract
{
    public interface IProductService : IServiceRepository<Product>
    {
        Product Get_ById(int id);

        Task<Product> Get_ById_Async(int id);
    }
}