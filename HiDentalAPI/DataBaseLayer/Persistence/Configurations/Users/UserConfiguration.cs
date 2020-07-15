using DatabaseLayer.Enums;
using DatabaseLayer.Models.Users;
using DataBaseLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLayer.Persistence.Configurations.Users
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(x => x.UserRoles)
               .WithOne(x => x.User)
               .HasForeignKey(nameof(UserPermission.UserId))
               .HasPrincipalKey(x => x.Id);

            builder.HasMany(x => x.UserRoles)
               .WithOne(x => x.User)
               .HasForeignKey(nameof(UserPermission.UserId))
               .HasPrincipalKey(x => x.Id);

            builder.HasQueryFilter(x => x.State != State.Removed);

        }
    }


    public class UserPermissionConfiguration : IEntityTypeConfiguration<UserPermission>
    {

        public void Configure(EntityTypeBuilder<UserPermission> builder)
        {
            builder.HasKey(x => new { x.RoleId, x.UserId });
        }
    }
}
