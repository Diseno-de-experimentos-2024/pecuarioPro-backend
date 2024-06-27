namespace PecuarioProPlatform.API.InventoryManagement.Domain.Model.Commands;

public record CreateInventoryCommand(string ProductName, string Quantity, string PhotoUrl);