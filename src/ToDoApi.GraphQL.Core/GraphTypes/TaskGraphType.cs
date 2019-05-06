using GraphQL.Types;
using ToDoApi.Models;

namespace ToDoApi.GraphQL.Core.GraphTypes
{
    public class TaskGraphType : ObjectGraphType<Task>
    {
        public TaskGraphType()
        {
            Name = "TaskGraphType";
            Field("id", x => x.TaskId, type: typeof(IdGraphType)).Description("Id of task");
            Field("description", x => x.Description, type: typeof(StringGraphType)).Description("Describe task essence");
            Field("status",x => x.Status, type: typeof(BooleanGraphType)).Description("Complete task or not");
        }
    }
}
