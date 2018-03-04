using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.ViewModels.Validations
{
    public class QuestionViewValidator:AbstractValidator<QuestionViewModel>
    {
        public QuestionViewValidator()
        {
            RuleFor(vm => vm.Questiontype).NotEmpty().WithMessage("Question Type cannot be empty");
            RuleFor(vm => vm.Subject).NotEmpty().WithMessage("Subject cannot be empty");
            RuleFor(vm => vm.Questiontext).NotEmpty().WithMessage("Question Text cannot be empty");
            //RuleFor(vm => vm.Options.Length).LessThan(4).WithMessage("Question should have at least 4 options.");
            RuleFor(vm => vm.Difficulty).NotEmpty().WithMessage("Difficulty cannot be empty.");

        }
    
    }
}
