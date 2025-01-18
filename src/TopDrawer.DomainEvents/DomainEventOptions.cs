namespace TopDrawer.DomainEvents
{
    public sealed class DomainEventOptions
    {
        public DomainEventOptions Add<TDomainEvent, TDomainEventHandler>()
            where TDomainEvent : IDomainEvent 
            where TDomainEventHandler : IDomainEventHandler<TDomainEvent>
        {
            return this;
        }
        
        public DomainEventOptions Register<TDomainEventHandler>(Type domainEventHandlerType)
        {
            return this;
        }
    }
}
