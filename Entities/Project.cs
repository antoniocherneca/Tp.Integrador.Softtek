using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tp.Integrador.Softtek.Entities
{
    /// <summary>
    ///     Permite registrar los proyectos que tiene la empresa
    /// </summary>
    [Table("Projects")]
    public class Project
    {
        /// <summary>
        ///     Id del proyecto
        /// </summary>
        /// <value>El Id se incrementa automáticamente</value>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column(TypeName = "INT")]
        public int ProjectId { get; set; }

        /// <summary>
        ///     Obtiene o establece el nombre de proyecto
        /// </summary>
        /// <value>El nombre del proyecto</value>
        [Required(ErrorMessage = "El nombre del proyecto es obligatorio")]
        [Column(TypeName = "VARCHAR(100)")]
        [MaxLength(100, ErrorMessage = "El nombre del proyecto es muy largo")]
        public string ProjectName { get; set; }

        /// <summary>
        ///     Obtiene o establece la dirección del proyecto
        /// </summary>
        /// <value>La dirección del proyecto</value>
        [Required(ErrorMessage = "La dirección del proyecto es obligatoria")]
        [Column(TypeName = "VARCHAR(200)")]
        [MaxLength(200, ErrorMessage = "La dirección es muy larga")]
        public string Address { get; set; }

        /// <summary>
        ///     Obtiene o establece si el proyecto fue eliminado o no. La eliminación es lógica
        /// </summary>
        /// <value>El proyecto está eliminado o no</value>
        [Required, Column(TypeName = "BIT")]
        public bool IsDeleted { get; set; }

        /// <summary>
        ///     Obtiene o establece el Id del estado del proyecto
        /// </summary>
        /// <value>El Id del estado del proyecto</value>
        [ForeignKey("ProjectStatus"), Required, Column(TypeName = "INT")]
        public int ProjectStatusId { get; set; }

        public virtual ProjectStatus? ProjectStatus { get; set; }
    }
}
