namespace TopDrawer.DomainEvents.Abstractions
{
    public interface IHaveDomainEvents
    {
        DomainEventCollection GetDomainEvents();
    }
}
