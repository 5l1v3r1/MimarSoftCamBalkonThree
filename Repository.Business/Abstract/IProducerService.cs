using Core.Business;
using Repository.Entities.Concrete;
using System.Threading.Tasks;

namespace Repository.Business.Abstract
{
    public interface IProducerService : IServiceRepository<Producer>
    {
        Producer Get_ById(short id);

        Task<Producer> Get_ById_Async(short id);
    }
}