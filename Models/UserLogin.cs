using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Proyect_alfabet_7._0.Models
{
    /// <summary>
    /// Superclase que maneja nombre de usuario y contraseña.
    /// </summary>
    public class UserLogin
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage="Debe ingresar su usuario")]
        [Display(Name ="Ingrese su usuario")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Debe ingresar una contraseña")]
        [Display(Name ="Ingrese su contraseña")]
        public string Password { get; set; }

        public UserLogin()
        {
        }
    }
}
