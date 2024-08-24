using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Logic.Commands.ToDoItemCommand;

namespace ToDoApp.Application.Validators
{
    public class AddToDoItemCommandValidators : AbstractValidator<AddToDoItemCommand>
    {
        public AddToDoItemCommandValidators()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title could not be empty!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description could not be empty!");
            // TO DO : Check the validatione for IsComplete prop.
        }
    }
}
