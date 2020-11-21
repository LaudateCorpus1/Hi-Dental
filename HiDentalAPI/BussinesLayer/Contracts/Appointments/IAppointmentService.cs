using BussinesLayer.Repository.Contracts;
using DatabaseLayer.Models.Appointments;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Contracts.Appointments
{
    public interface IAppointmentService : IBaseRepository<Appointment>
    {
        Task<bool> SendNotification(Appointment model,string to);
    }
}
