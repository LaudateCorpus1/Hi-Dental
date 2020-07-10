using DataBaseLayer.ViewModels.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Repository.Contracts
{
    /// <summary>
    /// Utilizado como helper para meter metodos comunes , cuando la entidad tiene como 
    /// primary key el tipo de dato de tipo primitivo
    /// </summary>
    /// <typeparam name="Indentifier"></typeparam>
    public interface IHelperService<Indentifier> where Indentifier : class
    {
        Task<bool> SoftDelete(Indentifier param);
    }

    /// <summary>
    /// Utilizado como helper para meter metodos comunes , cuando la entidad tiene como 
    /// primary key el tipo de dato de tipo struct
    /// </summary>
    /// <typeparam name="Indentifier"></typeparam>
    public interface IHelperServiceStructure<Indentifier> where Indentifier : struct
    {
        Task<bool> SoftDelete(Indentifier param);
    }

    /// <summary>
    /// Servicio para paginar de manera generica
    /// </summary>
    /// <typeparam name="TEntity">Entidad resultante</typeparam>
    /// <typeparam name="TFilterEntity">Parametros por los cuales se filtrara</typeparam>
    public interface IPaginationService<TEntity, TFilterEntity> where TEntity : class where TFilterEntity : class
    {
        Task<PaginationViewModel<TEntity>> GetAllWithPaginateAsync(TFilterEntity filterEntity);

    }
}
