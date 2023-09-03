using System.ComponentModel.DataAnnotations;

namespace Proyect_alfabet_7._0.Models
{
    public class Content
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name ="URL")]
        public string Url { get; set; }

        //isLast?

        public Lesson Lesson { get; set; }

        public Content() { }
        public Content(int id, string url, Lesson lesson)
        {
            Id = id;
            Url = url;
            Lesson = lesson;
            lesson.AddContent(this);
        }
    }
}
