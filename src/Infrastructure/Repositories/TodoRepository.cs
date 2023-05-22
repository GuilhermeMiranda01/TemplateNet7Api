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
            return await _context.Set<Todo>().AsNoTracking().ToListAsync();
        }
        public async Task DeleteTodo(int id)
        {
            var todo = await GetTodo(id);
            _context.Set<Todo>().Remove(todo);
            await _context.SaveChangesAsync();
        }

        public async Task<Todo> GetTodo(int id)
        {
            return await _context.Set<Todo>().AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task InsertTodo(Todo todo)
        {
            await _context.Set<Todo>().AddAsync(todo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTodo(Todo todo)
        {
            _context.Set<Todo>().Update(todo);
            _context.Entry(todo).Property(x => x.Created).IsModified = false;
            await _context.SaveChangesAsync();
        }
    }
}
