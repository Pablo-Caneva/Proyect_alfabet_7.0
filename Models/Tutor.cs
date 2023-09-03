namespace Proyect_alfabet_7._0.Models
{
    public class Tutor :User
    {
        public List<Student> StudentsInMonitoring { get; set; }
        //public List<Ticket> TicketsSent { get; set; }

        public Tutor()
        {
        }

        public Tutor(int id, string name, string city, string email, string phone, string profilePicture, string password) : base(id, name, city, email, phone, profilePicture, password)
        {
            StudentsInMonitoring = new List<Student>();
            //TicketsSent = new List<Ticket>();
        }

        public void AddStudentInMonitoring(Student student) { StudentsInMonitoring.Add(student); }
        public void RemoveStudentInMonitoring(Student student) { StudentsInMonitoring.Remove(student); }
    }
}
