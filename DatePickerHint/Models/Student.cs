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
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Range(0, 4.0, ErrorMessage = "GPA must be between 0 and 4.0.")]
        public double GPA { get; set; }

        [NotMapped] // Computed property, not stored in DB
        public int Age => DateTime.Now.Year - DateOfBirth.Year;

        [NotMapped] // Computed property, not stored in DB
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
