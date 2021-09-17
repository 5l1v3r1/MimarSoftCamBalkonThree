using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IViewRepository<T> where T : class, IView, new()
    {
        // GET
        T Get(Expression<Func<T, bool>> filter);

        Task<T> GetAsync(Expression<Func<T, bool>> filter);

        // GET LIST
        List<T> GetList(Expression<Func<T, bool>> filter = null);

        Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter = null);
    }
}