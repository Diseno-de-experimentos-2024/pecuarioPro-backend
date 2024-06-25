using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Aggregates;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Entities;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.ValueObjects;
using PecuarioProPlatform.API.Shared.Domain.Repositories;

namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Repositories;

public interface IBovineRepository : IBaseRepository<Bovine>
{
    // add to list vaccineOrders

    Task<IEnumerable<Bovine>> FindByBreedIdAsync(int breedId);
    Task<IEnumerable<Bovine>> FindByDistrictIdAsync(int districtId);
    Task<IEnumerable<Bovine>> FindByBatchIdAsync(int batchId);
    Task<IEnumerable<Bovine>> FindByCampaignIdAsync(int campaignId);
    Task<Bovine?> FindByBovineIdentifierAsync(BovineIdentifier bovineIdentifier);
    Task<IEnumerable<Bovine>> FindByUserIdAsync(UserId userId);

    Task<IEnumerable<WeightRecord>> FindByBovineIdAsync(int bovineId);
    void RemoveAssets(ImageAsset image);
}