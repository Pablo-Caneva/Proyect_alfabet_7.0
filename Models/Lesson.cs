using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Proyect_alfabet_7._0.Models
{
    /// <summary>
    /// Las lecciones son los componentes de los módulos.
    /// </summary>
    public class Lesson
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name ="number")]
        public int Number { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name ="URL")]
        public string Url { get; set; }

        [Required]
        [Display(Name ="Module")]
        public int ModuleId { get; set; }
        public virtual Module Module { get; set; }

        [Required]
        [Display(Name = "Last")]
        public bool isLast { get; set; }

        public Lesson()
        {
        }
    }
}
