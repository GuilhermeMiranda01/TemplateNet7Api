using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ITodoRepository
    {
        Task<List<Todo>> GetTodos();
        Task<Todo> GetTodo(int id);
        Task UpdateTodo(Todo todo);
        Task DeleteTodo(int id);
        Task InsertTodo(Todo todo);
    }
}
