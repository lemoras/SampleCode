using System.Collections.Generic;

namespace Company.Domain.Request
{
    public class CreateStaffHourRequest
    {
        public int StaffId { get; set; }
        public int Week { get; set; }
        public List<string> WorkHours { get; set; }
    }
}
