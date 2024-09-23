using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Aggregates;
using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Entities;
using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Queries;
using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Queries.FeedSupplyQueries;
using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Queries.MedicineQueries;
using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Queries.ToolQueries;
using PecuarioProPlatform.API.InventoryManagement.Domain.Repositories;
using PecuarioProPlatform.API.InventoryManagement.Domain.Services;

namespace PecuarioProPlatform.API.InventoryManagement.Application.Internal.QueryServices;

public class InventoryQueryService(IInventoryRepository inventoryRepository) : IInventoryQueryService
{
    public async Task<IEnumerable<Inventory>> Handle(GetAllInventoriesQuery query)
    {
        return await inventoryRepository.ListAsync();
    }

    public async Task<IEnumerable<Inventory>> Handle(GetAllInventoriesByUserIdQuery query)
    {
        return await inventoryRepository.FindInventoryByUserIdAsync(query.UserId);
    }

    public async Task<IEnumerable<FeedSupply>> Handle(GetAllFeedSupplyByInventoryIdQuery query)
    {
        return await inventoryRepository.FindFeedSupplyByInventoryIdAsync(query.InventoryId);
    }

    public async Task<IEnumerable<Medicine>> Handle(GetAllMedicinesByInventoryIdQuery query)
    {
        return await inventoryRepository.FindMedicineByInventoryIdAsync(query.InventoryId);
    }

    public async Task<IEnumerable<Tool>> Handle(GetAllToolsByInvetoryIdQuery query)
    {
        return await inventoryRepository.FindToolByInventoryIdAsync(query.InventoryId);
        
    }

    public async Task<Tool?> Handle(GetToolByIdQuery query)
    {
        return await inventoryRepository.FindToolByIdAndInventoryIdAsync(query.ToolId,query.InventoryId);
    }

    public async Task<Medicine?> Handle(GetMedicineByIdQuery query)
    {
        return await inventoryRepository.FindMedicineByIdAndInventoryIdAsync(query.MedicineId, query.InventoryId);
    }

    public async Task<FeedSupply?> Handle(GetFeedSupplyByIdQuery query)
    {
        return await inventoryRepository.FindFeedSupplyByIdAndInventoryIdAsync(query.FeedSupplyId, query.InventoryId);
    }

    public async Task<Inventory?> Handle(GetInventoryByIdQuery query)
    {
        return await inventoryRepository.FindByIdAsync(query.Id);
    }
}