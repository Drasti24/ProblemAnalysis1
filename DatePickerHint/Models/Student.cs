//DRASTI PATEL (#8839416)
//PROBLEM ANALYSIS #1
//FEBRUARY 16, 2025

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatePickerHint.Models
{
    public class Student
    {
        [Key]            //marks this property as primary key for the table.
        public int Id { get; set; }

        [Required]      //ensures first name is provided
        public string FirstName { get; set; } = string.Empty;

        [Required]      //ensures last name is provided
        public string LastName { get; set; } = string.Empty;

        [Required]      //ensures DOB is provided
        public DateTime DateOfBirth { get; set; }

        [Required]      //ensures GPA is provided and within valid range.
        [Range(0.0, 4.0, ErrorMessage = "GPA must be between 0.0 and 4.0.")]
        public double GPA { get; set; }

        [Required]      //marks ProgramOfStudyId as required and represents foreign key
        public int ProgramOfStudyId { get; set; }
        //navigation property for related ProgramOfStudy
        public ProgramOfStudy? ProgramOfStudy { get; set; } 

        //computed property for calculating student's age based on their DOB.
        public int Age => DateTime.Now.Year - DateOfBirth.Year;

        //computed property for categorinzing GPA on scale.
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
