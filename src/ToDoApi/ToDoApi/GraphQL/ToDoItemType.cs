using GraphQL.Types;
using ToDoApi.Database;
using ToDoApi.Models;

namespace ToDoApi.GraphQL
{
    public class ToDoItemType  : ObjectGraphType<ToDoItem>
    {
        public ToDoItemType()
        {
            Name = "ToDoItemType";
            Field(x => x.ToDoItemId, type: typeof(IdGraphType)).Description("The ID ToDo Item.");
            Field(x => x.Description).Description("Describe todo task");
            Field(x => x.Status).Description("Bool type of successfully or not status of this task");
        }
    }
}
