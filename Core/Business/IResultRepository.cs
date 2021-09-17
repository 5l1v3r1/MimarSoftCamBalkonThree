using Core.Entities;
using Core.Utilities.Results;
using System.Collections.Generic;

namespace Core.Business
{
    public interface IResultRepository<TEntity> where TEntity : class, IEntity, new()
    {
        IResult Add(TEntity entity);

        IResult Add_Async(TEntity entity);

        IResult AddList(IList<TEntity> entities);

        IResult AddList_Async(IList<TEntity> entities);

        IResult Update(TEntity entity);

        IResult Update_Async(TEntity entity);

        IResult UpdateList(IList<TEntity> entities);

        IResult UpdateList_Async(IList<TEntity> entities);

        IResult Delete(TEntity entity);

        IResult Delete_Async(TEntity entity);

        IResult DeleteList(IList<TEntity> entities);

        IResult DeleteList_Async(IList<TEntity> entities);
    }
}