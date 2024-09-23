namespace PecuarioProPlatform.API.InventoryManagement.Interfaces.REST.Resources;

public record AddToolToInventoryResource(int inventoryId,
    string name,
    double unitPrice,
    double quantity,
    DateOnly purchaseDate,
    string supplier,
    string status,
    string condition);