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
    private IBovineRepository _bovineRepositoryImplementation;

    public async Task<IEnumerable<Bovine>> FindByBreedIdAsync(int breedId)
    {
        return await Context.Set<Bovine>()
            .Include(bovine=>bovine.Images)
            .Include(bovine => bovine.Breed)
            .Include(bovine => bovine.Origin)
            .ThenInclude(origin => origin.District)
            .Include(bovine => bovine.Origin)
            .ThenInclude(origin => origin.City)
            .Include(bovine => bovine.Origin)
            .ThenInclude(origin => origin.Department) 
            .Where(b => b.BreedId == breedId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Bovine>> FindByDistrictIdAsync(int districtId)
    {
        return await Context.Set<Bovine>()
            .Include(bovine=>bovine.Images)
            .Include(bovine => bovine.Breed)
            .Include(bovine => bovine.Origin)
            .ThenInclude(origin => origin.District)
            .Include(bovine => bovine.Origin)
            .ThenInclude(origin => origin.City)
            .Include(bovine => bovine.Origin)
            .ThenInclude(origin => origin.Department) 
            .Where(b => b.Origin.DistrictId == districtId) 
            .ToListAsync();
    }

    public async Task<IEnumerable<Bovine>> FindByBatchIdAsync(int batchId)
    {
        return await Context.Set<Bovine>()
            .Include(bovine=>bovine.Images)
            .Include(bovine => bovine.Breed)
            .Include(bovine => bovine.Origin)
            .ThenInclude(origin => origin.District)
            .Include(bovine => bovine.Origin)
            .ThenInclude(origin => origin.City)
            .Include(bovine => bovine.Origin)
            .ThenInclude(origin => origin.Department) 
            .Where(b => b.BatchId == batchId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Bovine>> FindByCampaignIdAsync(int campaignId)
    {
        return await Context.Set<Bovine>()
            .Include(bovine=>bovine.Images)
            .Include(bovine => bovine.Breed)
            .Include(bovine => bovine.Origin)
            .ThenInclude(origin => origin.District)
            .Include(bovine => bovine.Origin)
            .ThenInclude(origin => origin.City)
            .Include(bovine => bovine.Origin)
            .ThenInclude(origin => origin.Department) 
            .Where(b => b.Batch.CampaignId == campaignId)
            .ToListAsync();
        
    }

    public async Task<Bovine?> FindByBovineIdentifierAsync(BovineIdentifier bovineIdentifier)
    {
        return await Context.Set<Bovine>()
            .Include(bovine=>bovine.Images)
            .Include(bovine =>bovine.Breed)
            .Include(bovine => bovine.Origin)
            .ThenInclude(origin => origin.District)
            .Include(bovine => bovine.Origin)
            .ThenInclude(origin => origin.City)
            .Include(bovine => bovine.Origin)
            .ThenInclude(origin => origin.Department)
            .FirstOrDefaultAsync(b => b.BovineIdentifier == bovineIdentifier);
    }

    public async Task<IEnumerable<Bovine>> FindByUserIdAsync(UserId userId)
    {
        return await Context.Set<Bovine>().Include(bovine =>bovine.Breed)
            .Include(bovine=>bovine.Images)
            .Include(bovine => bovine.Origin)
            .ThenInclude(origin => origin.District)
            .Include(bovine => bovine.Origin)
            .ThenInclude(origin => origin.City)
            .Include(bovine => bovine.Origin)
            .ThenInclude(origin => origin.Department)
            .Where(b => b.Batch.Campaign.UserId.Identifier == userId.Identifier)
            .ToListAsync();
    }

    public async Task<IEnumerable<WeightRecord>> FindByBovineIdAsync(int bovineId)
    {
        var bovine = await Context.Set<Bovine>()
            .Include(b => b.WeightRecords)
            .FirstOrDefaultAsync(b => b.Id == bovineId);
        return bovine.WeightRecords;
    }


    public new async Task<Bovine?> FindByIdAsync(int id)
    {
        return await Context.Set<Bovine>()
            .Include(bovine=>bovine.Images)
            .Include(bovine => bovine.Breed)
            .Include(bovine => bovine.Origin)
            .ThenInclude(origin => origin.District)
            .Include(bovine => bovine.Origin)
            .ThenInclude(origin => origin.City)
            .Include(bovine => bovine.Origin)
            .ThenInclude(origin => origin.Department)
            .FirstOrDefaultAsync(bovine => bovine.Id == id);
    }

    public new async Task<IEnumerable<Bovine>> ListAsync()
    {
        return await Context.Set<Bovine>()
            .Include(bovine=>bovine.Images)
            .Include(bovine => bovine.Breed)
            .Include(bovine => bovine.Origin)
            .ThenInclude(origin => origin.District)
            .Include(bovine => bovine.Origin)
            .ThenInclude(origin => origin.City)
            .Include(bovine => bovine.Origin)
            .ThenInclude(origin => origin.Department)
            .ToListAsync();
    }
    
    public void RemoveAssets(ImageAsset image)
    {
            Context.Set<ImageAsset>().Remove(image);
    }
    
}
