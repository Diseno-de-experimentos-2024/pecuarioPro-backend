using PecuarioProPlatform.API.InventoryManagement.Domain.Model.ValueObjects;

namespace PecuarioProPlatform.API.InventoryManagement.Domain.Model.Commands;

public record CreateMedicineCommand(
    string Name,
    DateOnly ExpirationDate,
    string Supplier,
    double Volume,
    EStatus Status
);