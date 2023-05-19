using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoContext _context;
        public TodoRepository(TodoContext context)
        {
            _context = context;
        }
        public async Task<List<Todo>> GetTodos()
        {
            return await _context.Set<Todo>().ToListAsync();
        }
        public Task DeleteTodo(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Todo> GetTodo(int id)
        {
            throw new NotImplementedException();
        }


        public async Task InsertTodo(Todo todo)
        {
            await _context.Set<Todo>().AddAsync(todo);
            _context.SaveChanges();
        }

        public Task UpdateTodo()
        {
            throw new NotImplementedException();
        }
    }
}
