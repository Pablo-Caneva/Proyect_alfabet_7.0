using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyect_alfabet_7._0.Models
{
    public class User : UserLogin
    {
        [Required]
        [MaxLength(100)]
        [Display(Name ="city")]
        public string City { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name ="email")]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name ="phone")]
        public string Phone { get; set; }

        [NotMapped]
        public IFormFile? ProfilePicture { get; set; } = null;

        public User()
        {
        }
    }
}
