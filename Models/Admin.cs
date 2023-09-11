namespace Proyect_alfabet_7._0.Models
{
    public class Admin :User
    {
        public List<Ticket> TicketList { get; set; }
        public Admin() { }
    }
}
