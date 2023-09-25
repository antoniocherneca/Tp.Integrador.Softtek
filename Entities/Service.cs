using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tp.Integrador.Softtek.Entities
{
    [Table("Services")]
    public class Service
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column(TypeName = "INT")]
        public int SeviceId { get; set; }

        [Required(ErrorMessage = "La descripción del servicio es obligatoria")]
        [Column(TypeName = "VARCHAR(500)")]
        [MaxLength(500, ErrorMessage = "La descripción del servicio es muy larga")]
        public string Description { get; set; }

        [Required(ErrorMessage = "El valor de la hora del servicio es obligatorio")]
        [Column(TypeName = "MONEY")]
        public double HourValue { get; set; }

        [Required, Column(TypeName = "BIT")]
        public bool IsActive { get; set; }
    }
}
