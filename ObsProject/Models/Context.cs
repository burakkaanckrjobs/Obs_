using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ObsProject.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<İlceler> İlcelers { get; set; }
        public DbSet<İller> İllers { get; set; }
        public DbSet<StudentHobby> StudentHobbies { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Teachers> Teachers { get; set; }
        public DbSet<TeacherStudens> TeacherStudens { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
