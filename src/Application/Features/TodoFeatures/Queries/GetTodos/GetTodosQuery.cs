using Application.Features.TodoFeatures.Queries.GetTodo;
using MediatR;

namespace Application.Features.TodoFeatures.Queries.GetTodos
{
    public record GetTodosQuery : IRequest<List<GetTodoDTO>>;
}
