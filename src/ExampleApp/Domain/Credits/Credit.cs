using ExampleApp.Common.Abstractions;

namespace ExampleApp.Domain.Credits;

public sealed class Credit : BaseEntity
{
    private Credit() { }
    
    public required Guid CreditId { get; init; }
    
    public required bool ProposalSigned { get; init; }
    
    public required CreditStatus Status { get; init; }
    
    public required decimal Limit { get; init; }
    
    public required string ContractNumber { get; init; } 
}
