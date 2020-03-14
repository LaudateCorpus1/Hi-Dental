using DataBaseLayer.ViewModels.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Repository.Contracts
{
    public interface IHelperService<Indentifier> where Indentifier : class
    {
        Task<bool> SoftDelete(Indentifier param);
    }

    public interface IHelperServiceStructure<Indentifier> where Indentifier : struct
    {
        Task<bool> SoftDelete(Indentifier param);
    }

    public interface IPaginationService<TEntity, TFilterEntity> where TEntity : class where TFilterEntity : class
    {
        Task<PaginationViewModel<TEntity>> GetAllWithPaginateAsync(TFilterEntity filterEntity);
    }
}
