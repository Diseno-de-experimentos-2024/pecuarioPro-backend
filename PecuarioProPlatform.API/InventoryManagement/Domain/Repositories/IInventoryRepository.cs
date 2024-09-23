using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Aggregates;
using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Entities;
using PecuarioProPlatform.API.Shared.Domain.Repositories;

namespace PecuarioProPlatform.API.InventoryManagement.Domain.Repositories;

public interface IInventoryRepository : IBaseRepository<Inventory>
{
    Task<IEnumerable<Inventory>> FindInventoryByUserIdAsync(int userId);

    Task<IEnumerable<FeedSupply>> FindFeedSupplyByInventoryIdAsync(int inventoryId);

    Task<IEnumerable<Tool>> FindToolByInventoryIdAsync(int inventoryId);

    Task<IEnumerable<Medicine>> FindMedicineByInventoryIdAsync(int inventoryId);

    Task<Medicine?> FindMedicineByIdAndInventoryIdAsync(int medicineId, int inventoryId);

    Task<Tool?> FindToolByIdAndInventoryIdAsync(int toolId, int inventoryId);

    Task<FeedSupply?> FindFeedSupplyByIdAndInventoryIdAsync(int feedSupplyId, int inventoryId);



}