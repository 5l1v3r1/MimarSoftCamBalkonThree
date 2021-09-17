using Core.Business;
using Repository.Entities.Concrete;
using System.Threading.Tasks;

namespace Repository.Business.Abstract
{
    public interface IProducerPersonelService : IServiceRepository<ProducerPersonel>
    {
        ProducerPersonel Get_ById(string id);

        Task<ProducerPersonel> Get_ById_Async(string id);
    }
}