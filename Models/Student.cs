namespace Proyect_alfabet_7._0.Models
{
    public class Student :User
    {
        public List<Progress> Progress { get; set; }

        public Student()
        {
        }

        public Student(int id, string name, string city, string email, string phone, string profilePicture, string password) : base(id, name, city, email, phone, profilePicture, password)
        {
            ReceivedMessages = new List<Message>();
            SentMessages = new List<Message>();
            Progress = new List<Progress>();
        }

        public void AddProgress(Progress progress) { Progress.Add(progress); }
    }
}
