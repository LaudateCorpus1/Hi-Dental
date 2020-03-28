using DatabaseLayer.Models;
using DatabaseLayer.Models.Patients;
using DatabaseLayer.Models.Users;
using DataBaseLayer.Models;
using DataBaseLayer.Models.Appointment;
using DataBaseLayer.Models.Offices;
using DataBaseLayer.Models.Users;
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
            builder.Entity<User>().HasMany(x => x.UserRoles)
                .WithOne(x => x.User)
                .HasForeignKey(nameof(UserPermission.UserId))
                .HasPrincipalKey(x => x.Id);
            builder.Entity<Permission>().HasMany(x => x.Users)
                .WithOne(x => x.Role)
                .HasForeignKey(nameof(UserPermission.RoleId))
                .HasPrincipalKey(x => x.Id);
            builder.Entity<UserPermission>().HasKey(x => new { x.RoleId, x.UserId });

            #region Filters
            builder.Entity<User>().HasQueryFilter(x => x.State != Enums.State.Removed);
            builder.Entity<Patient>().HasQueryFilter(x => x.State != Enums.State.Removed);
            builder.Entity<Appointment>().HasQueryFilter(x => x.State != Enums.State.Removed);
            builder.Entity<Consultation>().HasQueryFilter(x => x.State != Enums.State.Removed);
            builder.Entity<UserType>().HasQueryFilter(x => x.State != Enums.State.Removed);
            builder.Entity<DentalBranch>().HasQueryFilter(x => x.State != Enums.State.Removed);
            builder.Entity<ServiceOfPattient>().HasQueryFilter(x => x.State != Enums.State.Removed);
            #endregion

        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<DentalBranch> DentalBranch { get; set; }
        public DbSet<PrincipalOffice> PrincipalOffices { get; set; }
        public DbSet<ServiceOfPattient> ServiceOfPattients { get; set; }

    }
}
