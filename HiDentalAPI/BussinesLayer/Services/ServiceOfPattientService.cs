using BussinesLayer.Contracts;
using BussinesLayer.Repository.Services;
using DatabaseLayer.Persistence;
using DataBaseLayer.Models.Appointment;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BussinesLayer.Services
{
    public class ServiceOfPattientService : BaseRepository<ServiceOfPattient>, IServiceOfPattientService
    {
        private readonly ApplicationDbContext _dbContext;
        public ServiceOfPattientService(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ServiceOfPattient>> GetListByDentalBrach(Guid id)
            => await GetAll().Include(x => x.DentalBranch).Where(x => x.DentalBranchId == id).ToListAsync();
    }
}
