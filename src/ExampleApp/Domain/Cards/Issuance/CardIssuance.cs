using ExampleApp.Common.Abstractions;

namespace ExampleApp.Domain.Cards.Issuance;

public sealed class CardIssuance : BaseEntity
{
    private CardIssuance() { }
    
    public required Guid CardIssuanceId { get; init; }
    
    public required Guid CardId { get; init; }
    
    public required Guid UserId { get; init; }
    
    public required DateTime RequestedAtUtc { get; init; }
    
    public DateTime? CompletedAtUtc { get; private set; }

    public string? PanNumber { get; private set; }
    
    public DateTime? ExpiryDate { get; private set; }
    
    public bool Complete(Card card, string panNumber, DateTime expiryDate)
    {
        if (card.Status != CardStatus.Requested)
        {
            return false;
        }
        
        if (CompletedAtUtc is not null)
        {
            return false;
        }
        
        CompletedAtUtc = DateTime.UtcNow;
        PanNumber = panNumber;
        ExpiryDate = expiryDate;
        card.ChangeStatus(CardStatus.Issued);
        RaiseDomainEvent(new CardIssuanceCompletedDomainEvent(CardId));
        return true;
    }
    
    public static CardIssuance Create(Guid cardId, Guid userId)
    {
        var cardIssuance = new CardIssuance
        {
            CardIssuanceId = Guid.NewGuid(),
            CardId = cardId,
            UserId = userId,
            RequestedAtUtc = DateTime.UtcNow,
        };
        
        return cardIssuance;
    }
}
