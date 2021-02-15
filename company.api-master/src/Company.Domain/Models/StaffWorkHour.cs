namespace Company.Domain.Models
{
    public class StaffWorkHour
    {
        public int Id { get; set; }
        public int StaffId { get; set; }
        public int Week { get; set; }
        public string WorkHours { get; set; }
    }
}
