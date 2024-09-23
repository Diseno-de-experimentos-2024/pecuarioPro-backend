using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Commands;
using PecuarioProPlatform.API.InventoryManagement.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.InventoryManagement.Interfaces.REST.Transform;

public static class AddFeedSupplyToInventoryCommandFromResourceAssembler
{
    public static CreateFeedSupplyCommand ToCommandFromResource(AddFeedSupplyToInventoryResource resource)
    {
        return new CreateFeedSupplyCommand(resource.inventoryId, resource.Name, resource.UnitPrice,
            resource.Quantity, resource.PurchaseDate, resource.Supplier,
            resource.UnitOfMeasurement, resource.Status);
    }
}