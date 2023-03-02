namespace Tecoora.API.Models
{
    public class UserRequestDto
    {
        public string UserType { get; set; }
        public string sortBy { get; set; }
        public string search { get; set; }
        public string Email { get; set; }
        public string OTP { get; set; }
    }
}
