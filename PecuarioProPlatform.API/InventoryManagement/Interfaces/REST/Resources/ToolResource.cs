namespace PecuarioProPlatform.API.InventoryManagement.Interfaces.REST.Resources;

public record ToolResource(int Id, string Name, double UnitPrice,
    double Quantity, double TotalPrice, DateOnly PurchaseDate, 
    string Supplier, string Status, string Condition);