using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Domain.Response
{
    public class StaffWorkHourResponse
    {
        public int Id { get; set; }
        public int StaffId { get; set; }
        public int Week { get; set; }
        public List<string> WorkHours { get; set; }
    }
}
