using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyect_alfabet_7._0.Models
{
    /// <summary>
    /// Clase que guarda el progreso de un estudiante. Uno por estudiante, se crea en cero al crear un usuario Student
    /// </summary>
    public class Progress
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Id del estudiante al que pertenece el progreso.
        /// </summary>
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        /// <summary>
        /// Id del módulo que está realizando el estudiante
        /// </summary>
        [Required]
        [Display(Name ="ModuleId")]
        public int ModuleId { get; set; }
        public virtual Module Module { get; set; }

        /// <summary>
        /// Id de la clase que debe realizar el estudiante a continuación
        /// </summary>
        [Required]
        [Display(Name ="LessonId")]
        public int LessonId { get; set; }
        public virtual Lesson Lesson { get; set; }

        public Progress()
        {
        }  
    }
}
