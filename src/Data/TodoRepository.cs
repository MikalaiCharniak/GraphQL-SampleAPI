using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using TodoAPI.Models;

namespace TodoAPI.Data
{
    public class TodoRepository : ITodoRepository
    {
        private List<Todo> _todos;
        public TodoRepository()
        {
            _todos = new List<Todo>(){
                new Todo(){Id=1,Description="Create presentation",Status=true},
                new Todo(){Id=2,Description="Show graphiQL",Status=false},
                new Todo(){Id=3,Description="Create demo",Status=true},
                new Todo(){Id=4,Description="Cook dinner",Status=false},
                new Todo(){Id=5,Description="Buy Shoes",Status=true}
            };
        }
        public Task<Todo> GetTodoById(int id)
        {
            return Task.FromResult(_todos.FirstOrDefault(x => x.Id == id));
        }
        public Task<List<Todo>> GetTodos()
        {
            return Task.FromResult(_todos);
        }

        public Task<List<Todo>> GetTodoByStatus(bool status)
        {
            return Task.FromResult(_todos.Where(x => x.Status == status).ToList());
        }

        public Task<Todo> AddTodo(Todo todo)
        {
            _todos.Add(todo);
            return Task.FromResult(todo);
        }
    }
}