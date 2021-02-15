using Company.Domain.Request;
using System.Threading.Tasks;

namespace Company.Domain.Repositories
{
    public interface ICompanyRepository
    {
        Task<int> CreateCompanyAsync(CreateCompanyRequest request);
    }
}
