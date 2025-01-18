using Sandbox;
using TopDrawer.DomainEvents;var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDomainEventHandlers(handlers =>
{
    handlers.Add<CardActivationCompletedDomainEvent, CardActivationCompletedDomainEventHandler>();
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();

public sealed class CardActivationCompletedDomainEvent : IDomainEvent;