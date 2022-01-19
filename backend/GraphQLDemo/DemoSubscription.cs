using GraphQL.Types;
using System.Reactive.Linq;

namespace GraphQLDemo;

public class DemoSubscription : ObjectGraphType
{
    public DemoSubscription()
    {
        Field<StringGraphType>()
            .Name("currentDateTime")
            .Resolve(ctx => (ctx.Source as string)!)
            .Subscribe(ctx => Observable
                .Interval(TimeSpan.FromSeconds(1))
                .Select(x => DateTimeOffset.Now.ToString("s")));
    }
}

