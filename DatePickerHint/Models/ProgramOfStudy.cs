using System.ComponentModel.DataAnnotations;

namespace DatePickerHint.Models
{
    public class ProgramOfStudy
    {
        [Key]
        public int Id { get; set; } // Correct primary key name

        [Required]
        public string Name { get; set; } = string.Empty;
    }

}
