using Proyect_alfabet_7._0.Models;

namespace Proyect_alfabet_7._0.Repository
{
    /// <summary>
    /// Interfaz que determina las funciones que autentican el logueo.
    /// </summary>
    public interface ILogin
    {
        Task<IEnumerable<UserLogin>> getuser();
        Task<UserLogin> AuthenticateUser(string username, string passcode);
    }
}