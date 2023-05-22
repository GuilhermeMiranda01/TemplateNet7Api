namespace Application.Features.TodoFeatures.Queries.GetTodo
{
    public class GetTodoDTO
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime Created { get; set; }
    }
}
