namespace PecuarioProPlatform.API.InventoryManagement.Interfaces.REST.Resources;

public record AddFeedSupplyToInventoryResource(int inventoryId,string Name,
    double UnitPrice,
    double Quantity,
    DateOnly PurchaseDate,
    string Supplier,
    string UnitOfMeasurement,
    string Status );