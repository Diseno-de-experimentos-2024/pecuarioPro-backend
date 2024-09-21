using PecuarioProPlatform.API.InventoryManagement.Domain.Model.ValueObjects;

namespace PecuarioProPlatform.API.InventoryManagement.Domain.Model.Commands;

public record CreateToolCommand(
    string Name,
    double UnitPrice,
    double Quantity,
    DateOnly PurchaseDate,
    string Supplier,
    EStatus Status,
    EToolCondition Condition
);