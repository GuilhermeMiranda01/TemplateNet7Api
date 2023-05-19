using Application.TodoFeatures;
using Application.TodoFeatures.Queries.GetTodos;
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

        //[HttpGet]
        //public async Task<List<TodoDTO>> Get()
        //{
        //    return await _mediator.Send(new GetTodosQuery());
        //}
        
        //[HttpPost]
        //[ProducesResponseType(201)]
        //[ProducesResponseType(400)]
        //public async Task<ActionResult> Post(CreateTodoCommand todo)
        //{
        //    await _mediator.Send(todo);
        //}

        // GET: TodoController/Details/5


        // GET: TodoController/Create
        //[HttpGet]
        //public ActionResult Create()
        //{
        //    return null;
        //}

    }
}
