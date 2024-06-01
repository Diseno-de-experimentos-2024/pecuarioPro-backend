using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Aggregates;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.ValueObjects;
using PecuarioProPlatform.API.Shared.Domain.Repositories;

namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Repositories;

public interface ICampaignRepository: IBaseRepository<Campaign>
{
    Task<IEnumerable<Campaign>> FindByUserIdAsync(UserId userId);
    Task<Campaign?> FindByCampaignIdAndUserIdAsync(int campaignId, UserId userId);
    Task<IEnumerable<Batch>> FindByCampaignIdAsync(int campaignId);
    Task<Batch?> FindByBatchIdAndCampaignId(int batchId, int campaignId);
}