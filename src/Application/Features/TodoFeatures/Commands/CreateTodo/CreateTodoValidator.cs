using FluentValidation;

namespace Application.Features.TodoFeatures.Commands.CreateTodo
{
    public class CreateTodoValidator : AbstractValidator<CreateTodoCommand>
    {
        public CreateTodoValidator()
        {
            RuleFor(t => t.Description)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(255).WithMessage("{PropertyName} must have less than 255 characters");
        }
    }
}
