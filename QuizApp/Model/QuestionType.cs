using System.ComponentModel.DataAnnotations;

namespace QuizApp.Model
{
    public class QuestionType
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Type { get; set; }
        [MaxLength(255)]
        public string NormalizedType { get; set; }
    }
}