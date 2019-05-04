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
                    new QueryArgument<IdGraphType>()
                    {
                        Name = "id",
                        Description = "Unique Id of concrete task"
                    }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    var task = db.ToDoItems.FirstOrDefault(x => x.ToDoItemId == id);
                    return task;
                });
        }
    }
}
