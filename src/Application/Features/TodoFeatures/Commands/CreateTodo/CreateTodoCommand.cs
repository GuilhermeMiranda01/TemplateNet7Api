using MediatR;

namespace Application.Features.TodoFeatures.Commands.CreateTodo
{
    public class CreateTodoCommand : IRequest<int>
    {
        public string? Description { get; set; }
    }
}
