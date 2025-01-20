using CreditCards.Common.Abstractions;

namespace CreditCards.Domain.Cards.Plastics;

public sealed class CardPlastic : BaseEntity
{
    private CardPlastic() { }
    
    public required Guid CardPlasticId { get; init; }
    
    public required Guid CardId { get; init; }
    
    public CardPlasticLocation Location { get; private set; }
    
    public static CardPlastic Create(Card card)
    {
        if (!card.Type.SupportsPlastic())
        {
            throw new ApplicationException("Card type does not support a plastic.");
        }
        
        if (card.Status != CardStatus.Issued)
        {
            throw new ApplicationException("Card must be issued.");
        }
        
        var plastic = new CardPlastic
        {
            CardPlasticId = Guid.NewGuid(),
            CardId = card.CardId,
            Location = CardPlasticLocation.Manufacturer,
        };
        
        return plastic;
    }
}
