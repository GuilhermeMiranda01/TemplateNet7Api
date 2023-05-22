using MediatR;

namespace Application.Features.TodoFeatures.Commands.DeleteTodo
{
    public class DeleteTodoCommand: IRequest<Unit>
    {
        public int Id { get; set;}
    }
}
