namespace CreditCards.Domain.Cards.Issuance;

public interface ICardIssuanceRepository
{
    void AddCardIssuance(CardIssuance cardIssuance);
    
    Task<CardIssuance> LoadCardIssuanceByCardId(Guid cardId, CancellationToken cancellationToken);
}
