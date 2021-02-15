namespace Company.Domain.Models
{
    public class BranchImage
    {
        public int Id { get; set; }
        public int BranchId { get; set; }
        public int Order { get; set; }
        public bool Active { get; set; }
        public string Url { get; set; }
    }
}
