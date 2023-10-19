namespace Proyect_alfabet_7._0.Models
{
    /// <summary>
    /// Usuario admin. Hereda de User. Tiene asociado una lista de tickets.
    /// </summary>
    public class Admin :User
    {
        public List<Ticket>? TicketList { get; set; } = null;
        public Admin() { }
    }
}
