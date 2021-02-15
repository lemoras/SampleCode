using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Domain.Response
{
    public class StaffResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BranchId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhotoUrl { get; set; }

        public StaffWorkHourResponse StaffWorkHours { get; set; }
    }
}
