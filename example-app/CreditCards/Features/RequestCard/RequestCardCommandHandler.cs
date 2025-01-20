using CreditCards.Domain.Cards;
using CreditCards.Domain.Credits;

namespace CreditCards.Features.RequestCard;

public sealed class RequestCardCommandHandler(ICreditRepository creditRepository, ICardRepository cardRepository)
{
    public async Task Handle(RequestCardCommand command, CancellationToken cancellationToken)
    {
        var credit = await creditRepository.LoadCreditById(command.CreditId, cancellationToken);
        var creditHasCards = await creditRepository.HasAnyCards(command.CreditId, cancellationToken);
        var card = Card.Create(credit, creditHasCards, command.CardType);
        cardRepository.AddCard(card);
    }
}
