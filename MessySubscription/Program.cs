using MessySubscription.EventHandlers;
using MessySubscription.Mutations;
using MessySubscription.Queries;
using MessySubscription.Services;
using MessySubscription.Subscriptions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "MessySubscription", Version = "v1" });
});

// Set up GraphQL
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddSubscriptionType<Subscription>()
    .AddInMemorySubscriptions();  

// This is the fake background service
builder.Services.AddHostedService<ConsumablesService>();

// This is the internal event handler that publishes GraphQL "events" via the ITopicEventSender
builder.Services.AddSingleton<ConsumablesEventHandler>();

var app = builder.Build();

// Warm up the EventHandler, otherwise it won't react to anything
app.Services.GetService<ConsumablesEventHandler>();


app.UseRouting();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MessySubscription v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseWebSockets();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

app.Run();
