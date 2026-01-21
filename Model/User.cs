using pratices_angular_CURD.Enum;

namespace pratices_angular_CURD.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public UserRole Role { get; set; }
    }
}
