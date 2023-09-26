namespace Tp.Integrador.Softtek.DTOs
{
    public class RegisterDto
    {
        public string UserName { get; set; }
        public string Dni { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public byte RoleId { get; set; }
    }
}
