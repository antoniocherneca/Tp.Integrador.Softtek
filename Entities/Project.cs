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
        [Column("VARCHAR(100)")]
        public string ProjectName { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(200)")]
        public string Address { get; set; }

        //[ForeignKey("ProjectStatusId")]
        //[Required]
        //public ProjectStatus ProjectStatus { get; set; }
    }
}
