﻿using System;
using System.Collections.Generic;

namespace Company.Domain.Models
{
    public class Branch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public string Adress { get; set; }
        public int Order { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime DeletedDate { get; set; }
        public int DeletedBy { get; set; }

        public List<Staff> Staffs { get; set; }
    }
}
