namespace Company.Domain.Request
{
    public class CreateCompanyRegisterRequest
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public int CountyId { get; set; }
        public int DistrcitId { get; set; }
    }
}
