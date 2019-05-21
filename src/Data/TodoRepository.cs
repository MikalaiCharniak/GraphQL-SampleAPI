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
                new Todo(){Id=1,Description="Buy Milk",Status=false},
                new Todo(){Id=2,Description="Buy Chocolate",Status=false},
                new Todo(){Id=3,Description="Meet CEO",Status=true},
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
    }
}