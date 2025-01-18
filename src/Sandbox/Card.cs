using TopDrawer.DomainEvents;

namespace Sandbox;

public class Card : DomainEntity
{
    public int Id { get; private set; }

    public string Status { get; private set; } = "Issued";

    public void ChangeStatus(string status)
    {
        Status = status;
        RaiseDomainEvent(new CardStatusChangedDomainEvent
        {
            CardId = Id,
            NewStatus = status
        });
    }
}
