using System;
using System.Collections.Generic;
using GraphQL.Types;
using ToDoApi.GraphQL.Core.GraphTypes;
using ToDoApi.GraphQL.Core.Infrastructure;
using ToDoApi.Models;

namespace ToDoApi.GraphQL.Core.GraphQueris
{
    //public class TaskQuery : RootFieldType<TaskGraphType, Task> 
    //{
    //    public TaskQuery() : base("task", "search tasks")
    //    {
    //        QueryArgument[] queryArguments = new QueryArgument[2];
    //        queryArguments[0] = new QueryArgument<IdGraphType>()
    //        { Name = "id", Description = "task id" };
    //        queryArguments[1] = new QueryArgument<BooleanGraphType>()
    //        { Name = "status", Description = "bool value of complete or not complete task" };
    //    }

    //    protected override Task Resolve(ResolveFieldContext context)
    //    {
    //        var id = context.GetArgument<int?>("id");
    //        var status = context.GetArgument<bool>("status");
    //        return new Task() {TaskId = id.Value, Status = status  };
    //    }
    //}

    public class TaskQuery : ObjectGraphType<Task>
    {
        public TaskQuery()
        {


        }
    }
}
