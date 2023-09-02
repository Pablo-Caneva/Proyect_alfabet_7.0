using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyect_alfabet_7._0.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name ="type")]
        public string Type { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name ="priority")]
        public string Priority { get; set; }

        [Required]
        [Display(Name ="content")]
        public string Content { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name ="state")]
        public string State { get; set; }

        [ForeignKey("Creator")]
        public int CreatorId { get; set; }

        [ForeignKey("Responsable")]
        public int ResponsableId { get; set; }

        public virtual Tutor Creator { get; set; }
        public virtual Admin Responsable { get; set; }
    }
}
