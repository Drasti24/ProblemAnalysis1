using System.ComponentModel.DataAnnotations;

namespace DatePickerHint.Models
{
    public class ProgramOfStudy
    {
        [Key]
        public string ProgramOfStudyId { get; set; } = string.Empty; // e.g., "CPA"

        [Required]
        public string Name { get; set; } = string.Empty; // e.g., "Computer Programmer Analyst"
    }
}
