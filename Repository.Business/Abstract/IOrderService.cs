using Core.Business;
using Repository.Entities.Concrete;
using System.Threading.Tasks;

namespace Repository.Business.Abstract
{
    public interface IOrderService : IServiceRepository<Order>
    {
        Order Get_ById(int id);

        Task<Order> Get_ById_Async(int id);
    }
}