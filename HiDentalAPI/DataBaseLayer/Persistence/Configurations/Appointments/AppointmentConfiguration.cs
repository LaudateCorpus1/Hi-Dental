using DatabaseLayer.Enums;
using DatabaseLayer.Models.Appointments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLayer.Persistence.Configurations.Appointments
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasQueryFilter(x => x.State != State.Removed)
                .HasOne(x => x.Patient)
                .WithMany(x => x.Appointment)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
