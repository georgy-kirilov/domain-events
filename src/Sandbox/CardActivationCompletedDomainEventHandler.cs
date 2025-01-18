using TopDrawer.DomainEvents;

public sealed class CardActivationCompletedDomainEventHandler : IDomainEventHandler<CardActivationCompletedDomainEvent>
{
    public Task HandleAsync(CardActivationCompletedDomainEvent domainEvent, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

public sealed class Credit
{
    public required int CreditId { get; init; }
    
    private Credit() { }
    
    public static async Task Create(
        CreateCreditDomainModel domainModel,
        ICreditRepository creditRepository,
        CancellationToken cancellationToken)
    {
        var credit = new Credit
        {
            CreditId = creditId,
        };
        
        await creditRepository.AddCredit(credit, cancellationToken);
    }
}

public interface ICreditRepository
{
    Task<Credit> LoadCredit(int creditId, CancellationToken cancellationToken);
    
    Task AddCredit(Credit credit, CancellationToken cancellationToken);
}

public sealed record CreateCreditDomainModel
{
    private CreateCreditDomainModel() { }

    public required 
    
    public sealed class Repository : ICreateCreditDomainModelRepository
    {
        
    }
}

public interface ICreateCreditDomainModelRepository
{
    
}