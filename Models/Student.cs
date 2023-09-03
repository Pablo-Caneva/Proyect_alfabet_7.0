using Microsoft.EntityFrameworkCore;
using Proyect_alfabet_7._0.Data;

namespace Proyect_alfabet_7._0.Models
{
    public class Student :User
    {
        private readonly ApplicationDbContext _context;

        public Student() { }
        public Student(ApplicationDbContext context)
        {
            _context = context;
        }

        //public Student(int id, string name, string city, string email, string phone, string profilepicture, string password) : base(id, name, city, email, phone, profilepicture, password)
        //{
        //}

        public async Task<List<Progress>> getStudentProgress()
        {
            return await _context.Progress.ToListAsync();
        }
    }
}
