using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Business
{
    public interface IServiceRepository<TEntity> where TEntity : class, IEntity, new()
    {
        IList<TEntity> GetList_All();

        Task<IList<TEntity>> GetList_All_Async();

        void Add(TEntity entity);

        void Add_Async(TEntity entity);

        void AddList(IList<TEntity> entities);

        void AddList_Async(IList<TEntity> entities);

        void Update(TEntity entity);

        void Update_Async(TEntity entity);

        void UpdateList(IList<TEntity> entities);

        void UpdateList_Async(IList<TEntity> entities);

        void Delete(TEntity entity);

        void Delete_Async(TEntity entity);

        void DeleteList(IList<TEntity> entities);

        void DeleteList_Async(IList<TEntity> entities);
    }
}