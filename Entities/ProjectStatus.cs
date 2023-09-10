using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tp.Integrador.Softtek.Entities
{
    [Table("ProjectStatuses")]
    public class ProjectStatus
    {
        [Key]
        [Column(TypeName = "INT")]
        public int ProjectStatusId { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(20)")]
        public string ProjectStatusDescription { get; set; }
    }
}
