using Application.Features.TodoFeatures.Queries.GetTodo;
using AutoMapper;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.TodoFeatures.Queries.GetTodos
{
    internal class GetTodosHandler : IRequestHandler<GetTodosQuery, List<GetTodoDTO>>
    {
        private readonly ITodoRepository _repository;
        private readonly IMapper _mapper;
        public GetTodosHandler(ITodoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }
        public async Task<List<GetTodoDTO>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
        {
            var todos = _mapper.Map<List<GetTodoDTO>>(await _repository.GetTodos());
            return todos;
        }
    }
}
