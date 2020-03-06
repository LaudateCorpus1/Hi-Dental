using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BussinesLayer.Repository.Contracts
{
    public interface IQuerableRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetById(Guid id);
        IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> expression);
    }
}
