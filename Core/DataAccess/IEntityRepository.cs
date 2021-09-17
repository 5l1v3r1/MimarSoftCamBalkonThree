using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, new()
    {
        // ADD
        void Add(T entity);

        void AddAsync(T entity);

        // ADD LIST
        void AddList(IList<T> entities);

        void AddListAsync(IList<T> entities);

        // GET
        T Get(Expression<Func<T, bool>> filter);

        Task<T> GetAsync(Expression<Func<T, bool>> filter);

        // GET LIST
        IList<T> GetList(Expression<Func<T, bool>> filter = null);

        Task<IList<T>> GetListAsync(Expression<Func<T, bool>> filter = null);

        // UPDATE
        void Update(T entity);

        void UpdateAsync(T entity);

        // UPDATE LIST
        void UpdateList(IList<T> entities);

        void UpdateListAsync(IList<T> entities);

        // DELETE
        void Delete(T entity);

        void DeleteAsync(T entity);

        // DELETE LIST
        void DeleteList(IList<T> entities);

        void DeleteListAsync(IList<T> entities);
    }
}