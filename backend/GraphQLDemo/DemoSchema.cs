using GraphQL.Types;

namespace GraphQLDemo;

public class DemoSchema : Schema
{
    public DemoSchema(DemoQuery demoQuery, DemoSubscription demoSubscription)
    {
        Query = demoQuery;
        Subscription = demoSubscription;
    }
}
