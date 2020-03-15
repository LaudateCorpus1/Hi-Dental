using DatabaseLayer.Models.Users;
using DatabaseLayer.Persistence;
using DataBaseLayer.Enums;
using DataBaseLayer.Models;
using DataBaseLayer.Models.Users;
using DataBaseLayer.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
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
                var officesResult = SeedOfOffices(dbContext, appSetting);
                if (officesResult != null)
                {
                    var userTypeResult = SeedOfUserType(dbContext, appSetting);
                    if (userTypeResult != null)
                    {
                        var resultOfUser = SeedOfUsers(dbContext, userManager, appSetting, officesResult.Id);
                        if (resultOfUser != null) SeedOfUserDetail(dbContext, resultOfUser.Id, userTypeResult.Id);
                    }
                }
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
            foreach (var item in options.Value.DefaultPermissions) permissions.Add(new Permission { Name = item, NormalizedName = item.ToUpper() });

            dbContext.Roles.AddRange(permissions);
            return dbContext.SaveChanges() > 0 ? Result.Success : Result.Error;
        }

        /// <summary>
        /// Create the root user
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="userManager"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        private static User SeedOfUsers(ApplicationDbContext dbContext, UserManager<User> userManager, IOptions<AppSetting> options, Guid officeId)
        {
            if (dbContext.Users.Any()) return null;
            var user = new User
            {
                UserName = options.Value.User.UserName,
                Email = options.Value.User.UserName,
                Names = options.Value.User.Names,
                LastNames = options.Value.User.LastName,
                EmailConfirmed = true,
                PhoneNumber = options.Value.User.PhoneNumber,
                LockoutEnabled = false,
                CreatedBy = nameof(TypeOfCreation.ByApp),
                DentalBranchId = officeId
            };

            var result = userManager.CreateAsync(user, options.Value.User.Password);
            dbContext.Users.Add(user);
            if (dbContext.SaveChanges() <= 0) return null;

            var permissions = dbContext.Roles.FirstOrDefault(x => x.Name == options.Value.DefaultPermissions.FirstOrDefault());
            dbContext.UserRoles.Add(new UserPermission { RoleId = permissions.Id, UserId = user.Id });
            return dbContext.SaveChanges() > 0 ? user : null;
        }

        /// <summary>
        /// Create the root userType
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        private static UserType SeedOfUserType(ApplicationDbContext dbContext, IOptions<AppSetting> options)
        {
            if (dbContext.UserTypes.Any()) return null;
            var model = new UserType { Name = options.Value.DefautlUserType };
            dbContext.UserTypes.Add(model);
            return dbContext.SaveChanges() > 0 ? model : null;
        }


        private static bool SeedOfUserDetail(ApplicationDbContext dbContext, string userId, Guid userTypeId)
        {
            dbContext.UserDetails.Add(new UserDetail { UserId = userId, UserTypeId = userTypeId });
            return dbContext.SaveChanges() > 0;
        }

        private static DentalBranch SeedOfOffices(ApplicationDbContext dbContext, IOptions<AppSetting> options)
        {
            if (dbContext.PrincipalOffices.Any()) return null;
            var principalOffice = new PrincipalOffice { Title = options.Value.Office.Name };
            dbContext.PrincipalOffices.Add(principalOffice);
            var result = dbContext.SaveChanges() > 0;
            if (!result) return null;
            var dentalBranch = new DentalBranch { Title = options.Value.Office.Name, PrincipalOfficeId = principalOffice.Id };
            dbContext.DentalBranch.Add(dentalBranch);
            return dbContext.SaveChanges() > 0 ? dentalBranch : null;
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
