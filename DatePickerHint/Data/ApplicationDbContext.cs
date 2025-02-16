﻿using Microsoft.EntityFrameworkCore;
using DatePickerHint.Models;
using System;

namespace DatePickerHint.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<ProgramOfStudy> ProgramOfStudies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Programs
            modelBuilder.Entity<ProgramOfStudy>().HasData(
                new ProgramOfStudy { Id = 1, Name = "Computer Programmer (CP)" },
                new ProgramOfStudy { Id = 2, Name = "Bachelor of Applied Computer Science (BACS)" }
            );

            // Seed Students
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
