using MediatR;

namespace Application.Features.TodoFeatures.Commands.UpdateTodo
{
    public class UpdateTodoCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string? Description { get; set; }
    }
}
