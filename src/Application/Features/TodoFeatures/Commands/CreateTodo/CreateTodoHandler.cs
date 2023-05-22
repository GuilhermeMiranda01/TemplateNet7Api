using Application.Exceptions;
using Application.Features.TodoFeatures.Commands.CreateTodo;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.TodoFeatures.Commands.CreateTodo
{
    public class CreateTodoHandler : IRequestHandler<CreateTodoCommand, int>
    {
        private readonly ITodoRepository _repository;
        private readonly IMapper _mapper;
        public CreateTodoHandler(ITodoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateTodoValidator();

            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new BadRequestException("Invalid request", validationResult);

            var todo = _mapper.Map<Todo>(request);
            todo.Created = DateTime.Now;
            await _repository.InsertTodo(todo);

            return todo.Id;
        }

    }
}
