using DatabaseLayer.Enums;
using DataBaseLayer.Models.Offices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLayer.Persistence.Configurations.DentalBranchs
{
    public class DentalBranchConfiguration : IEntityTypeConfiguration<DentalBranch>
    {
        public void Configure(EntityTypeBuilder<DentalBranch> builder)
        {
            builder.HasQueryFilter(x => x.State != State.Removed);
        }
    }
}
