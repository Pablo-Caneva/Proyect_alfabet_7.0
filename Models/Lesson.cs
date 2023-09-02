using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Proyect_alfabet_7._0.Models
{
    public class Lesson
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

        public Module Module { get; set; }
        public List<Content> Contents { get; set; }

        public Lesson()
        {
        }

        public Lesson(int id, int number, string description, Module module)
        {
            Id = id;
            Number = number;
            Description = description;
            Module = module;
            Contents = new List<Content>();
            module.AddLesson(this);
        }

        public void AddContent(Content content) { Contents.Add(content); }

        public void RemoveContent(Content content) { Contents.Remove(content); }

        public bool Enabled(Progress progress) => progress.Finished() ? true : false;
    }
}
