using pratices_angular_CURD.Enum;

namespace pratices_angular_CURD.Dtos
{
    public class RegisterDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
    }
}
