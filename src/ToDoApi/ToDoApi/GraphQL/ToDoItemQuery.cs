using System.Linq;
using GraphQL.Types;
using ToDoApi.Database;

namespace ToDoApi.GraphQL
{
    public class ToDoItemQuery : ObjectGraphType
    {
        public ToDoItemQuery(AppDbContext db)
        {
            Field<ToDoItemType>(
                "ToDoItem",
                arguments: new QueryArguments(
                    new QueryArgument<BooleanGraphType>()
                    {
                        Name = "status",
                        Description = "status"
                    }),
                resolve: context =>
                {
                    var status = context.GetArgument<bool>("status");
                    var task = db.ToDoItems.FirstOrDefault(x => x.Status == status);
                    return task;
                });
        }
    }
}
