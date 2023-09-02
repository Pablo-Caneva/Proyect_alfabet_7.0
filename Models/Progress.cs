using System.ComponentModel.DataAnnotations;

namespace Proyect_alfabet_7._0.Models
{
    public class Progress
    {
        [Key]
        public int Id { get; set; }

        public Student Student { get; set; }
        public Module Module { get; set; }
        public Lesson Lesson { get; set; }
        public List<Content> FinishedContents { get; set; }

        public Progress()
        {
        }

        public Progress(int id, Student student, Module module, Lesson lesson)
        {
            Id = id;
            Student = student;
            Module = module;
            Lesson = lesson;
            FinishedContents = new List<Content>();
        }

        public void AddContents(Content content) { FinishedContents.Add(content); }

        public bool Finished()
        {
            int totalLessons = Lesson.Contents.Count;
            int finishedLessons = FinishedContents.Count;
            if (totalLessons == finishedLessons) { return true; } else { return false; }
        }
    }
}
