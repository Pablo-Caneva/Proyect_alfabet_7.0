using Microsoft.EntityFrameworkCore;
using Proyect_alfabet_7._0.Data;
using Proyect_alfabet_7._0.Models;

namespace Proyect_alfabet_7._0.Repository
{
    public class AuthenticateLogin : ILogin
    {
        private readonly ApplicationDbContext _context;

        public AuthenticateLogin(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserLogin> AuthenticateUser(string username, string passcode)
        {
            var succeded = await _context.UserLogin.FirstOrDefaultAsync(authUser => authUser.UserName == username && authUser.Password == passcode);
            return succeded;
        }

        public async Task<IEnumerable<UserLogin>> getuser()
        {
            return await _context.UserLogin.ToListAsync();
        }

        public async Task<string> GetDiscriminatorFromDB(int id)
        {
            string? discriminator = await _context.UserLogin
                .Where(u => u.Id == id)
                .Select(u => EF.Property<string>(u, "Discriminator"))
                .FirstOrDefaultAsync();

            if (discriminator != null)
            {
                return discriminator.ToString();
            }

            else { return "x"; }
            
        }
    }
}
