using Microsoft.EntityFrameworkCore;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Aggregates;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Entities;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.ValueObjects;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Repositories;
using PecuarioProPlatform.API.Shared.Infraestructure.Persistence.EFC.Configuration;
using PecuarioProPlatform.API.Shared.Infraestructure.Persistence.EFC.Repositories;

namespace PecuarioProPlatform.API.BusinessAdministration.Infrastructure.Persistence.EFC.Repositories;

public class BovineRepository(AppDbContext context) : BaseRepository<Bovine>(context), IBovineRepository
{
    public async Task<IEnumerable<Bovine>> FindByRaceIdAsync(int raceId)
    {
        return await Context.Set<Bovine>().Include(bovine =>bovine.Race).Include(bovine => bovine.District)
            .Where(b => b.RaceId == raceId).ToListAsync();
    }

    public async Task<IEnumerable<Bovine>> FindByDistrictIdAsync(int districtId)
    {
        return await Context.Set<Bovine>().Include(bovine =>bovine.Race).Include(bovine => bovine.District)
            .Where(b => b.DistrictId == districtId).ToListAsync();
    }

    public async Task<IEnumerable<Bovine>> FindByBatchIdAsync(int batchId)
    {
        return await Context.Set<Bovine>().Include(bovine =>bovine.Race).Include(bovine => bovine.District)
            .Where(b => b.BatchId == batchId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Bovine>> FindByCampaignIdAsync(int campaignId)
    {
        return await Context.Set<Bovine>().Include(bovine =>bovine.Race).Include(bovine => bovine.District)
            .Where(b => b.Batch.CampaignId == campaignId)
            .ToListAsync();    }

    public async Task<Bovine?> FindByBovineIdentifierAsync(BovineIdentifier bovineIdentifier)
    {
        return await Context.Set<Bovine>().Include(bovine =>bovine.Race).Include(bovine => bovine.District)
            .FirstOrDefaultAsync(b => b.BovineIdentifier == bovineIdentifier);
    }

    public async Task<IEnumerable<Bovine>> FindByUserIdAsync(UserId userId)
    {
        return await Context.Set<Bovine>().Include(bovine =>bovine.Race).Include(bovine => bovine.District)
            .Where(b => b.Batch.Campaign.UserId == userId)
            .ToListAsync();
        
        
    }

    public new async Task<Bovine?> FindByIdAsync(int id)
    {
        return await Context.Set<Bovine>().Include(bovine => bovine.Race).Include(bovine => bovine.District)
            .FirstOrDefaultAsync(bovine => bovine.Id == id);
    }

    public new async Task<IEnumerable<Bovine>> ListAsync()
    {
        return await Context.Set<Bovine>().Include(bovine => bovine.Race).Include(bovine => bovine.District)
            .ToListAsync();
    }
    
}
