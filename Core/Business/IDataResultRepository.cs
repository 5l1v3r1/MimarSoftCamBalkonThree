using Core.Utilities.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Business
{
    public interface IDataResultRepository<TEntity> where TEntity : class, /*IEntity,*/ new()
    {
        IDataResult<IList<TEntity>> GetList_All();

        IDataResult<Task<IList<TEntity>>> GetList_All_Async();
    }
}