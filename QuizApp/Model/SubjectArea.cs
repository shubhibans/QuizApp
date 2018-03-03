using System.ComponentModel.DataAnnotations;

namespace QuizApp.Model
{
    public class SubjectArea
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Area { get; set; }
    }
}