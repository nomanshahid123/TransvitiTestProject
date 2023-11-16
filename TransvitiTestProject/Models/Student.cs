using System.ComponentModel.DataAnnotations;

namespace TransvitiTestProject.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public int Age { get; set; } = 0;
    }
}
