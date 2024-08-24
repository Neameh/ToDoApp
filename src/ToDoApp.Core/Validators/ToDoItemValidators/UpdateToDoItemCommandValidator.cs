using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Logic.Commands.ToDoItemCommand;

namespace ToDoApp.Application.Validators.ToDoItemValidators
{
    public class UpdateToDoItemCommandValidator : AbstractValidator<UpdateToDoItemCommand>
    {
        public UpdateToDoItemCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title Could not be empty!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description Could not be empty!");
        }
    }
}
