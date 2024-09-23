using PecuarioProPlatform.API.InventoryManagement.Domain.Model.ValueObjects;

namespace PecuarioProPlatform.API.InventoryManagement.Domain.Model.Commands;

public record CreateFeedSupplyCommand
(
    int InventoryId,
    string Name,
    double UnitPrice,
    double Quantity,
    DateOnly PurchaseDate,
    string Supplier,
    string UnitOfMeasurement,
    string Status
);