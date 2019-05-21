using GraphQL.Types;
using TodoAPI.Data;
using System.Collections.Generic;

namespace TodoAPI.Models
{
    public class TodoQuery : ObjectGraphType
    {
        public TodoQuery(ITodoRepository todoRepository)
        {
            Field<ListGraphType<TodoType>>("todo", arguments: new QueryArguments(
                new QueryArgument<IntGraphType> { Name = "id", Description = "id of todo" },
                new QueryArgument<BooleanGraphType> {Name = "status" , Description = "Boolean status of todo item" }
            ),
            resolve: context =>
            {
                var id = context.GetArgument<int?>("id");
                if (id.HasValue)
                {
                    return todoRepository.GetTodoById(id.Value);
                }
                var status = context.GetArgument<bool?>("status");
                if (status.HasValue)
                {
                    return todoRepository.GetTodoByStatus(status.Value).Result;
                }
                return new List<TodoType>();
            });
          
           

            Field<ListGraphType<TodoType>>("todos",
            resolve: context => todoRepository.GetTodos().Result
            );

        }
    }
}