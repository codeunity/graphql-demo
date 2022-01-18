using GraphQL.Types;

namespace GraphQLDemo;

public class DemoQuery : ObjectGraphType
{
    public DemoQuery()
    {
        Field<StringGraphType>()
            .Name("currentDateTime")
            .Resolve(ctx => DateTimeOffset.Now.ToString("s"));
    }
}
