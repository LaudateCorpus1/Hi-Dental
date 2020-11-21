using BussinesLayer.Contracts.Appointments;
using BussinesLayer.Repository.Services;
using Common.ExtensionsMethods;
using DatabaseLayer.Models.Appointments;
using DatabaseLayer.Persistence;
using DataBaseLayer.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Services.Appointments
{
    public class AppointmentService : BaseRepository<Appointment>, IAppointmentService
    {
        private readonly ApplicationDbContext _context;
        private readonly MailSetting _options;
        public AppointmentService(ApplicationDbContext dbContext, IOptions<MailSetting> options) : base(dbContext)
        {
            _context = dbContext;
            _options = options.Value;
        }

        public override async Task<bool> Remove(Appointment entity)
        {
            var model = await GetById(entity.Id);
            if (model == null) return false;
            model.State = DatabaseLayer.Enums.State.Removed;
            return await Update(model);
        }

        public override async Task<IEnumerable<Appointment>> GetList(Expression<Func<Appointment, bool>> expression = null)
            => await base.GetAll().Include(x => x.Patient).Include(x => x.Doctor).Where(expression).ToListAsync();



        public override async Task<bool> Add(Appointment entity)
        {
            var result = await base.Add(entity);
            if (result)
            {
                var dentalBranch = await _context.DentalBranch.FirstOrDefaultAsync(x => x.Id == entity.DentalBranchId);
                if (dentalBranch != null)
                {
                    var appointment = new Appointment
                    {
                        StartDate = entity.StartDate,
                        DentalBranch = dentalBranch
                    };
                    var to = await _context.Patients.Select(x => new { x.Id, x.Email }).FirstOrDefaultAsync(x => x.Id == entity.PatientId);
                    if (!string.IsNullOrEmpty(to.Email)) await SendNotification(appointment, to.Email);
                }

            }
            return result;
        }


        public async Task<bool> SendNotification(Appointment model, string to)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(_options.SmtpClient);

                mail.From = new MailAddress(_options.UserName);
                mail.To.Add(to);
                mail.Subject = "Tiene una Nueva cita";
                mail.Body = $"Hola, tienes una nueva cita de {model.DentalBranch.Title} en horario de {model.StartDate:f}";

                SmtpServer.Port = _options.Port;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential(_options.UserName, _options.Password);
                SmtpServer.EnableSsl = _options.EnableSsl;

                await SmtpServer.SendMailAsync(mail);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
