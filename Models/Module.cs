using System.ComponentModel.DataAnnotations;

namespace Proyect_alfabet_7._0.Models
{
    public class Module
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name ="number")]
        public int Number { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name ="description")]
        public string Description { get; set; }

        [Required]
        [Display(Name ="Lessons Quantity")]
        public int LessonsQuantity { get; set; }

        public Module()
        {
        }
    }
}
