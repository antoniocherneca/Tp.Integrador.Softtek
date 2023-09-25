using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tp.Integrador.Softtek.Entities
{
    [Table("Jobs")]
    public class Job
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column(TypeName = "INT")]
        public int JobId { get; set; }

        [Required(ErrorMessage = "La fecha de inicio del trabajo es obligatoria")]
        [Column(TypeName = "DATE")]
        public DateTime JobDate { get; set; }

        [Required(ErrorMessage = "El número de horas del trabajo es obligatorio")]
        [Column(TypeName = "INT")]
        public int NumberOfHours { get; set; }

        [Required(ErrorMessage = "El valor de la hora del trabajo es obligatorio")]
        [Column(TypeName = "MONEY")]
        public double HourValue { get; set; }

        [Required(ErrorMessage = "El costo del trabajo es obligatorio")]
        [Column(TypeName = "MONEY")]
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
