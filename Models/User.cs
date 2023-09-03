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

        [Required]
        [MaxLength(100)]
        [Display(Name ="ProfilePicture")]
        public string ProfilePicture { get; set; }

        public User()
        {
        }

        public User(int id, string name, string city, string email, string phone, string profilePicture, string password) :base(id, name, password)
        {
            City = city;
            Email = email;
            Phone = phone;
            ProfilePicture = profilePicture;
            Password = password;
        }
    }
}
