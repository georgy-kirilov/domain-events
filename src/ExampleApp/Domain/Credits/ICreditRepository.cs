namespace ExampleApp.Domain.Credits;

public interface ICreditRepository
{
    Task<Credit> LoadCreditById(Guid creditId, CancellationToken cancellationToken);
    
    Task<bool> HasAnyCards(Guid creditId, CancellationToken cancellationToken);
}
