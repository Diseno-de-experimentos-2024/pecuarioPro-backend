using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Commands;
using PecuarioProPlatform.API.InventoryManagement.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.InventoryManagement.Interfaces.REST.Transform;

public static class AddToolToInventoryCommandFromResourceAssembler
{
    public static CreateToolCommand ToCommandFromResource(AddToolToInventoryResource resource)
    {
        return new CreateToolCommand(resource.inventoryId,
            resource.name, resource.unitPrice, resource.quantity, resource.purchaseDate,
            resource.supplier, resource.status, resource.condition);
    }
}