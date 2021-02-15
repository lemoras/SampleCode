using Company.Domain.Models;
using Company.Domain.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Company.Domain.Repositories
{
    public interface IStaffRepository
    {
        Task<int> CreateStaffAsync(CreateStaffRequest request);
        Task<int> UpdateStaffAsync(UpdateStaffRequest request);
        Task<IEnumerable<Staff>> GetStaffByBranchIdAsync(int branchId);
    }
}
