using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tp.Integrador.Softtek.DTOs;
using Tp.Integrador.Softtek.Helpers;

namespace Tp.Integrador.Softtek.Entities
{
    /// <summary>
    ///     Permite registrar los usuario en el sistema
    /// </summary>
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
            this.Password = PasswordEncryptHelper.EncryptPassword(registerDto.Password, registerDto.Email);
            this.RoleId = registerDto.RoleId;
        }

        public User(RegisterDto registerDto, int id)
        {
            this.UserId = id;
            this.UserName = registerDto.UserName;
            this.Dni = registerDto.Dni;
            this.Email = registerDto.Email;
            this.Password = PasswordEncryptHelper.EncryptPassword(registerDto.Password, registerDto.Email);
            this.RoleId = registerDto.RoleId;
        }

        /// <summary>
        ///     Id del usuario
        /// </summary>
        /// <value>El Id se incrementa automáticamente</value>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column(TypeName = "INT")]
        public int UserId { get; set; }

        /// <summary>
        ///     Obtiene o establece el nombre completo del usuario
        /// </summary>
        /// <value>El nombre completo del usuario</value>
        [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
        [Column(TypeName = "VARCHAR(50)")]
        [MaxLength(50, ErrorMessage = "El nombre de usuario es muy largo")]
        public string UserName { get; set; }

        /// <summary>
        ///     Obtiene o establece el DNI del usuario
        /// </summary>
        /// <value>El DNI del usuario</value>
        [Required(ErrorMessage = "El DNI es obligatorio")]
        [Column(TypeName = "VARCHAR(9)")]
        [MaxLength(9, ErrorMessage = "El DNI es muy largo")]
        public string Dni { get; set; }

        /// <summary>
        ///     Obtiene o establece el e-mail del usuario
        /// </summary>
        /// <value>El e-mail del usuario</value>
        [Required(ErrorMessage = "El E-mail es obligatorio")]
        [Column(TypeName = "VARCHAR(50)")]
        [MaxLength(50, ErrorMessage = "El E-mail es muy largo")]
        public string Email { get; set; }

        /// <summary>
        ///     Obtiene o establece la contraseña del usuario
        /// </summary>
        /// <value>La contraseña del usuario</value>
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [Column(TypeName = "VARCHAR(250)")]
        [MaxLength(250, ErrorMessage = "La contraseña es muy larga")]
        public string Password { get; set; }

        /// <summary>
        ///     Obtiene o establece si el usuario fue eliminado o no. La eliminación es lógica
        /// </summary>
        /// <value>El usuario está eliminado o no</value>
        [Required, Column(TypeName = "BIT")]
        public bool IsDeleted { get; set; }

        /// <summary>
        ///     Obtiene o establece el Id del rol del usuario
        /// </summary>
        /// <value>El Id del rol del usuario</value>
        [ForeignKey("Role"), Required, Column(TypeName = "INT")]
        public int RoleId { get; set; }

        public virtual Role? Role { get; set; }
    }
}
