using Microsoft.EntityFrameworkCore;
using ProiectColectiv.Domain.Entities;

namespace ProiectColectiv.Persistence
{
    public class ProiectColectivDbContext : DbContext
    {
        public ProiectColectivDbContext(DbContextOptions<ProiectColectivDbContext> options)
            : base(options)
        {
        }

        public DbSet<Example> Examples { get; set; }
        //public DbSet<Student> Students { get; set; }
        //public DbSet<Course> Courses { get; set; }
        //public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //// Example: configure relationships / constraints
            //modelBuilder.Entity<Enrollment>()
            //    .HasOne(e => e.Student)
            //    .WithMany(s => s.Enrollments)
            //    .HasForeignKey(e => e.StudentId);

            //modelBuilder.Entity<Enrollment>()
            //    .HasOne(e => e.Course)
            //    .WithMany(c => c.Enrollments)
            //    .HasForeignKey(e => e.CourseId);
        }
    }
}
