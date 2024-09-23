using PecuarioProPlatform.API.InventoryManagement.Domain.Model.ValueObjects;

namespace PecuarioProPlatform.API.InventoryManagement.Domain.Model.Commands;

public record CreateMedicineCommand(int InventoryId,
    string Name,
    DateOnly ExpirationDate,
    string Supplier,
    double Volume,
    string Status
);