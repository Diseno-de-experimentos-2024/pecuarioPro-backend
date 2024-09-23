using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Commands;
using PecuarioProPlatform.API.InventoryManagement.Domain.Model.ValueObjects;
using PecuarioProPlatform.API.InventoryManagement.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.InventoryManagement.Interfaces.REST.Transform;

public static class AddMedicineToInventoryCommandFromResourceAssembler
{
    public static CreateMedicineCommand ToCommandFromResource(AddMedicineToInventoryResource resource)
    {
        EStatus statusEnum;

        statusEnum = (EStatus)Enum.Parse(typeof(EStatus), resource.status, true);

        
        return new CreateMedicineCommand(resource.inventoryId,
            resource.name,
            resource.expirationDate,
            resource.supplier,
            resource.volume,
            statusEnum);
    }
}