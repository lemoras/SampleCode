using Member.Domain.Models;
using Member.Domain.Repositories;
using Member.Domain.Request;
using System;
using System.Threading.Tasks;

namespace Member.Domain.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IApplicationContext _applicationContext;

        public UserRoleService(IApplicationContext applicationContext, IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
            _applicationContext = applicationContext;
        }

        public async Task<int> CreateUserRolehAsync(CreateUserRoleRequest request)
        {
             var entity = new UserRole {
                 UserId = request.UserId,
                 RoleId = request.RoleId,
                 Active = request.Active,
                 CreatedBy = _applicationContext.UserId,
                 CreatedDate = DateTime.UtcNow
             };

            return await _userRoleRepository.CreateUserRolehAsync(entity);;
        }

        public async Task<UserRole> GetUserRoleByUserIdAysnc(int userId)
        {
            return await _userRoleRepository.GetUserRoleByUserIdAysnc(userId);
        }

        public async Task<int> GetUserRoleAysnc()
        {
            var userId = _applicationContext.UserId;
            var result = await _userRoleRepository.GetUserRoleByUserIdAysnc(userId);

            return result.RoleId;
        }
    }
}
