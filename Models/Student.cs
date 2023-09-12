using Microsoft.EntityFrameworkCore;
using Proyect_alfabet_7._0.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyect_alfabet_7._0.Models
{
    public class Student :User
    {
        public int? TutorId { get; set; } = null;
        public virtual Tutor? Tutor { get; set; } = null;

        [NotMapped]
        public virtual double? StudentProgress { get; set; } = null;

        [NotMapped]
        public virtual int? StudentModule { get; set; } = null;

        [NotMapped]
        public virtual int? StudentLesson { get; set; } = null;
        public Student() { }
    }
}
