namespace TopDrawer.DomainEvents
{
    public sealed class DomainEventServiceContainerBuilder
    {
        public DomainEventContainer Container { get; } = new DomainEventContainer();

        public DomainEventServiceContainerBuilder Add<TDomainEvent, TDomainEventHandler>()
            where TDomainEvent : IDomainEvent 
            where TDomainEventHandler : IDomainEventHandler<TDomainEvent>
        {
            Container.Add<TDomainEvent, TDomainEventHandler>();
            return this;
        }
    }
}
