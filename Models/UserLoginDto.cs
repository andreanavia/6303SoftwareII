namespace MovieReservationSystem.Models
{
    // DTO = Data Transfer Object para el login
    public class UserLoginDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
