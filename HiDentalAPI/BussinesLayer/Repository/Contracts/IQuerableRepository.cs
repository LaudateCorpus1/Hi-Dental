using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BussinesLayer.Repository.Contracts
{
    public interface IQuerableRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetList();
        Task<TEntity> GetById(Guid id);
        IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> expression);
        Task<IEnumerable<TEntity>> FilterAsync(Expression<Func<TEntity, bool>> expression);

    }
}
