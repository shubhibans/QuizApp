using Microsoft.EntityFrameworkCore;
using QuizApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Persistence
{
    public class AppDBContext: DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {

        }

        public DbSet<Quiz> Quizzes { get; set; }

        public DbSet<QuizApp.Model.Question> Question { get; set; }

        public DbSet<QuizApp.Model.Difficulty> Difficulty { get; set; }

        public DbSet<QuizApp.Model.SubjectArea> SubjectArea { get; set; }

        public DbSet<QuizApp.Model.QuestionType> QuestionType { get; set; }

    }
}
