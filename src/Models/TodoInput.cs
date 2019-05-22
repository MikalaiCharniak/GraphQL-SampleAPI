using GraphQL.Types;

namespace TodoAPI.Models
{
    public class TodoInput : InputObjectGraphType
    {
        public TodoInput()
        {
            Name = "TodoInput";
            Field<IntGraphType>("id");
            Field<StringGraphType>("description");
            Field<BooleanGraphType>("status");
        }
    }
}
