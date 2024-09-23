using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Commands;
using PecuarioProPlatform.API.InventoryManagement.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.InventoryManagement.Interfaces.REST.Transform;

public static class CreateInventoryCommandFromResourceAssembler
{
    public static CreateInventoryCommand ToCommandFromResource(CreateInventoryResource resource)
    {
        return new CreateInventoryCommand(resource.userId);
    }
}