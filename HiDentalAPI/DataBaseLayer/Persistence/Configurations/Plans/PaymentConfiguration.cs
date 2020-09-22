using DatabaseLayer.Enums;
using DataBaseLayer.Models.Plan;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLayer.Persistence.Configurations.Plans
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasQueryFilter(x => x.State != State.Removed);
        }
    }
}
