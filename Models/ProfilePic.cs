using System.ComponentModel.DataAnnotations;

namespace Proyect_alfabet_7._0.Models
{
    public class ProfilePic
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name ="UserId")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        [Display(Name ="Picture")]
        public byte[] ProfilePictureBytes { get; set; }

        public ProfilePic() { }

    }
}
