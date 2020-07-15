using DatabaseLayer.Enums;
using DataBaseLayer.Models.Plan;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLayer.Persistence.Configurations.Plans
{
    public class PlanServiceConfiguration : IEntityTypeConfiguration<ServicePlan>
    {
        public void Configure(EntityTypeBuilder<ServicePlan> builder)
        {
            builder.HasQueryFilter(x => x.State != State.Removed)
            .HasOne(x => x.ServiceOfPattient)
            .WithMany(x => x.ServiceOfPattients)
            .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
