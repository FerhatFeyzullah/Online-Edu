namespace OnlineEdu.DTO.DTOs.UserDTOs
{
    public class AssignRoleDto
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool RoleExist { get; set; }

    }
}
