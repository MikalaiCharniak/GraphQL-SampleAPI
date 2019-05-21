using GraphQL.Types;
using TodoAPI.Data;
namespace TodoAPI.Models
{
    class TodoType : ObjectGraphType<Todo>
    {
        public TodoType(ITodoRepository todoRepository)
        {
            Name = "TodoType";
            Field(x => x.Id, type: typeof(IntGraphType)).Description("todo ID.");
            Field(x => x.Description, type: typeof(StringGraphType)).Description("Describe todo task");
            Field(x => x.Status, type: typeof(StringGraphType)).
                Description("Bool type of successfully or not status of this todo item");
        }
    }
}