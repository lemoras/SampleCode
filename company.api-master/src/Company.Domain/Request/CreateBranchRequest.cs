using System;

namespace Company.Domain.Request
{
    public class CreateBranchRequest
    {
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public string Adress { get; set; }
        public int Order { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public bool Active { get; set; }
    }
}
