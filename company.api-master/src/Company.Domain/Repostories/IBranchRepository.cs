using Company.Domain.Models;
using Company.Domain.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Company.Domain.Repositories
{
    public interface IBranchRepository
    {
        Task<int> CreateBranchAsync(CreateBranchRequest request);

        Task<IEnumerable<Branch>> GetAllBranchByCompanyAsync(int companyId);

        Task<Branch> GetBranchByIdAsync(int Id);
    }
}
