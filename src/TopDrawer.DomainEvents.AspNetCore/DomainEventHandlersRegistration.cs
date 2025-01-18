using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using TopDrawer.DomainEvents.Abstractions;

namespace TopDrawer.DomainEvents.AspNetCore;

public static class DomainEventHandlersRegistration
{
    public static IServiceCollection AddDomainEventHandlers(
        this IServiceCollection services,
        Action<DomainEventContainerBuilder> configureBuilder)
    {
        var builder = new DomainEventContainerBuilder();
        configureBuilder(builder);
        RegisterDomainEventHandlers(builder.Container.GetAllHandlerTypes(), services, builder.Container);
        return services;
    }
    
    public static IServiceCollection AddDomainEventHandlersFromAssemblyContaining<T>(
        this IServiceCollection services)
    {
        RegisterDomainEventHandlers(typeof(T).Assembly.GetTypes(), services, new DomainEventContainer());
        return services;
    }
    
    public static IServiceCollection AddDomainEventHandlersFromAssemblies(this IServiceCollection services,
        params Assembly[] assemblies)
    {
        var types = assemblies.SelectMany(a => a.GetTypes());
        RegisterDomainEventHandlers(types, services, new DomainEventContainer());
        return services;
    }
    
    private static void RegisterDomainEventHandlers(
        IEnumerable<Type> types,
        IServiceCollection services,
        DomainEventContainer container)
    {
        services.AddSingleton(container);
        services.AddScoped<IDomainEventHandlerResolver, AspNetCoreDomainEventHandlerResolver>();
        
        foreach (var type in types)
        {
            if (!type.IsClass)
            {
                continue;
            }

            if (type.IsAbstract)
            {
                continue;
            }

            var domainEventHandlerInterface = type
                .GetInterfaces()
                .Where(i => i.IsGenericType)
                .SingleOrDefault(i => i.GetGenericTypeDefinition() == typeof(IDomainEventHandler<>));
            
            if (domainEventHandlerInterface is null)
            {
                continue;
            }

            var eventType = domainEventHandlerInterface.GenericTypeArguments.Single();
            services.AddScoped(type);
            container.Add(eventType, type);
        }
    }
}
