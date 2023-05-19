using MediatR;

namespace Application.TodoFeatures.Queries.GetTodos
{
    public record GetTodosQuery : IRequest<List<GetTodosDTO>>;
}
