using Microsoft.EntityFrameworkCore;
using Proyect_alfabet_7._0.Models;

namespace Proyect_alfabet_7._0.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
            
        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Tutor> Tutors { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Progress> Progress { get; set; }
        public DbSet<UserLogin> UserLogin { get; set; }
        public DbSet<ProfilePic> ProfilePic { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .HasOne(m => m.Sender)
                .WithMany()
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.Restrict); // Puedes configurar OnDelete según tus necesidades

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Receiver)
                .WithMany()
                .HasForeignKey(m => m.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict); // Puedes configurar OnDelete según tus necesidades

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.HasKey(k => k.Id);
                entity.HasIndex(m => m.UserName).IsUnique();
            });

            modelBuilder.Entity<Progress>()
                .HasIndex(p => p.StudentId).IsUnique();
            modelBuilder.Entity<Module>()
                .HasIndex(m => m.Number).IsUnique();
        }
    }
}
