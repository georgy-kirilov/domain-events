using CreditCards.Domain.Cards;

namespace CreditCards.Features.RequestCard;

public sealed record RequestCardCommand(Guid CreditId, CardType CardType);
