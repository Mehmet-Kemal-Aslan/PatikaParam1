using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentWebApi.Models
{
    public class Student
    {
        [Key]
        [Required(ErrorMessage = "Id is required.")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Surname is required.")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Grade is required.")]
        public int Grade { get; set; }
        public string Note { get; set; }
        [ForeignKey ("Project")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
