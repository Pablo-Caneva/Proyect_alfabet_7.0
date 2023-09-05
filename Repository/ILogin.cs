using Proyect_alfabet_7._0.Models;

namespace Proyect_alfabet_7._0.Repository
{
    public interface ILogin
    {
        Task<IEnumerable<UserLogin>> getuser();
        Task<UserLogin> AuthenticateUser(string username, string passcode);
    }
}