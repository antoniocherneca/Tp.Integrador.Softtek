using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tp.Integrador.Softtek.Entities
{
    [Table("Projects")]
    public class Project
    {
        [Key]
        [Column(TypeName = "INT")]
        public int ProjectId { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string ProjectName { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(200)")]
        public string Address { get; set; }

        [Required]
        [Column(TypeName = "SMALLINT")]
        public byte Status { get; set; }

        [Required]
        [Column(TypeName = "BIT")]
        public bool IsActive { get; set; }
    }

    public enum ProjectStatus { Pendiente = 1, Confirmado = 2, Terminado = 3 }
}
