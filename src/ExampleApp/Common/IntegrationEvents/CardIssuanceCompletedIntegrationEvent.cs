namespace ExampleApp.Common.IntegrationEvents;

public sealed record CardIssuanceCompletedIntegrationEvent(
    Guid CardId,
    string PanNumber,
    DateTime ExpiryDate);
