namespace Company.Domain.Request
{
    public class CreateStaffRequest
    {
        public int UserId { get; set; }
        public int BranchId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhotoUrl { get; set; }
    }
}
