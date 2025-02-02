namespace HOTELBOOKING.Application.Dtos.User.Response
{
    public class GetAllUserResponseDto
    {
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public int RoleId { get; set; }
        public string? RoleName { get; set; }
        public string? StateName { get; set; }
        public DateTime AuditCreateDate { get; set; }
    }
}
