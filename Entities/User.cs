using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tp.Integrador.Softtek.Entities
{
    [Table("Users")]
    public class User
    {
        [Key]
        [Column(TypeName = "INT")]
        public int UserId { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(50)")]
        public string UserName { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(9)")]
        public int Dni { get; set; }

        [Required]
        [Column(TypeName = "SMALLINT")]
        public int Type { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string Password { get; set; }

        [Required]
        [Column(TypeName = "BIT")]
        public bool IsActive { get; set; }
    }

    public enum UserType { Administrador = 1, Consultor = 2}
}
