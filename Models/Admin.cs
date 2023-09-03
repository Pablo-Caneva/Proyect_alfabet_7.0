namespace Proyect_alfabet_7._0.Models
{
    public class Admin :User
    {
        public List<Ticket> TicketList { get; set; }

        public Admin()
        {
        }

        public Admin(int id, string name, string city, string email, string phone, string profilePicture, string password) : base(id, name, city, email, phone, profilePicture, password)
        {
            TicketList = new List<Ticket>();
        }

        public bool CreateUser(int id)
        {
            return true;
        }

        public bool DeleteUser(int id)
        {
            return true;
        }

        public bool CreateModule(int moduleNumber)
        {
            return true;
        }

        public bool DeleteModule(int moduleNumber)
        {
            return true;
        }

        public bool CreateLesson(int lessonNumber)
        {
            return true;
        }

        public bool DeleteLesson(int lessonNumber)
        {
            return true;
        }

        public bool CreateContent(int contentNumber)
        {
            return true;
        }

        public bool DeleteContent(int contentNumber)
        {
            return true;
        }
    }
}
