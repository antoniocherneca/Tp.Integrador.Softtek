using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tp.Integrador.Softtek.Entities
{
    [Table("Projects")]
    public class Project
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column(TypeName = "INT")]
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "El nombre del proyecto es obligatorio")]
        [Column(TypeName = "VARCHAR(100)")]
        [MaxLength(100, ErrorMessage = "El nombre del proyecto es muy largo")]
        public string ProjectName { get; set; }

        [Required(ErrorMessage = "La dirección del proyecto es obligatoria")]
        [Column(TypeName = "VARCHAR(200)")]
        [MaxLength(200, ErrorMessage = "El nombre del proyecto es muy largo")]
        public string Address { get; set; }

        [Required, Column(TypeName = "BIT")]
        public bool IsActive { get; set; }

        [ForeignKey("ProjectStatus"), Required, Column(TypeName = "INT")]
        public int ProjectStatusId { get; set; }

        public virtual ProjectStatus? ProjectStatus { get; set; }
    }
}
