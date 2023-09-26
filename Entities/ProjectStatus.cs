using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tp.Integrador.Softtek.Entities
{
    [Table("ProjectStatuses")]
    public class ProjectStatus
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column(TypeName = "INT")]
        public int ProjectStatusId { get; set; }

        [Required(ErrorMessage = "El nombre del estado del proyecto es obligatorio")]
        [Column(TypeName = "VARCHAR(20)")]
        [MaxLength(20, ErrorMessage = "El nombre del estado del proyecto es muy largo")]
        public string ProjectStatusName { get; set; }

        [Required, Column(TypeName = "BIT")]
        public bool IsActive { get; set; }
    }
}
