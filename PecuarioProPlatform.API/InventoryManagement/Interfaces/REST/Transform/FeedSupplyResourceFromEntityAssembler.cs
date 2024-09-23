using Microsoft.OpenApi.Extensions;
using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Entities;
using PecuarioProPlatform.API.InventoryManagement.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.InventoryManagement.Interfaces.REST.Transform;

public static class FeedSupplyResourceFromEntityAssembler
{
    public static FeedSupplyResource ToResourceFromEntity(FeedSupply entity)
    {
        return new FeedSupplyResource(entity.Id, entity.Name, entity.UnitPrice, entity.Quantity, entity.TotalPrice,
            entity.PurchaseDate, entity.Supplier, entity.UnitOfMeasurement, entity.Status.GetDisplayName());
    }
}