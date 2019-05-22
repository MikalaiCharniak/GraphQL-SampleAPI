using GraphQL.Types;
using TodoAPI.Data;

namespace TodoAPI.Models
{
    public class TodoMutation : ObjectGraphType
    {

        public TodoMutation(ITodoRepository todoRepository)
        {
            Name = "Mutation";
            Field<TodoType>(
                    "createToDo",
                    arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<TodoInput>> { Name = "todoItem" }
                            ),
            resolve: context =>
            {
                var todo = context.GetArgument<Todo>("todoItem");
                return todoRepository.AddTodo(todo);
            });
        }
    }
}
