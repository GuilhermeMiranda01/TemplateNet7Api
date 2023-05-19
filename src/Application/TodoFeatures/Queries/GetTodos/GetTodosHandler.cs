using AutoMapper;
using Domain.Interfaces;
using MediatR;

namespace Application.TodoFeatures.Queries.GetTodos
{
    internal class GetTodosHandler : IRequestHandler<GetTodosQuery, List<GetTodosDTO>>
    {
        private readonly ITodoRepository _repository;
        private readonly IMapper _mapper;
        public GetTodosHandler(ITodoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }
        public async Task<List<GetTodosDTO>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
        {
            var todos = _mapper.Map<List<GetTodosDTO>>(await _repository.GetTodos());
            return todos;
        }
    }
}
