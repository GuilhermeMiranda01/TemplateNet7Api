using MediatR;

namespace Application.TodoFeatures.Commands.CreateTodo
{
    public class CreateTodoCommand : IRequest<Unit>
    {
        public string? Description { get; set; }
        public DateTime Created { get; set; }
    }
}
