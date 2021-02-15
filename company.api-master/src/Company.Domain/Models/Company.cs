using System;

namespace Company.Domain.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string TradeRegisterNo { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime DeletedDate { get; set; }
        public int DeletedBy { get; set; }

    }
}
