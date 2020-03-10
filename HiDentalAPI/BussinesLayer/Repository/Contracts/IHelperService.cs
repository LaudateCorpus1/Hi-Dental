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
}
