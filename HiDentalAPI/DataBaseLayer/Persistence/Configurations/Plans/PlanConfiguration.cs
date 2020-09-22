using DatabaseLayer.Enums;
using DataBaseLayer.Models.Plan;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLayer.Persistence.Configurations.Plans
{
    public class PlanConfiguration : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder.HasQueryFilter(x => x.State != State.Removed);
        }
    }
}
