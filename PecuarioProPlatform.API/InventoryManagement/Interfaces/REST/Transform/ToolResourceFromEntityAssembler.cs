using Microsoft.OpenApi.Extensions;
using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Entities;
using PecuarioProPlatform.API.InventoryManagement.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.InventoryManagement.Interfaces.REST.Transform;

public static class ToolResourceFromEntityAssembler
{
    public static ToolResource ToResourceFromEntity(Tool entity)
    {
        return new ToolResource(entity.Id, entity.Name, entity.UnitPrice, entity.Quantity, entity.TotalPrice,
            entity.PurchaseDate, entity.Supplier, entity.Status.GetDisplayName(), entity.Condition.GetDisplayName());
    }
    public static ICollection<ToolResource> ToResourceFromEntity(ICollection<Tool> entities)
    {
        return entities.Select(ToResourceFromEntity).ToList(); 
    }
}