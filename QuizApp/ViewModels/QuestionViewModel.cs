using System.Collections.Generic;

namespace QuizApp.ViewModels
{
    public class QuestionViewModel
    {
        public string Questiontype { get; set; }
        public string Subject { get; set; }
        public string Questiontext { get; set; }
        public string[] Options1 { get; set; }
        public string Difficulty { get; set; }
    }
}