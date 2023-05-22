using Application.Exceptions;
using Application.Features.TodoFeatures.Commands.UpdateTodo;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.TodoFeatures.Commands.UpdateTodo
{
    internal class UpdateTodoHandler : IRequestHandler<UpdateTodoCommand, Unit>
    {
        private readonly ITodoRepository _repository;
        private readonly IMapper _mapper;
        public UpdateTodoHandler(ITodoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateTodoValidator();

            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new BadRequestException("Invalid request", validationResult);

            if (await _repository.GetTodo(request.Id) == null)
                throw new NotFoundException("Item does not exist");

            await _repository.UpdateTodo(_mapper.Map<Todo>(request));
            return Unit.Value;
        }
    }
}
