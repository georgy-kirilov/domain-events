namespace TopDrawer.DomainEvents.Abstractions
{
    public sealed class DomainEventServiceContainerBuilder
    {
        internal DomainEventServiceContainer ServiceContainer { get; } = new DomainEventServiceContainer();

        public DomainEventServiceContainerBuilder Add<TDomainEvent, TDomainEventHandler>()
            where TDomainEvent : IDomainEvent 
            where TDomainEventHandler : IDomainEventHandler<TDomainEvent>
        {
            ServiceContainer.Add(typeof(TDomainEvent), typeof(TDomainEventHandler));
            return this;
        }
    }
}
