using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Model
{
    public class Question
    {
        [Required]
        [Key]
        [MaxLength(255)]
        public string Id { get; set; }
        [Required]
        public string Question_txt { get; set; }
        [ForeignKey("QuestionType")]
        public int QuestionTypeId { get; set; }
        [Required]
        public QuestionType QuestionType { get; set; }
        [Required]
        [ForeignKey("SubjectArea")]
        public int SubjectAreaId { get; set; }
        [Required]
        public SubjectArea SubjectArea { get; set; }
        [Required]
        [ForeignKey("Difficulty")]
        public int DifficultyId { get; set; }
        [Required]
        public Difficulty Difficulty { get; set; }
        public bool Answered { get; set; }
        public ICollection<Option> Options { get; set; }
        [Required]
        public DateTime AddedDate { get; set; }
        public AppAdmin AddedBy { get; set; }

    }
}
