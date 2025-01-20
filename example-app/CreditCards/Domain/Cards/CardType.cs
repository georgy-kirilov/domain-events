namespace CreditCards.Domain.Cards;

public enum CardType
{
    Virtual,
    Plastic,
    VirtualWithPlastic,
}

public static class CardTypeExtensions
{
    public static bool SupportsPlastic(this CardType type)
    {
        return type is CardType.Plastic or CardType.VirtualWithPlastic;
    }
}
