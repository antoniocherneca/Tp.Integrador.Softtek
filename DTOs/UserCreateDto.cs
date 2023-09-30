namespace Tp.Integrador.Softtek.Entities
{
    public class UserCreateDto
    {
        public string UserName { get; set; }
        public string Dni { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte RoleId { get; set; }
    }
}
