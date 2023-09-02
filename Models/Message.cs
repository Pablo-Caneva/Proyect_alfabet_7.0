using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyect_alfabet_7._0.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "message")]
        public string Content { get; set; }

        [ForeignKey("Sender")]
        public int SenderId { get; set; }

        [ForeignKey("Receiver")]
        public int ReceiverId { get; set;}

        public virtual User Sender { get; set; }
        public virtual User Receiver { get; set; }
    }
}
