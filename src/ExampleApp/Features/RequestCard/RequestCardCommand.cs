using ExampleApp.Domain.Cards;

namespace ExampleApp.Features.RequestCard;

public sealed record RequestCardCommand(Guid CreditId, CardType CardType);
