using TodoAPI.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace TodoAPI.Data
{
    public interface ITodoRepository
    {
        Task<Todo> GetTodoById(int id);
        Task<List<Todo>> GetTodos();
        Task<List<Todo>> GetTodoByStatus(bool status);
        Task<Todo> AddTodo(Todo todo);
    }
}