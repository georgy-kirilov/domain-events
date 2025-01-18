using Sandbox;
using TopDrawer.DomainEvents;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDomainEventHandlers(handlers =>
{
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
