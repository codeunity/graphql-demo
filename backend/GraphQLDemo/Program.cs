using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Altair;
using GraphQLDemo;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("default", p =>
    {
        p.AllowAnyOrigin();
        p.AllowAnyMethod();
    });
});

GraphQL.MicrosoftDI.GraphQLBuilderExtensions
    .AddGraphQL(builder.Services)
    .AddServer(false)
    .AddSystemTextJson()
    .AddWebSockets()
    .AddDocumentExecuter<SubscriptionDocumentExecuter>()
    .AddGraphTypes()
    .AddSchema<DemoSchema>();

var app = builder.Build();

const string subscriptionsEndpoint = "/subscriptions";
const string graphQLEndPoint = "/graphql";

app.UseCors("default");
app.UseWebSockets();
app.UseGraphQLWebSockets<DemoSchema>(subscriptionsEndpoint);
app.UseGraphQL<DemoSchema>(graphQLEndPoint);
app.UseGraphQLAltair(new AltairOptions { SubscriptionsEndPoint = subscriptionsEndpoint, GraphQLEndPoint = graphQLEndPoint });

app.Run();