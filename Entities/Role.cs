using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tp.Integrador.Softtek.Entities
{
    /// <summary>
    ///     Permite registrar los roles de usuario en el sistema
    /// </summary>
    [Table("Roles")]
    public class Role
    {
        public Role()
        {
            
        }

        public Role(RoleDto roleDto)
        {
            this.RoleId = roleDto.RoleId;
            this.RoleName = roleDto.RoleName;
            this.IsDeleted = roleDto.IsDeleted;
        }

        /// <summary>
        ///     Id del rol de usuario
        /// </summary>
        /// <value>El Id se incrementa automáticamente</value>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column(TypeName = "INT")]
        public int RoleId { get; set; }

        /// <summary>
        ///     Obtiene o establece el nombre del rol de usuario
        /// </summary>
        /// <value>El nombre del rol de usuario</value>
        [Required(ErrorMessage = "El nombre del rol es obligatorio")]
        [Column(TypeName = "VARCHAR(20)")]
        [MaxLength(20, ErrorMessage = "El nombre del rol es muy largo")]
        public string RoleName { get; set; }

        /// <summary>
        ///     Obtiene o establece si el rol de usuario fue eliminado o no. La eliminación es lógica
        /// </summary>
        /// <value>El rol de usuario está eliminado o no</value>
        [Required, Column(TypeName = "BIT")]
        public bool IsDeleted { get; set; }
    }
}
