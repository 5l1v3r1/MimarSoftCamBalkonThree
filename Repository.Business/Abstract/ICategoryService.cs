using Core.Business;
using Repository.Entities.Concrete;
using System.Threading.Tasks;

namespace Repository.Business.Abstract
{
    public interface ICategoryService : IServiceRepository<Category>
    {
        Category Get_ById(short id);

        Task<Category> Get_ById_Async(short id);
    }
}