//DRASTI PATEL (#8839416)
//PROBLEM ANALYSIS #1
//FEBRUARY 16, 2025

using System.ComponentModel.DataAnnotations;

namespace DatePickerHint.Models
{
    public class ProgramOfStudy
    {
        [Key]             //marks this property as primary key for the table.
        public int Id { get; set; } 

        [Required]         //makes this property required for model validation.
        public string Name { get; set; } = string.Empty;          //name of program
    }

}
