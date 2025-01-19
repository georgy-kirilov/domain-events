namespace ExampleApp.Domain.Cards;

public interface ICardRepository
{
    void AddCard(Card card);
    
    Task<Card> LoadCardById(Guid cardId, CancellationToken cancellationToken);
}
