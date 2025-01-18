using System.Threading;
using System.Threading.Tasks;

namespace TopDrawer.DomainEvents.Abstractions
{
    public interface IDomainEventHandler<in TDomainEvent> where TDomainEvent : IDomainEvent
    {
        Task HandleAsync(TDomainEvent domainEvent, CancellationToken cancellationToken);
    }
}
