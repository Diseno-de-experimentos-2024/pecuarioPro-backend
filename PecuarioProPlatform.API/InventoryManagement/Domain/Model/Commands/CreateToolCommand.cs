using PecuarioProPlatform.API.InventoryManagement.Domain.Model.ValueObjects;

namespace PecuarioProPlatform.API.InventoryManagement.Domain.Model.Commands;

public record CreateToolCommand(int InventoryId,
    string Name,
    double UnitPrice,
    double Quantity,
    DateOnly PurchaseDate,
    string Supplier,
    string Status,
    string Condition
);