using System.ComponentModel.DataAnnotations;

namespace QuizApp.Model
{
    public class Difficulty
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string DifficultyLevel { get; set; }
    }
}