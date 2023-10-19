using Microsoft.EntityFrameworkCore;
using Proyect_alfabet_7._0.Data;
using Proyect_alfabet_7._0.Models;

namespace Proyect_alfabet_7._0.Repository
{
    /// <summary>
    /// Implementación de las funciones de autenticación de logueo, interfaz ILogin.
    /// </summary>
    public class AuthenticateLogin : ILogin
    {
        private readonly ApplicationDbContext _context;

        public AuthenticateLogin(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Tarea asincrónica que determina si el usuario y la contraseña se corresponden con lo guardado en base de datos.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="passcode"></param>
        /// <returns></returns>
        public async Task<UserLogin> AuthenticateUser(string username, string passcode)
        {
            var succeded = await _context.UserLogin.FirstOrDefaultAsync(authUser => authUser.UserName == username && authUser.Password == passcode);
            return succeded;
        }

        /// <summary>
        /// Tarea asincrónica que crea una lista de usuarios en base de datos.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserLogin>> getuser()
        {
            return await _context.UserLogin.ToListAsync();
        }
    }
}
