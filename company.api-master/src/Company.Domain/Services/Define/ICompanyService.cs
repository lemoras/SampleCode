using Company.Domain.Request;
using Company.Domain.Response;
using System.Threading.Tasks;

namespace Company.Domain.Service.Define
{
    public interface ICompanyService
    {
        Task<object> CreateCompanyAsync(CreateCompanyRequest request);
        Task<object> CreateAsync(CreateCompanyRegisterRequest request);
    }
}
