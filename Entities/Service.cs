using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tp.Integrador.Softtek.Entities
{
    /// <summary>
    ///     Permite registrar los servicios que brinda la empresa
    /// </summary>
    [Table("Services")]
    public class Service
    {
        /// <summary>
        ///     Id del servicio
        /// </summary>
        /// <value>El Id se incrementa automáticamente</value>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column(TypeName = "INT")]
        public int ServiceId { get; set; }

        /// <summary>
        ///     Obtiene o establece la descripción del servicio
        /// </summary>
        /// <value>La descripción del servicio</value>
        [Required(ErrorMessage = "La descripción del servicio es obligatoria")]
        [Column(TypeName = "VARCHAR(500)")]
        [MaxLength(500, ErrorMessage = "La descripción del servicio es muy larga")]
        public string Description { get; set; }

        /// <summary>
        ///     Obtiene o establece el valor/hora del servicio
        /// </summary>
        /// <value>El valor/hora del servicio</value>
        [Required(ErrorMessage = "El valor de la hora del servicio es obligatorio")]
        [Column(TypeName = "MONEY")]
        public double HourValue { get; set; }

        /// <summary>
        ///     Obtiene o establece si el servicio fue eliminado o no. La eliminación es lógica
        /// </summary>
        /// <value>El servicio está eliminado o no</value>
        [Required, Column(TypeName = "BIT")]
        public bool IsDeleted { get; set; }
    }
}
