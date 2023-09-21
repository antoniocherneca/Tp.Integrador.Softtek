using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tp.Integrador.Softtek.Entities
{
    [Table("ProjectStatuses")]
    public class ProjectStatus
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column(TypeName = "INT")]
        public int ProjectStatusId { get; set; }

        public string ProjectStatusName { get; set; }
    }
}
