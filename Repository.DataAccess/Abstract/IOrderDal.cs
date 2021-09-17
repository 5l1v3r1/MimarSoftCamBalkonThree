using Core.DataAccess;
using Repository.Entities.Concrete;

namespace Repository.DataAccess.Abstract
{
    public interface IOrderDal : IEntityRepository<Order>
    {
    }
}