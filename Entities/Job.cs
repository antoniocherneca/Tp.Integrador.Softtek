using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tp.Integrador.Softtek.Entities
{
    [Table("Jobs")]
    public class Job
    {
        [Key]
        [Column(TypeName = "INT")]
        public int JobId { get; set; }

        [Required]
        [Column(TypeName = "DATE")]
        public DateTime JobDate { get; set; }

        [Required]
        [Column(TypeName = "INT")]
        public int NumberOfHours { get; set; }

        [Required]
        [Column(TypeName = "MONEY")]
        public double HourValue { get; set; }

        [Required]
        [Column(TypeName = "MONEY")]
        public double Cost { get; set; }

        //[ForeignKey("ProjectId")]
        //[Required]
        //public Project Project { get; set; }

        //[ForeignKey("ServiceId")]
        //[Required]
        //public Service Service { get; set; }
    }
}
