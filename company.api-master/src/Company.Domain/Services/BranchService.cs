using Company.Domain.Service.Define;
using Company.Domain.Repositories;
using Company.Domain.Repositories.Define;
using Company.Domain;
using Company.Domain.Request;
using Company.Domain.Response;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Domain.Service
{
    public class BranchService : IBranchService
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IStaffRepository _staffRepository;
        private readonly IStaffHourRepository _staffHourRepository;
        private readonly IApplicationContext _applicationContext;

        public BranchService(IBranchRepository branchRepository, IStaffRepository staffRepository, IStaffHourRepository staffHourRepository, IApplicationContext applicationContext)
        {
            _branchRepository = branchRepository;
            _staffRepository = staffRepository;
            _staffHourRepository = staffHourRepository;
            _applicationContext = applicationContext;
        }

        public async Task<object> CreateBranchAsync(CreateBranchRequest request)
        {
            var result = await _branchRepository.CreateBranchAsync(request);

            return JsonConvert.SerializeObject(result);
        }

        public async Task<object> GetAllBranchAysnc(int companyId)
        {
            var result = await _branchRepository.GetAllBranchByCompanyAsync(companyId);

            return JsonConvert.SerializeObject(result);
        }

        public async Task<object> GetBranchByIdAysnc(int Id)
        {
            var result = await _branchRepository.GetBranchByIdAsync(Id);

            var staff = await _staffRepository.GetStaffByBranchIdAsync(result.Id);

            result.Staffs = staff.ToList();

            return JsonConvert.SerializeObject(result);
        }

        public async Task<object> GetBranchByIdWithHoursAysnc(int Id)
        {
            var result = await _branchRepository.GetBranchByIdAsync(Id);

            var staff = await _staffRepository.GetStaffByBranchIdAsync(result.Id);

            var staffIds = new List<int>();

            staffIds = staff.Select(x => x.Id).ToList();

            var workHours = await _staffHourRepository.GetStaffHoursByStaffs(staffIds);

            result.Staffs = staff.ToList();

            var staffResponses = new List<StaffResponse>();

            foreach (var item in result.Staffs)
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
            }

            var branchResponse = new BranchResponse()
            {
                Id = result.Id,
                Order = result.Order,
                Active = result.Active,
                StaffResponses = staffResponses,
                Adress = result.Adress,
                CityId = result.CityId,
                CreatedBy = result.CreatedBy,
                CreatedDate = result.CreatedDate,
                DeletedBy = result.DeletedBy,
                DeletedDate = result.DeletedDate,
                DistrictId = result.DistrictId,
                ModifiedBy = result.ModifiedBy,
                ModifiedDate = result.ModifiedDate,
                Name = result.Name
            };

            return JsonConvert.SerializeObject(branchResponse);
        }
    }
}
