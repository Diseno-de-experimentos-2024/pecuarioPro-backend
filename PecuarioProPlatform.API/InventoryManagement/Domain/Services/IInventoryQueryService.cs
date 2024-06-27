using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Aggregates;
using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Queries;


namespace PecuarioProPlatform.API.InventoryManagement.Domain.Services;

public interface IInventoryQueryService
{
    Task<Inventory?> Handle(GetInventoryByIdQuery query);
    Task<Inventory?> Handle(GetInventoryByProductName query);
    Task<IEnumerable<Inventory>> Handle(GetAllInvetoryQuery query);
}