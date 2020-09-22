using DatabaseLayer.Models;
using DatabaseLayer.Models.Appointments;
using DatabaseLayer.Models.Patients;
using DatabaseLayer.Models.Users;
using DataBaseLayer.Models;
using DataBaseLayer.Models.Offices;
using DataBaseLayer.Models.Plan;
using DataBaseLayer.Models.Users;
using DataBaseLayer.Persistence.Configurations.Appointments;
using DataBaseLayer.Persistence.Configurations.Consultations;
using DataBaseLayer.Persistence.Configurations.DentalBranchs;
using DataBaseLayer.Persistence.Configurations.Patients;
using DataBaseLayer.Persistence.Configurations.Permissions;
using DataBaseLayer.Persistence.Configurations.Plans;
using DataBaseLayer.Persistence.Configurations.ServicesOfPatients;
using DataBaseLayer.Persistence.Configurations.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLayer.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<User
        , Permission, string, IdentityUserClaim<string>, UserPermission
        , IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserPermissionConfiguration());
            builder.ApplyConfiguration(new PermissionConfiguration());
            builder.ApplyConfiguration(new PatientConfiguration());
            builder.ApplyConfiguration(new AppointmentConfiguration());
            builder.ApplyConfiguration(new ConsultationConfiguration());
            builder.ApplyConfiguration(new UserTypeConfiguration());
            builder.ApplyConfiguration(new DentalBranchConfiguration());
            builder.ApplyConfiguration(new ServiceOfPatientConfiguration());
            builder.ApplyConfiguration(new PlanConfiguration());
            builder.ApplyConfiguration(new PlanServiceConfiguration());
            builder.ApplyConfiguration(new PaymentConfiguration());
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<DentalBranch> DentalBranch { get; set; }
        public DbSet<ServiceOfPatient> ServiceOfPattients { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<ServicePlan> PlanService { get; set; }
        public DbSet<Payment> Payments { get; set; }

        ///todo :  plan , planservice => 
    }
}
