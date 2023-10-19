namespace Proyect_alfabet_7._0.Models
{
    /// <summary>
    /// Modelo que agrupa los mensajes de un usario para usar en la vista.
    /// </summary>
    public class MessageViewModel
    {
        public List<Message> ReceivedMessages { get; set; }
        public List<Message> SentMessages { get; set; }

        public MessageViewModel() { }
    }
}
