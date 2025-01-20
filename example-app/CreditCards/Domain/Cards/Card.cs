using CreditCards.Common.Abstractions;
using CreditCards.Domain.Credits;

namespace CreditCards.Domain.Cards;

public sealed class Card : BaseEntity
{
    private Card() { }
    
    public required Guid CardId { get; init; }
    
    public required Guid CreditId { get; init; }
        
    public CardStatus Status { get; private set; }
    
    public required CardType Type { get; init; }

    public void ChangeStatus(CardStatus status)
    {
        Status = status;
    }
    
    public static Card Create(Credit credit, bool creditHasCards, CardType cardType)
    {
        if (creditHasCards)
        {
            throw new ApplicationException("Credit already has associated cards.");
        }
        
        if (credit.Status != CreditStatus.Active)
        {
            throw new ApplicationException("Credit must be active.");
        }
        
        if (!credit.ProposalSigned)
        {
            throw new ApplicationException("Credit proposal must be signed.");
        }
        
        var card = new Card
        {
            CardId = Guid.NewGuid(),
            CreditId = credit.CreditId,
            Status = CardStatus.Requested,
            Type = cardType,
        };
        
        card.RaiseDomainEvent(new CardRequestedDomainEvent(card.CardId));
        
        return card;
    }
}
