namespace PecuarioProPlatform.API.InventoryManagement.Interfaces.REST.Resources;

public record AddMedicineToInventoryResource(int inventoryId, string name, DateOnly expirationDate,
    string supplier, double volume, string status);