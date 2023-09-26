using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tp.Integrador.Softtek.DTOs;
using Tp.Integrador.Softtek.Helpers;

namespace Tp.Integrador.Softtek.Entities
{
    [Table("Users")]
    public class User
    {
        public User()
        {
            
        }

        public User(RegisterDto registerDto)
        {
            this.UserName = registerDto.UserName;
            this.Dni = registerDto.Dni;
            this.Email = registerDto.Email;
            this.Password = PasswordEncryptHelper.EncryptPassword(registerDto.Password);
            this.IsActive = registerDto.IsActive;
            this.RoleId = registerDto.RoleId;
        }

        public User(RegisterDto registerDto, int id)
        {
            this.UserId = id;
            this.UserName = registerDto.UserName;
            this.Dni = registerDto.Dni;
            this.Email = registerDto.Email;
            this.Password = PasswordEncryptHelper.EncryptPassword(registerDto.Password);
            this.IsActive = registerDto.IsActive;
            this.RoleId = registerDto.RoleId;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column(TypeName = "INT")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
        [Column(TypeName = "VARCHAR(50)")]
        [MaxLength(50, ErrorMessage = "El nombre de usuario es muy largo")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "El DNI es obligatorio")]
        [Column(TypeName = "VARCHAR(9)")]
        [MaxLength(9, ErrorMessage = "El DNI es muy largo")]
        public string Dni { get; set; }

        [Required(ErrorMessage = "El E-mail es obligatorio")]
        [Column(TypeName = "VARCHAR(50)")]
        [MaxLength(50, ErrorMessage = "El E-mail es muy largo")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [Column(TypeName = "VARCHAR(250)")]
        [MaxLength(250, ErrorMessage = "La contraseña es muy larga")]
        public string Password { get; set; }

        [Required, Column(TypeName = "BIT")]
        public bool IsActive { get; set; }

        [ForeignKey("Role"), Required, Column(TypeName = "INT")]
        public int RoleId { get; set; }

        public virtual Role? Role { get; set; }
    }
}
