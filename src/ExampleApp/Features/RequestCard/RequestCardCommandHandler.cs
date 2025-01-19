using ExampleApp.Domain.Cards;
using ExampleApp.Domain.Credits;

namespace ExampleApp.Features.RequestCard;

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
