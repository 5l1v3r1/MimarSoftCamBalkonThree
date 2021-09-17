using Core.Utilities.Aspects.Autofac.Caching;
using Core.Utilities.Aspects.Autofac.Validation;
using Repository.Business.Abstract;
using Repository.Business.Rules.FluentValidation;
using Repository.Business.Utilities.Aspects;
using Repository.DataAccess.Abstract;
using Repository.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        [CacheAspect]
        public Order Get_ById(int id)
        {
            return _orderDal.Get(x => x.Id == id);
        }

        [CacheAspect]
        public Task<Order> Get_ById_Async(int id)
        {
            return _orderDal.GetAsync(x => x.Id == id);
        }

        [CacheAspect]
        public IList<Order> GetList_All()
        {
            return _orderDal.GetList();
        }

        [CacheAspect]
        public async Task<IList<Order>> GetList_All_Async()
        {
            return await _orderDal.GetListAsync();
        }

        [SecuredOperation("order.add,admin")]
        [ValidationAspect(typeof(OrderValidator))]
        [CacheRemoveAspect("IOrderService.Get")]
        public void Add(Order order)
        {
            _orderDal.Add(order);
        }

        [SecuredOperation("order.add,admin")]
        [ValidationAspect(typeof(OrderValidator))]
        [CacheRemoveAspect("IOrderService.Get")]
        public async void Add_Async(Order order)
        {
            await Task.Run(() => _orderDal.AddAsync(order));
        }

        [SecuredOperation("order.add,admin")]
        [ValidationAspect(typeof(OrderValidator))]
        [CacheRemoveAspect("IOrderService.Get")]
        public void AddList(IList<Order> orders)
        {
            _orderDal.AddList(orders);
        }

        [SecuredOperation("order.add,admin")]
        [ValidationAspect(typeof(OrderValidator))]
        [CacheRemoveAspect("IOrderService.Get")]
        public async void AddList_Async(IList<Order> orders)
        {
            await Task.Run(() => _orderDal.AddListAsync(orders));
        }

        [SecuredOperation("order.update,admin")]
        [ValidationAspect(typeof(OrderValidator))]
        [CacheRemoveAspect("IOrderService.Get")]
        public void Update(Order order)
        {
            _orderDal.Update(order);
        }

        [SecuredOperation("order.update,admin")]
        [ValidationAspect(typeof(OrderValidator))]
        [CacheRemoveAspect("IOrderService.Get")]
        public async void Update_Async(Order order)
        {
            await Task.Run(() => _orderDal.UpdateAsync(order));
        }

        [SecuredOperation("order.update,admin")]
        [ValidationAspect(typeof(OrderValidator))]
        [CacheRemoveAspect("IOrderService.Get")]
        public void UpdateList(IList<Order> orders)
        {
            _orderDal.UpdateList(orders);
        }

        [SecuredOperation("order.update,admin")]
        [ValidationAspect(typeof(OrderValidator))]
        [CacheRemoveAspect("IOrderService.Get")]
        public async void UpdateList_Async(IList<Order> orders)
        {
            await Task.Run(() => _orderDal.UpdateListAsync(orders));
        }

        [SecuredOperation("order.delete,admin")]
        [ValidationAspect(typeof(OrderValidator))]
        [CacheRemoveAspect("IOrderService.Get")]
        public void Delete(Order order)
        {
            _orderDal.Delete(order);
        }

        [SecuredOperation("order.delete,admin")]
        [ValidationAspect(typeof(OrderValidator))]
        [CacheRemoveAspect("IOrderService.Get")]
        public async void Delete_Async(Order order)
        {
            await Task.Run(() => _orderDal.DeleteAsync(order));
        }

        [SecuredOperation("order.delete,admin")]
        [ValidationAspect(typeof(OrderValidator))]
        [CacheRemoveAspect("IOrderService.Get")]
        public void DeleteList(IList<Order> orders)
        {
            _orderDal.DeleteList(orders);
        }

        [SecuredOperation("order.delete,admin")]
        [ValidationAspect(typeof(OrderValidator))]
        [CacheRemoveAspect("IOrderService.Get")]
        public async void DeleteList_Async(IList<Order> orders)
        {
            await Task.Run(() => _orderDal.DeleteListAsync(orders));
        }
    }
}