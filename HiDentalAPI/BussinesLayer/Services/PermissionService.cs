using BussinesLayer.Contracts;
using BussinesLayer.Repository.Services;
using DatabaseLayer.Enums;
using DatabaseLayer.Persistence;
using DataBaseLayer.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BussinesLayer.Services
{
    public class PermissionService : BaseRepository<Permission>, IPermissionService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly RoleManager<Permission> _roleManager;

        public PermissionService(ApplicationDbContext dbContext, RoleManager<Permission> roleManager) : base(dbContext)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
        }

        public async Task<Permission> GetByIdentifier(string id) => await _roleManager.FindByIdAsync(id);


        public async Task<bool> SoftDelete(string param)
        {
            var model = await _dbContext.Roles.FirstOrDefaultAsync(x => x.Id == param);
            if (model == null) return false;
            model.State = State.Removed;
            _dbContext.Update(model);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> Create(Permission permission)
        {
            var result = await _roleManager.CreateAsync(permission);
            return result.Succeeded;
        }

        public async Task<bool> ExistByIdAsync(string id)
        {
            var result = await _roleManager.FindByIdAsync(id);
            return result != null;
        }

        public async Task<bool> ExistByNameAsync(string name) => await _roleManager.RoleExistsAsync(name);

        public async Task<bool> UpdateByProperties(Permission model)
        {
            var result = await GetByIdentifier(model.Id);
            if (result == null) return false;
            result.IsChecked = model.IsChecked;
            result.IsExpanded = model.IsExpanded;
            result.MenuName = model.MenuName;
            result.Name = model.Name;
            result.NormalizedName = model.Name.ToUpper();
            result.HasChild = model.HasChild;
            result.ParentId = model.ParentId;
            result.UpdateAt = model.UpdateAt;
            var op = await _roleManager.UpdateAsync(result);
            return op.Succeeded;
        }
    }
}
