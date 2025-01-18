using Microsoft.EntityFrameworkCore;
using Sandbox;
using TopDrawer.DomainEvents;
using TopDrawer.DomainEvents.Abstractions;
using TopDrawer.DomainEvents.AspNetCore;
using TopDrawer.DomainEvents.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>((sp, x) =>
{
    x.UseSqlServer(
        "Server=localhost,1434; Database=domainevents; User Id=sa; Password=Qwerty1@; TrustServerCertificate=True;");

    x.AddInterceptors(
        new PublishDomainEventsInterceptor(sp.GetRequiredService<IDomainEventHandlerResolver>()));
});

builder.Services.AddDomainEventHandlersFromAssemblyContaining<Program>();

var app = builder.Build();

await using var scope = app.Services.CreateAsyncScope();
await using var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
await context.Database.EnsureDeletedAsync();
await context.Database.EnsureCreatedAsync();

app.MapGet("/add-card", async (AppDbContext db) =>
{
    var card = new Card();
    db.Cards.Add(card);
    await db.SaveChangesAsync();
    return card.Id;
});

app.MapGet("/activate/{cardId:int}", async (int cardId, AppDbContext db) =>
{
    var card = db.Cards.Single(c => c.Id == cardId);
    card.ChangeStatus("Activated");
    await db.SaveChangesAsync();
});

app.Run();
