﻿using ExpensesTrackerApp.Core.Identity;
using ExpensesTrackerApp.DataAccess;
using ExpensesTrackerApp.DataAccess.Repositories;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExpensesTrackerApp.Core.Services.Identity
{
    public class RoleStore { }

    /*
    public class RoleStore : IRoleStore<Role>
    {
        private readonly IDataRepository _dataRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RoleStore(IDataRepository dataRepository, IUnitOfWork unitOfWork)
        {
            _dataRepository = dataRepository;
            _unitOfWork = unitOfWork;
        }
        public Task<IdentityResult> CreateAsync(Role role, CancellationToken cancellationToken)
        {
            _dataRepository.Insert(role);
            _unitOfWork.Commit();
            return Task.FromResult(IdentityResult.Success);
        }

        public Task CreateAsync(Role role)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> DeleteAsync(Role role, CancellationToken cancellationToken)
        {
            _dataRepository.Delete(role);
            _unitOfWork.Commit();
            return Task.FromResult(IdentityResult.Success);
        }

        public Task DeleteAsync(Role role)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }

        public Task<Role> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            Guid id = Guid.Empty;
            Guid.TryParse(roleId, out id);
            var role = _dataRepository.Query<Role>().SingleOrDefault(r => r.Id == id);
            return Task.FromResult(role);
        }

        public Task<Role> FindByIdAsync(string roleId)
        {
            throw new NotImplementedException();
        }

        public Task<Role> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            var role = _dataRepository.Query<Role>()
                .SingleOrDefault(r => r.Name == normalizedRoleName);
            return Task.FromResult(role);
        }

        public Task<Role> FindByNameAsync(string roleName)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetNormalizedRoleNameAsync(Role role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Name.ToLower());
        }

        public Task<string> GetRoleIdAsync(Role role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Id.ToString());
        }

        public Task<string> GetRoleNameAsync(Role role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Name);
        }

        public Task SetNormalizedRoleNameAsync(Role role, string normalizedName, CancellationToken cancellationToken)
        {
            role.Name = normalizedName;
            return Task.CompletedTask;
        }

        public Task SetRoleNameAsync(Role role, string roleName, CancellationToken cancellationToken)
        {
            role.Name = roleName;
            return Task.CompletedTask;
        }

        public Task<IdentityResult> UpdateAsync(Role role, CancellationToken cancellationToken)
        {
            var dbRole = _dataRepository.Query<Role>()
                .Single(r => r.Id == role.Id);
            dbRole.Name = role.Name;
            _dataRepository.Update(dbRole);
            _unitOfWork.Commit();
            return Task.FromResult(IdentityResult.Success);
        }

        public Task UpdateAsync(Role role)
        {
            throw new NotImplementedException();
        }
    }*/
}
