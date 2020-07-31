using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLayer.ViewModels.Pagination
{
    public class PaginationViewModel<TEntity> where TEntity : class
    {
        public int Total { get; set; }
        public int Pages { get; set; }
        public int ActualPage { get; set; }
        public IEnumerable<TEntity> Entities { get; set; }
    }
}
