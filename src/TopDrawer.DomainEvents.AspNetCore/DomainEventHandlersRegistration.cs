using Microsoft.Extensions.DependencyInjection;

namespace TopDrawer.DomainEvents.AspNetCore;

public static class DomainEventHandlersRegistration
{
    public static IServiceCollection AddDomainEventHandlers(
        this IServiceCollection services,
        Action<DomainEventServiceContainerBuilder> configureBuilder)
    {
        var builder = new DomainEventServiceContainerBuilder();
        
        configureBuilder(builder);

        foreach (var handlerType in builder.Container.GetAllHandlerTypes())
        {
            services.AddScoped(handlerType);
        }
        
        services.AddSingleton(builder.Container);
        services.AddScoped<IDomainEventHandlerResolver, AspNetCoreDomainEventHandlerResolver>();
        
        return services;
    }
}
