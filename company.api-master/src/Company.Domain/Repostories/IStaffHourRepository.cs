using Company.Domain.Models;
using Company.Domain.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Company.Domain.Repositories.Define
{
    public interface IStaffHourRepository
    {
        Task<int> CreateStaffHourAsync(CreateStaffHourRequest request);

        Task<int> UpdateStaffHourAsync(UpdateStaffHourRequest request);

        Task<StaffWorkHour> GetStaffHourByStaffId(int staffId);

        Task<IEnumerable<StaffWorkHour>> GetStaffHoursByStaffs(List<int> staffId);
    }
}
