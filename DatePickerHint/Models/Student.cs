using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatePickerHint.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a first name.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a last name.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a date of birth.")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please enter a valid GPA.")]
        [Range(0, 4.0, ErrorMessage = "GPA must be between 0.0 and 4.0.")]
        public double GPA { get; set; }

        [Required(ErrorMessage = "Please select a program of study.")]
        public string ProgramOfStudyId { get; set; } = string.Empty;

        [ForeignKey("ProgramOfStudyId")]
        public ProgramOfStudy? ProgramOfStudy { get; set; }

        // Computed properties
        [NotMapped]
        public int Age => DateTime.Now.Year - DateOfBirth.Year; // Simplistic, may not account for month/day

        [NotMapped]
        public string GPAScale
        {
            get
            {
                if (GPA >= 3.7) return "Excellent";
                if (GPA >= 3.3) return "Very Good";
                if (GPA >= 2.7) return "Good";
                if (GPA >= 2.0) return "Satisfactory";
                return "Unsatisfactory";
            }
        }
    }
}
