using DatabaseLayer.Enums;
using DatabaseLayer.Models.Patients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLayer.Persistence.Configurations.Patients
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasQueryFilter(x => x.State != State.Removed);
            //builder.Property(x => x.Id).HasDefaultValueSql("NEWID()");
        }
    }
}
