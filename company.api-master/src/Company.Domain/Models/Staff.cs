namespace Company.Domain.Models
{
    public class Staff
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BranchId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhotoUrl { get; set; }

        public StaffWorkHour StaffWorkHours { get; set; }
    }
}
