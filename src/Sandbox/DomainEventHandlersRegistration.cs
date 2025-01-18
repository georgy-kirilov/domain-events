using TopDrawer.DomainEvents;

namespace Sandbox;

public static class DomainEventHandlersRegistration
{
    public static IServiceCollection AddDomainEventHandlers(
        this IServiceCollection services,
        Action<DomainEventOptions> configureOptions)
    {
        var options = new DomainEventOptions();
        
        configureOptions(options);
        
        
        
        return services;
    }
}
