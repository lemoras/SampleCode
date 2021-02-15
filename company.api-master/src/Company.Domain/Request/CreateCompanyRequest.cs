using System;

namespace Company.Domain.Request
{
    public class CreateCompanyRequest
    {
        public string Name { get; set; }
        public string TradeRegisterNo { get; set; }
        public string Logo { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
    }
}
