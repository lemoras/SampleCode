using Company.Domain.Service.Define;
using Company.Domain.Repositories;
using Company.Domain.Repositories.Define;
using Company.Domain.Constant;
using Company.Domain.Request;
using Company.Domain.Response;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Domain.Service
{
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository _staffRepository;
        private readonly IStaffHourRepository _staffHourRepository;
        private readonly IApplicationContext _applicationContext;

        public StaffService(IStaffRepository staffRepository, IStaffHourRepository staffHourRepository, IApplicationContext applicationContext)
        {
            _staffRepository = staffRepository;
            _staffHourRepository = staffHourRepository;
            _applicationContext = applicationContext;
        }

        public async Task<object> CreateStaffAsync(CreateStaffRequest request)
        {
            request.UserId = _applicationContext.UserId;
            var result = await _staffRepository.CreateStaffAsync(request);

            var newResult = await _staffHourRepository.CreateStaffHourAsync(new CreateStaffHourRequest() { StaffId = result, Week = 52, WorkHours =  DefaultWorkHour.DefaultWorkHours});

            return  JsonConvert.SerializeObject(result);
        }

        public async Task<object> GetStaffByBranchIdAsync(int branchId)
        {
            var staffs = await _staffRepository.GetStaffByBranchIdAsync(branchId);

            var staffIds = new List<int>();

            staffIds = staffs.Select(x => x.Id).ToList();

            var workHours = await _staffHourRepository.GetStaffHoursByStaffs(staffIds);


            var staffResponses = new List<StaffResponse>();

            foreach (var item in staffs)
            {
                staffResponses.Add(new StaffResponse()
                {
                    Id = item.Id,
                    BranchId = item.BranchId,
                    Name = item.Name,
                    PhotoUrl = item.PhotoUrl,
                    Surname = item.Surname,
                    UserId = item.UserId
                });              
            }

            foreach (var item in staffResponses)
            {
                foreach (var jrItem in workHours)
                {
                    if (jrItem.StaffId == item.Id)
                    {
                        item.StaffWorkHours = new StaffWorkHourResponse()
                        {
                            Id = jrItem.Id,
                            StaffId = jrItem.StaffId,
                            Week = jrItem.Week,
                            WorkHours = jrItem.WorkHours.Split(',').ToList()
                        };
                    }
                }
            };                      

            return  JsonConvert.SerializeObject(staffResponses);
        }

        public async Task<object> UpdateStaffAsync(UpdateStaffRequest request)
        {
            var result = await _staffRepository.UpdateStaffAsync(request);

            return  JsonConvert.SerializeObject(result);
        }
    }
}
