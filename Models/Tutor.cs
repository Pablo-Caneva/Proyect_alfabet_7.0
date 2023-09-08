namespace Proyect_alfabet_7._0.Models
{
    public class Tutor :User
    {
        public List<Student> StudentsInMonitoring { get; set; }
        //public List<Ticket> TicketsSent { get; set; }

        public Tutor()
        {
        }

        public void AddStudentInMonitoring(Student student) { StudentsInMonitoring.Add(student); }
        public void RemoveStudentInMonitoring(Student student) { StudentsInMonitoring.Remove(student); }
    }
}
