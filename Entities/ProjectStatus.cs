using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tp.Integrador.Softtek.Entities
{
    /// <summary>
    ///     Permite registrar los estados de proyecto que tiene la empresa
    /// </summary>
    [Table("ProjectStatuses")]
    public class ProjectStatus
    {
        /// <summary>
        ///     Id del estado del proyecto
        /// </summary>
        /// <value>El Id se incrementa automáticamente</value>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column(TypeName = "INT")]
        public int ProjectStatusId { get; set; }

        /// <summary>
        ///     Obtiene o establece el nombre del estado de proyecto
        /// </summary>
        /// <value>El nombre del estado de proyecto</value>
        [Required(ErrorMessage = "El nombre del estado del proyecto es obligatorio")]
        [Column(TypeName = "VARCHAR(20)")]
        [MaxLength(20, ErrorMessage = "El nombre del estado del proyecto es muy largo")]
        public string ProjectStatusName { get; set; }

        /// <summary>
        ///     Obtiene o establece si el estado de proyecto fue eliminado o no. La eliminación es lógica
        /// </summary>
        /// <value>El estado de proyecto está eliminado o no</value>
        [Required, Column(TypeName = "BIT")]
        public bool IsDeleted { get; set; }
    }
}
