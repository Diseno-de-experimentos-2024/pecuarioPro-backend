using Microsoft.EntityFrameworkCore;
using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Aggregates;
using PecuarioProPlatform.API.InventoryManagement.Domain.Model.Entities;
using PecuarioProPlatform.API.InventoryManagement.Domain.Repositories;
using PecuarioProPlatform.API.Shared.Infraestructure.Persistence.EFC.Configuration;
using PecuarioProPlatform.API.Shared.Infraestructure.Persistence.EFC.Repositories;

namespace PecuarioProPlatform.API.InventoryManagement.Infrastructure.Persistence.EFC.Repositories;

public class InventoryRepository(AppDbContext context) : BaseRepository<Inventory>(context), IInventoryRepository
{
    public async Task<IEnumerable<Inventory>> FindInventoryByUserIdAsync(int userId)
    {
        return await context.Set<Inventory>()
            .Where(i => i.UserId.Identifier == userId)
            .Include(i => i.FeedSupplies)
            .Include(i => i.Tools)
            .Include(i => i.Medicines)
            .ToListAsync();
    }
    public async Task<IEnumerable<FeedSupply>> FindFeedSupplyByInventoryIdAsync(int inventoryId)
    {
        var inventory = await Context.Set<Inventory>().Include(i => i.FeedSupplies)
            .FirstOrDefaultAsync(i => i.Id == inventoryId);
        return inventory?.FeedSupplies ?? Enumerable.Empty<FeedSupply>();
    }

    public async Task<IEnumerable<Tool>> FindToolByInventoryIdAsync(int inventoryId)
    {
        var inventory = await Context.Set<Inventory>().Include(i => i.Tools)
            .FirstOrDefaultAsync(i => i.Id == inventoryId);
        return inventory?.Tools ?? Enumerable.Empty<Tool>();
    }

    public async Task<IEnumerable<Medicine>> FindMedicineByInventoryIdAsync(int inventoryId)
    {
        var inventory = await Context.Set<Inventory>().Include(i => i.Medicines)
            .FirstOrDefaultAsync(i => i.Id == inventoryId);
        return inventory?.Medicines ?? Enumerable.Empty<Medicine>();
    }

    public async Task<Medicine?> FindMedicineByIdAndInventoryIdAsync(int medicineId, int inventoryId)
    {
        var inventory = await context.Set<Inventory>()
            .Include(i => i.Medicines)
            .FirstOrDefaultAsync(i => i.Id == inventoryId);

        return inventory?.Medicines.FirstOrDefault(m => m.Id == medicineId);
    }

    public async Task<Tool?> FindToolByIdAndInventoryIdAsync(int toolId, int inventoryId)
    {
        var inventory = await context.Set<Inventory>()
            .Include(i => i.Tools)
            .FirstOrDefaultAsync(i => i.Id == inventoryId);

        return inventory?.Tools.FirstOrDefault(t => t.Id == toolId);
    }

    public async Task<FeedSupply?> FindFeedSupplyByIdAndInventoryIdAsync(int feedSupplyId, int inventoryId)
    {
        var inventory = await context.Set<Inventory>()
            .Include(i => i.FeedSupplies)
            .FirstOrDefaultAsync(i => i.Id == inventoryId);

        return inventory?.FeedSupplies.FirstOrDefault(fs => fs.Id == feedSupplyId);
    }

    public new async Task<Inventory?> FindByIdAsync(int inventoryId)
    {
        return await context.Set<Inventory>()
            .Include(i => i.Tools)
            .Include(i => i.FeedSupplies)
            .Include(i => i.Medicines)
            .FirstOrDefaultAsync(i => i.Id == inventoryId);
    }
    
}