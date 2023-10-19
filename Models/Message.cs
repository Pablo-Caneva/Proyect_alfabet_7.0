using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyect_alfabet_7._0.Models
{
    /// <summary>
    /// Modelado de mensajes que se mandan entre usuarios.
    /// </summary>
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "message")]
        public string Content { get; set; }

        [ForeignKey("Sender")]
        public int SenderId { get; set; }

        public string? SenderName { get; set; } = null;

        [ForeignKey("Receiver")]
        public int ReceiverId { get; set;}

        public string? ReceiverName { get; set; } = null;

        public virtual User? Sender { get; set; } = null;
        public virtual User? Receiver { get; set; } = null;

        public Message() { }
    }
}
