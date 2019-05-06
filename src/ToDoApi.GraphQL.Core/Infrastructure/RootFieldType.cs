using GraphQL.Types;

namespace ToDoApi.GraphQL.Core.Infrastructure
{
    public abstract class RootFieldType<TGraphType, TSourceType> : FieldType where TGraphType : IGraphType
    {
        protected RootFieldType(string name, string description)
        {
            Name = name;
            Description = description;
            Type = typeof(TGraphType);
            Description = description;
        }

        protected abstract TSourceType Resolve(ResolveFieldContext context);
    }
}
