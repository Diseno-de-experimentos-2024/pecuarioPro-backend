using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Aggregates;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.ValueObjects;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Repositories;
using PecuarioProPlatform.API.Shared.Infraestructure.Persistence.EFC.Configuration;
using PecuarioProPlatform.API.Shared.Infraestructure.Persistence.EFC.Repositories;

namespace PecuarioProPlatform.API.BusinessAdministration.Infrastructure.Persistence.EFC.Repositories;

public class CampaignRepository(AppDbContext context): BaseRepository<Campaign>(context),ICampaignRepository
{
    public async Task<IEnumerable<Campaign>> FindByUserIdAsync(UserId userId)
    {
       return await Context.Set<Campaign>().Where(c => c.UserId == userId).ToListAsync();
    }

    public async Task<Campaign?> FindByCampaignIdAndUserIdAsync(int campaignId, UserId userId)
    {
        return await Context.Set<Campaign>().FirstOrDefaultAsync(c => c.Id == campaignId && c.UserId == userId);
    }

    public async Task<IEnumerable<Batch>> FindByCampaignIdAsync(int campaignId)
    {
        var campaign = await Context.Set<Campaign>()
            .Include(c => c.Batches)
            .ThenInclude(b => b.Origin)
            .FirstOrDefaultAsync(c => c.Id == campaignId);

        return campaign.Batches;
        
    }

    public async Task<Batch?> FindByBatchIdAndCampaignId(int batchId, int campaignId)
    {
        var campaign = await Context.Set<Campaign>()
            .Include(c => c.Batches)
            .ThenInclude(b => b.Origin)
            .ThenInclude(o => o.District)
            .Include(c => c.Batches)
            .ThenInclude(b => b.Origin)
            .ThenInclude(o => o.City)
            .Include(c => c.Batches)
            .ThenInclude(b => b.Origin)
            .ThenInclude(o => o.Department)
            .FirstOrDefaultAsync(c => c.Id == campaignId);

        var batch = campaign?.Batches.FirstOrDefault(b => b.Id == batchId);
    
        if (batch != null)
        {
            Console.WriteLine($"Batch ID: {batch.Id}, Name: {batch.Name}");
            Console.WriteLine($"District: {batch.Origin?.District?.Name ?? "Not Loaded"}");
            Console.WriteLine($"City: {batch.Origin?.City?.Name ?? "Not Loaded"}");
            Console.WriteLine($"Department: {batch.Origin?.Department?.Name ?? "Not Loaded"}");
        }
    
        return batch;
    }

    public void RemoveBatch(Batch batch)
    {
        Context.Set<Batch>().Remove(batch);
    }


    public new async Task<Campaign?> FindByIdAsync(int id)
    {
        return await Context.Set<Campaign>()
            .Include(campaign => campaign.Batches)
            .ThenInclude(b => b.Origin)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public new async Task<IEnumerable<Campaign>> ListAsync()
    {
        return await Context.Set<Campaign>()
            .Include(campaign => campaign.Batches)
            .ThenInclude(b => b.Origin)
            .ToListAsync();
    }
    
}