using Application.Exceptions;
using AutoMapper;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.TodoFeatures.Commands.DeleteTodo
{
    public class DeleteTodoHandler : IRequestHandler<DeleteTodoCommand, Unit>
    {
        private readonly ITodoRepository _repository;

        public DeleteTodoHandler(ITodoRepository repository )
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
        {
            if (await _repository.GetTodo(request.Id) == null)
                throw new NotFoundException("Item does not exist");

            await _repository.DeleteTodo(request.Id);
            return Unit.Value;
        }
    }
}
