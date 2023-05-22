using Application.Features.TodoFeatures.Commands.CreateTodo;
using Application.Features.TodoFeatures.Commands.DeleteTodo;
using Application.Features.TodoFeatures.Commands.UpdateTodo;
using Application.Features.TodoFeatures.Queries.GetTodo;
using Application.Features.TodoFeatures.Queries.GetTodos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        // GET: TodoController
        private readonly IMediator _mediator;
        public TodoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<GetTodoDTO>>> Get()
        {
            var todo = await _mediator.Send(new GetTodosQuery());
            return Ok(todo);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<GetTodoDTO>> Get(int id)
        {
            var todo = await _mediator.Send(new GetTodoQuery(id));
            return Ok(todo);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Post(CreateTodoCommand todo)
        {
            var response = _mediator.Send(todo);
            return Created(nameof(Get), new {id = response.Result});
        }
        
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Put(UpdateTodoCommand todo)
        {
            await _mediator.Send(todo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteTodoCommand { Id = id });
            return NoContent();
        }

    }
}
