using Application.Exceptions;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.TodoFeatures.Commands.CreateTodo
{
    public class CreateTodoHandler : IRequestHandler<CreateTodoCommand, Unit>
    {
        private readonly ITodoRepository _repository;
        private readonly IMapper _mapper;
        public CreateTodoHandler(ITodoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateTodoValidator();

            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if(!validationResult.IsValid) 
                throw new BadRequestException("Invalid request", validationResult);

            request.Created = DateTime.Now;
            await _repository.InsertTodo(_mapper.Map<Todo>(request));

            return Unit.Value;
        }

    }
}
