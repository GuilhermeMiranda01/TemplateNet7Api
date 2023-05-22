using Domain.Interfaces;
using FluentValidation;

namespace Application.Features.TodoFeatures.Commands.UpdateTodo
{
    public class UpdateTodoValidator : AbstractValidator<UpdateTodoCommand>
    {
        public UpdateTodoValidator()
        {
            RuleFor(t => t.Id)
                .NotNull()
                .NotEqual(0).WithMessage("{PropertyName} is required.");

            RuleFor(t => t.Description)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(255).WithMessage("{PropertyName} must have less than 255 characters.");
        }
    }
}
