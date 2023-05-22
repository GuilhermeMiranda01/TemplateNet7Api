using MediatR;

namespace Application.Features.TodoFeatures.Queries.GetTodo
{
    public record GetTodoQuery(int Id) : IRequest<GetTodoDTO>;
}
