using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace QuizApp.Model
{
    public class SubjectArea
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Area { get; set; }
        [Required]
        [MaxLength(255)]
        public string SubArea { get; set; }

        public static implicit operator SubjectArea(Task<IActionResult> v)
        {
            throw new NotImplementedException();
        }
    }
}