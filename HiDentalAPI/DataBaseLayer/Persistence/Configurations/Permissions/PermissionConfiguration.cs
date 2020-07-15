using DatabaseLayer.Enums;
using DataBaseLayer.Models;
using DataBaseLayer.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLayer.Persistence.Configurations.Permissions
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasMany(x => x.Users)
               .WithOne(x => x.Role)
               .HasForeignKey(nameof(UserPermission.RoleId))
               .HasPrincipalKey(x => x.Id);

            builder.HasQueryFilter(x => x.State != State.Removed);
        }
    }
}
