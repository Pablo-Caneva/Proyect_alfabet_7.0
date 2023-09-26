using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyect_alfabet_7._0.Models
{
    public class Activity
    {
        [Key] public int Id { get; set; }

        [NotMapped] public string? firstInput { get; set; } = null;
        [NotMapped] public string? secondInput { get; set; } = null;
        [NotMapped] public string? thirdInput { get; set; } = null;
        [NotMapped] public string? fourthInput { get; set; } = null;
        [NotMapped] public string? fifthInput { get; set; } = null;
        [NotMapped] public string? sixthInput { get; set; } = null;
        [NotMapped] public string? seventhInput { get; set; } = null;
        [NotMapped] public string? eigthInput { get; set; } = null;
        [NotMapped] public string? ninthInput { get; set; } = null;
        [NotMapped] public string? tenthInput { get; set; } = null;

        public Activity() { }
    }
}
