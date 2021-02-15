using Company.Domain.Service.Define;
using Company.Domain.Repositories.Define;
using Company.Domain.Request;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Company.Domain.Service
{
    public class StaffHourService : IStaffHourService
    {
        private readonly IStaffHourRepository _staffHourRepository;
        private readonly IApplicationContext _applicationContext;

        public StaffHourService(IStaffHourRepository staffHourRepository, IApplicationContext applicationContext)
        {
            _staffHourRepository = staffHourRepository;
            _applicationContext = applicationContext;
        }

        public async Task<object> CreateStaffHourAsync(CreateStaffHourRequest request)
        {
            var result = await _staffHourRepository.CreateStaffHourAsync(request);

            return JsonConvert.SerializeObject(result);
        }

        public async Task<object> UpdateStaffHourAsync(UpdateStaffHourRequest request)
        {
            var result = await _staffHourRepository.UpdateStaffHourAsync(request);

            return  JsonConvert.SerializeObject(result);
        }
    }
}
