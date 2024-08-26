using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Logic.Commands.ToDoListCommand;

namespace ToDoApp.Application.Validators.ToDoListValidators
{
    public class UpdateToDoListCommandValidator : AbstractValidator<UpdateToDoListCommand>
    {
        public UpdateToDoListCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title Could not be empty!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description Could not be empty!");
        }
    }
}
