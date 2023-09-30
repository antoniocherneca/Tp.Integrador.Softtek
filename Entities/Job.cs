using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tp.Integrador.Softtek.Entities
{
    /// <summary>
    ///     Permite registrar los trabajos que realiza la empresa
    /// </summary>
    [Table("Jobs")]
    public class Job
    {
        /// <summary>
        ///     Id del trabajo
        /// </summary>
        /// <value>El Id se incrementa automáticamente</value>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column(TypeName = "INT")]
        public int JobId { get; set; }

        /// <summary>
        ///     Obtiene o establece la fecha de inicio del trabajo
        /// </summary>
        /// <value>La fecha de inicio del trabajo</value>
        [Required(ErrorMessage = "La fecha de inicio del trabajo es obligatoria")]
        [Column(TypeName = "DATE")]
        public DateTime JobDate { get; set; }

        /// <summary>
        ///     Obtiene o establece el número de horas del trabajo
        /// </summary>
        /// <value>Número de horas del trabajo</value>
        [Required(ErrorMessage = "El número de horas del trabajo es obligatorio")]
        [Column(TypeName = "INT")]
        public int NumberOfHours { get; set; }

        /// <summary>
        ///     Obtiene o establece el valor/hora del trabajo
        /// </summary>
        /// <value>El valor/hora del trabajo</value>
        [Required(ErrorMessage = "El valor de la hora del trabajo es obligatorio")]
        [Column(TypeName = "MONEY")]
        public double HourValue { get; set; }

        /// <summary>
        ///     Obtiene o establece el costo del trabajo
        /// </summary>
        /// <value>El costo del trabajo</value>
        [Required(ErrorMessage = "El costo del trabajo es obligatorio")]
        [Column(TypeName = "MONEY")]
        public double Cost { get; set; }

        /// <summary>
        ///     Obtiene o establece si el trabajo fue eliminado o no. La eliminación es lógica
        /// </summary>
        /// <value>El trabajo está eliminado o no</value>
        [Required, Column(TypeName = "BIT")]
        public bool IsDeleted { get; set; }

        /// <summary>
        ///     Obtiene o establece el Id del proyecto al que corresponde el servicio que contiene el trabajo
        /// </summary>
        /// <value>El Id que del projecto al que corresponde el servicio que contiene el trabajo</value>
        [ForeignKey("Project"), Required, Column(TypeName = "INT")]
        public int ProjectId { get; set; }

        public virtual Project? Project { get; set; }

        /// <summary>
        ///     Obtiene o establece el Id del servicio al que corresponde el trabajo
        /// </summary>
        /// <value>El Id que del servicio al que corresponde el trabajo</value>
        [ForeignKey("Service"), Required, Column(TypeName = "INT")]
        public int ServiceId { get; set; }

        public virtual Service? Service { get; set; }
    }
}
