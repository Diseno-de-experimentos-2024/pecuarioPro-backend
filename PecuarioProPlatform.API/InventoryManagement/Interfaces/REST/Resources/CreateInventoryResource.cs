namespace PecuarioProPlatform.API.InventoryManagement.Interfaces.REST.Resources;

public record CreateInventoryResource(string ProductName, string Quantity, string PhotoUrl);