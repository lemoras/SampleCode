using Company.Domain.Request;
using Company.Domain.Response;
using System.Threading.Tasks;

namespace Company.Domain.Service.Define
{
    public interface IStaffHourService
    {
        Task<object> CreateStaffHourAsync(CreateStaffHourRequest request);

        Task<object> UpdateStaffHourAsync(UpdateStaffHourRequest request);

    }
}
