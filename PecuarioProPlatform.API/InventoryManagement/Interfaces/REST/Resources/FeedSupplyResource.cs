namespace PecuarioProPlatform.API.InventoryManagement.Interfaces.REST.Resources;

public record FeedSupplyResource(int Id, string Name, double UnitPrice, double Quantity,
    double TotalPrice, DateOnly PurchaseDate, string Supplier,string UnitOfMeasurement, string Status);