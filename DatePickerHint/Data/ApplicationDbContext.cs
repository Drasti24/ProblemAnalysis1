using Microsoft.EntityFrameworkCore;
using DatePickerHint.Models;

namespace DatePickerHint.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<ProgramOfStudy> ProgramOfStudies { get; set; } // ✅ Corrected property name

        // Ensure the OnModelCreating method is inside the class
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgramOfStudy>().HasData(
                new ProgramOfStudy { ProgramOfStudyId = "CPA", Name = "Computer Programmer Analyst" },
                new ProgramOfStudy { ProgramOfStudyId = "BACS", Name = "Bachelor of Applied Computer Science" }
            );
        }
    }
}
