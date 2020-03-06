using BussinesLayer.Contracts;
using BussinesLayer.Repository.Services;
using DatabaseLayer.Models;
using DatabaseLayer.Persistence;

namespace BussinesLayer.Services
{
    public class PatientService : BaseRepository<Patient>,IPatientService
    {
        private readonly ApplicationDbContext _dbContext;
        public PatientService(ApplicationDbContext dbContext) : base(dbContext) => _dbContext = dbContext;
       
    }
}
