using DatabaseLayer.Enums;
using DataBaseLayer.Models.Plan;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLayer.Persistence.Configurations.ServicesOfPatients
{
    public class ServiceOfPatientConfiguration : IEntityTypeConfiguration<ServiceOfPatient>
    {
        public void Configure(EntityTypeBuilder<ServiceOfPatient> builder)
        {
            builder.HasQueryFilter(x => x.State != State.Removed);
        }
    }
}
