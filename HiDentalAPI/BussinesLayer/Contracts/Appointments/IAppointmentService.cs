using BussinesLayer.Repository.Contracts;
using DatabaseLayer.Models.Appointments;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLayer.Contracts.Appointments
{
    public interface IAppointmentService : IBaseRepository<Appointment>
    {
    }
}
