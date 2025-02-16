//DRASTI PATEL (#8839416)
//PROBLEM ANALYSIS #1
//FEBRUARY 16, 2025

using Microsoft.EntityFrameworkCore;
using DatePickerHint.Models;
using System;

namespace DatePickerHint.Data
{
    public class ApplicationDbContext : DbContext
    {
        //constructor initializes the context with provided options.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        //defines the DbSets for students and programs of study.
        public DbSet<Student> Students { get; set; }
        public DbSet<ProgramOfStudy> ProgramOfStudies { get; set; }

        //OnModelCreating method is used to configure the model, such as setting up initial data (seeding)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed ProgramOfStudy table with some predefined programs.
            modelBuilder.Entity<ProgramOfStudy>().HasData(
                new ProgramOfStudy { Id = 1, Name = "Computer Programmer (CP)" },
                new ProgramOfStudy { Id = 2, Name = "Bachelor of Applied Computer Science (BACS)" }
            );

            //seed student table with initial student data.
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    FirstName = "Bart",
                    LastName = "Simpson",
                    DateOfBirth = new DateTime(1971, 5, 31),
                    GPA = 2.7,
                    ProgramOfStudyId = 1
                },
                new Student
                {
                    Id = 2,
                    FirstName = "Lisa",
                    LastName = "Simpson",
                    DateOfBirth = new DateTime(1973, 8, 5),
                    GPA = 4.0,
                    ProgramOfStudyId = 2
                }
            );
        }

    }
}
