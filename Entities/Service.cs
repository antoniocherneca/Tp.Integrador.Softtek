using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tp.Integrador.Softtek.Entities
{
    [Table("Services")]
    public class Service
    {
        [Key]
        [Column(TypeName = "INT")]
        public int SeviceId { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(500)")]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "BIT")]
        public bool ServiceStatus { get; set; }

        [Required]
        [Column(TypeName = "MONEY")]
        public double HourValue { get; set; }
    }
}
