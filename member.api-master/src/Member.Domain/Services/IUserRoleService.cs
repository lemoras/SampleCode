using Member.Domain.Models;
using Member.Domain.Request;
using System.Threading.Tasks;

namespace Member.Domain.Services
{
    public interface IUserRoleService
    {
        Task<int> CreateUserRolehAsync(CreateUserRoleRequest request);
        Task<UserRole> GetUserRoleByUserIdAysnc(int userId);
        Task<int> GetUserRoleAysnc();
    }
}
