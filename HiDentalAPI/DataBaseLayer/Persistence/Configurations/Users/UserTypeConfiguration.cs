using DatabaseLayer.Enums;
using DataBaseLayer.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLayer.Persistence.Configurations.Users
{
    public class UserTypeConfiguration : IEntityTypeConfiguration<UserType>
    {
        public void Configure(EntityTypeBuilder<UserType> builder)
        {
            builder.HasQueryFilter(x => x.State != State.Removed);
        }
    }
}
