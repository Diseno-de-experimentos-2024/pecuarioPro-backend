namespace PecuarioProPlatform.API.InventoryManagement.Interfaces.REST.Resources;

public record MedicineResource(int Id, string Name, DateOnly ExpirationDate, string Supplier,
    double Volume, string Status );