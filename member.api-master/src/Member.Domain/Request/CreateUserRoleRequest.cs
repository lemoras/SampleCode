namespace Member.Domain.Request
{
    public class CreateUserRoleRequest
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public bool Active { get; set; }
    }
}
