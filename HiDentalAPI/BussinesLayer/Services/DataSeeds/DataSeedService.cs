using DatabaseLayer.Models.Users;
using DatabaseLayer.Persistence;
using DataBaseLayer.Models;
using DataBaseLayer.Models.Users;
using DataBaseLayer.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;

namespace BussinesLayer.Services.DataSeeds
{
    public static class DataSeedService
    {
        /// <summary>
        /// Generate SeedData for the app work 😎
        /// </summary>
        /// <param name="builder">App builder</param>
        public static void SeedsOfApp(IApplicationBuilder builder)
        {
            using var appScoped = builder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var dbContext = appScoped.ServiceProvider.GetService<ApplicationDbContext>();
            var userManager = appScoped.ServiceProvider.GetService<UserManager<User>>();
            var appSetting = appScoped.ServiceProvider.GetService<IOptions<AppSetting>>();
            var result = SeedOfUserPermitions(dbContext, appSetting);
            if (result == Result.Success || result == Result.HasAny)
            {
                SeedOfUsers(dbContext, userManager, appSetting);
            }
        }

        /// <summary>
        /// Create The User Permissions
        /// </summary>
        /// <param name="dbContext"></param>
        /// <returns></returns>
        private static Result SeedOfUserPermitions(ApplicationDbContext dbContext, IOptions<AppSetting> options)
        {
            if (dbContext.Roles.Any()) return Result.HasAny;

            var permissions = new List<Permission>();
            foreach (var item in options.Value.DefaultPermissions) permissions.Add(new Permission { Name = item, NormalizedName = item });

            dbContext.Roles.AddRange(permissions);
            return dbContext.SaveChanges() > 0 ? Result.Success : Result.Error;
        }

        /// <summary>
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="userManager"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        private static Result SeedOfUsers(ApplicationDbContext dbContext, UserManager<User> userManager, IOptions<AppSetting> options)
        {
            if (dbContext.Users.Any()) return Result.HasAny;
            var user = new User
            {
                UserName = options.Value.User.UserName,
                Email = options.Value.User.UserName,
                Names = options.Value.User.Names,
                LastNames = options.Value.User.LastName,
                EmailConfirmed = true,
                PhoneNumber = options.Value.User.PhoneNumber,
                LockoutEnabled = false
            };
            var result = userManager.CreateAsync(user, options.Value.User.Password);
            dbContext.Users.Add(user);
            if (dbContext.SaveChanges() > 0)
            {
                var permissions = dbContext.Roles.FirstOrDefault(x => x.Name == options.Value.DefaultPermissions.FirstOrDefault());
                dbContext.UserRoles.Add(new UserPermission { RoleId = permissions.Id, UserId = user.Id });
                return dbContext.SaveChanges() > 0 ? Result.Success : Result.Error;
            }
            return Result.Error;
        }
    }

    /// <summary>
    /// Results of DataSeedMethods
    /// </summary>
    public enum Result
    {
        Error,
        HasAny,
        Success
    }
}
