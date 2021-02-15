using Company.Domain.Request;
using Company.Domain.Response;
using System.Threading.Tasks;

namespace Company.Domain.Service.Define
{
    public interface IBranchService
    {
        Task<object> CreateBranchAsync(CreateBranchRequest request);
        Task<object> GetAllBranchAysnc(int companyId);
        Task<object> GetBranchByIdAysnc(int branchId);
        Task<object> GetBranchByIdWithHoursAysnc(int Id);
    }
}
