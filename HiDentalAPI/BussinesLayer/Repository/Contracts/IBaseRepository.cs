using System;
using System.Threading.Tasks;

namespace BussinesLayer.Repository.Contracts
{
    public interface IBaseRepository<TEntity> : IQuerableRepository<TEntity>  where TEntity : class 
    {
        Task<bool> Add(TEntity entity);
        Task<bool> Update(TEntity entity);
        Task<bool> Remove(TEntity entity);
    }
}
