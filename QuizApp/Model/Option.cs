using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Model
{
    public class Option
    {
        public int Id { get; set; }
        [Required]
        public string Body { get; set; }
        public bool IsAnswer { get; set; }
        public bool Selected { get; set; }
        [Required]
        public Question Question { get; set; }
    }
}
