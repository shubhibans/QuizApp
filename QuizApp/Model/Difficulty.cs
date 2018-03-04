using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace QuizApp.Model
{
    public class Difficulty
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string DifficultyLevel { get; set; }

        public static implicit operator Difficulty(Task<IActionResult> v)
        {
            throw new NotImplementedException();
        }

        public static explicit operator Difficulty(Task<Difficulty> v)
        {
            throw new NotImplementedException();
        }
    }
}