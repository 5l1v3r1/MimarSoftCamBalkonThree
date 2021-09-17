using Core.Business;
using Repository.Entities.Concrete;
using System.Threading.Tasks;

namespace Repository.Business.Abstract
{
    public interface IProductPartService : IServiceRepository<ProductPart>
    {
        ProductPart Get_ById(int id);

        Task<ProductPart> Get_ById_Async(int id);
    }
}