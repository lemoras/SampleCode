using System.Collections.Generic;

namespace Company.Domain.Request
{
    public class UpdateStaffHourRequest
    {
        public int Id { get; set; }
        public int StaffId { get; set; }
        public int Week { get; set; }
        public List<string> WorkHours { get; set; }
    }
}
