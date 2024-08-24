using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Logic.Commands.ToDoItemCommand;

namespace ToDoApp.Application.Validators.ToDoItemValidators
{
    public class AddToDoItemCommandValidator : AbstractValidator<AddToDoItemCommand>
    {
        public AddToDoItemCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title could not be empty!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description could not be empty!");
            // TO DO : Check the validation for IsComplete prop.
        }
    }
}
