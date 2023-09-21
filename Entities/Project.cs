using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tp.Integrador.Softtek.Entities
{
    [Table("Projects")]
    public class Project
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column(TypeName = "INT")]
        public int ProjectId { get; set; }

        [Required, Column(TypeName = "VARCHAR(100)")]
        public string ProjectName { get; set; }

        [Required, Column(TypeName = "VARCHAR(200)")]
        public string Address { get; set; }

        [Required, Column(TypeName = "SMALLINT")]
        public byte Status { get; set; }

        [Required, Column(TypeName = "BIT")]
        public bool IsActive { get; set; }

        [ForeignKey("ProjectStatus"), Required, Column(TypeName = "INT")]
        public int ProjectStatusId { get; set; }

        public virtual ProjectStatus ProjectStatus { get; set; }
    }
}
