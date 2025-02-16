using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatePickerHint.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Range(0.0, 4.0, ErrorMessage = "GPA must be between 0.0 and 4.0.")]
        public double GPA { get; set; }

        [Required]
        public int ProgramOfStudyId { get; set; } // Foreign key property
        public ProgramOfStudy? ProgramOfStudy { get; set; } // Navigation property

        // Computed Property: Age
        public int Age => DateTime.Now.Year - DateOfBirth.Year;

        // Computed Property: GPA Scale
        public string GPAScale => GPA switch
        {
            >= 3.7 => "Excellent",
            >= 3.0 => "Very Good",
            >= 2.0 => "Good",
            >= 1.0 => "Satisfactory",
            _ => "Unsatisfactory"
        };
    }

}
