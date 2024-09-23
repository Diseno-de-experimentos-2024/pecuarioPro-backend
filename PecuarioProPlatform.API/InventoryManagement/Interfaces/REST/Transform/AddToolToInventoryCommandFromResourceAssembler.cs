using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Commands;
using PecuarioProPlatform.API.InventoryManagement.Domain.Model.ValueObjects;
using PecuarioProPlatform.API.InventoryManagement.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.InventoryManagement.Interfaces.REST.Transform;

public static class AddToolToInventoryCommandFromResourceAssembler
{
    public static CreateToolCommand ToCommandFromResource(AddToolToInventoryResource resource)
    {
        EStatus statusEnum;

        statusEnum = (EStatus)Enum.Parse(typeof(EStatus), resource.status, true);
        
        EToolCondition conditionEnum;
        conditionEnum = (EToolCondition)Enum.Parse(typeof(EToolCondition), resource.condition, true);

        
        
        return new CreateToolCommand(resource.inventoryId,
            resource.name, resource.unitPrice, resource.quantity, resource.purchaseDate,
            resource.supplier, statusEnum, conditionEnum);
    }
}