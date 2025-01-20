using Microsoft.EntityFrameworkCore;
using TopDrawer.DomainEvents.Abstractions;
using TopDrawer.DomainEvents.EntityFrameworkCore;

namespace SandboxApp;

public sealed class SandboxDbContext(
    DbContextOptions<SandboxDbContext> options,
    IDomainEventHandlerInstanceResolver domainEventHandlerInstanceResolver) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(
            new PublishDomainEventsInterceptor(domainEventHandlerInstanceResolver));
    }
}
