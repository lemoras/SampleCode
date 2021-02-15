using Member.Domain.Models;
using System.Threading.Tasks;

namespace Member.Domain.Repositories
{
    public interface IUserRoleRepository
    {
        Task<int> CreateUserRolehAsync(UserRole entity);
        Task<UserRole> GetUserRoleByUserIdAysnc(int userId);
    }
}
