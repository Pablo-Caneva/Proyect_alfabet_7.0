using System.ComponentModel.DataAnnotations;

namespace Proyect_alfabet_7._0.Models
{
    public class Module
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name ="number")]
        public int Number { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name ="description")]
        public string Description { get; set; }

        public List<Lesson> Lessons { get; set; }

        public Module()
        {
        }

        public Module(int id, int number, string description)
        {
            Id = id;
            Number = number;
            Description = description;
            Lessons = new List<Lesson>();
        }

        public void AddLesson(Lesson lesson) { Lessons.Add(lesson); }

        public void RemoveLesson(Lesson lesson) { Lessons.Remove(lesson); }
    }
}
