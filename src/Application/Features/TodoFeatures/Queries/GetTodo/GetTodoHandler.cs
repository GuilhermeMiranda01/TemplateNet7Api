using Application.Exceptions;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.TodoFeatures.Queries.GetTodo
{
    internal class GetTodoHandler : IRequestHandler<GetTodoQuery, GetTodoDTO>
    {
        private readonly ITodoRepository _repository;
        private readonly IMapper _mapper;
        public GetTodoHandler(ITodoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }
        public async Task<GetTodoDTO> Handle(GetTodoQuery request, CancellationToken cancellationToken)
        {
            var todo = await _repository.GetTodo(request.Id);

            return todo == null ? throw new NotFoundException("Item does not exist") : _mapper.Map<GetTodoDTO>(todo);
        }
    }
}
