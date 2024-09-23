using Microsoft.OpenApi.Extensions;
using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Entities;
using PecuarioProPlatform.API.InventoryManagement.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.InventoryManagement.Interfaces.REST.Transform;

public static class MedicineResourceFromEntityAssembler
{
    public static MedicineResource ToResourceFromEntity(Medicine entity)
    {
        return new MedicineResource(entity.Id, entity.Name, entity.ExpirationDate, entity.Supplier, entity.Volume,
            entity.Status.GetDisplayName());
    }
}