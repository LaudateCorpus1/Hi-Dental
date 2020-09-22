using BussinesLayer.Contracts.Appointments;
using BussinesLayer.Repository.Services;
using DatabaseLayer.Models.Appointments;
using DatabaseLayer.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Services.Appointments
{
    public class AppointmentService : BaseRepository<Appointment>, IAppointmentService
    {
        private readonly ApplicationDbContext _context;
        public AppointmentService(ApplicationDbContext dbContext) : base(dbContext)
            => _context = dbContext;

        public override async Task<bool> Remove(Appointment entity)
        {
            var model = await GetById(entity.Id);
            if (model == null) return false;
            model.State = DatabaseLayer.Enums.State.Removed;
            return await Update(model);
        }
    }
}
