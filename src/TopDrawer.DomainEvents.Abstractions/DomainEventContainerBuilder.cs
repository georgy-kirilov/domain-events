namespace TopDrawer.DomainEvents.Abstractions
{
    public sealed class DomainEventContainerBuilder
    {
        internal DomainEventContainer Container { get; } = new DomainEventContainer();

        public DomainEventContainerBuilder Add<TDomainEvent, TDomainEventHandler>()
            where TDomainEvent : IDomainEvent 
            where TDomainEventHandler : IDomainEventHandler<TDomainEvent>
        {
            Container.Add<TDomainEvent, TDomainEventHandler>();
            return this;
        }
    }
}
