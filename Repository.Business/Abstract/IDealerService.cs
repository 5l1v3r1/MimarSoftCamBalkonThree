using Core.Business;
using Repository.Entities.Concrete;
using System.Threading.Tasks;

namespace Repository.Business.Abstract
{
    public interface IDealerService : IServiceRepository<Dealer>
    {
        Dealer Get_ById(int id);

        Task<Dealer> Get_ById_Async(int id);
    }
}