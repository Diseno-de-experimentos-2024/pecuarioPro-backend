using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Aggregates;
using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Queries;
using PecuarioProPlatform.API.InventoryManagement.Domain.Repositories;
using PecuarioProPlatform.API.InventoryManagement.Domain.Services;


namespace PecuarioProPlatform.API.InventoryManagement.Application.Internal.QueryServices;

public class InventoryQueryService(IInvetoryRepository inventoryRepository) : IInventoryQueryService
{
    public async Task<Inventory?> Handle(GetInventoryByProductName query)
    {
        return await inventoryRepository.FindByProductName(query.ProductName);
    }

    public async Task<IEnumerable<Inventory>> Handle(GetAllInvetoryQuery query)
    {
        return await inventoryRepository.ListAsync();
    }

    public async Task<Inventory?> Handle(GetInventoryByIdQuery query)
    {
        return await inventoryRepository.FindByIdAsync(query.IdInventory);
    }
}
