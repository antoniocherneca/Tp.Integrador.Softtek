using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tp.Integrador.Softtek.Entities
{
    [Table("Jobs")]
    public class Job
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column(TypeName = "INT")]
        public int JobId { get; set; }

        [Required, Column(TypeName = "DATE")]
        public DateTime JobDate { get; set; }

        [Required, Column(TypeName = "INT")]
        public int NumberOfHours { get; set; }

        [Required, Column(TypeName = "MONEY")]
        public double HourValue { get; set; }

        [Required, Column(TypeName = "MONEY")]
        public double Cost { get; set; }

        [Required, Column(TypeName = "BIT")]
        public bool IsActive { get; set; }

        [ForeignKey("Project"), Required, Column(TypeName = "INT")]
        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }

        [ForeignKey("Service"), Required, Column(TypeName = "INT")]
        public int ServiceId { get; set; }

        public virtual Service Service { get; set; }
    }
}
