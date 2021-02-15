using Company.Domain.Request;
using Company.Domain.Response;
using System.Threading.Tasks;

namespace Company.Domain.Service.Define
{
    public interface IStaffService
    {
        Task<object> CreateStaffAsync(CreateStaffRequest request);
        Task<object> UpdateStaffAsync(UpdateStaffRequest request);
        Task<object> GetStaffByBranchIdAsync(int branchId);
    }
}
