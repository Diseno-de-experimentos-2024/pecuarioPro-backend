using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Aggregates;
using PecuarioProPlatform.API.InventoryManagement.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.InventoryManagement.Interfaces.REST.Transform;

public static class InventoryResourceFromEntityAssembler
{
    public static InventoryResource ToResourceFromEntity(Inventory inventory)
    {
        return new InventoryResource(inventory.Id,inventory.UserId.Identifier, inventory.Tools,inventory.FeedSupplies, inventory.Medicines
            );
    }
}