using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Aggregates;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Queries;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.ValueObjects;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Repositories;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Services;

namespace PecuarioProPlatform.API.BusinessAdministration.Application.Internal.QueryServices;

public class CampaignQueryService(ICampaignRepository campaignRepository): ICampaignQueryService
{
    public async Task<IEnumerable<Batch>> Handle(GetAllBatchesByCampaignIdQuery query)
    {
        return await campaignRepository.FindByCampaignIdAsync(query.campaignId); // obtain all batches of specific campaign
    }

    public async Task<Batch?> Handle(GetBatchByIdAndCampaignIdQuery query)
    {
        return await campaignRepository.FindByBatchIdAndCampaignId(query.batchId, query.campaignId);
    }

    public async Task<Campaign?> Handle(GetCampaignByIdAndUserIdQuery query)
    {
        return await campaignRepository.FindByCampaignIdAndUserIdAsync(query.campaignId, query.userId);
    }

    public async Task<Campaign?> Handle(GetCampaignByIDQuery query)
    {
        return await campaignRepository.FindByIdAsync(query.campaignId);
    }

    public async Task<IEnumerable<Campaign>> Handle(GetAllCampaignsQuery query)
    {
        return await campaignRepository.ListAsync();
    }

    public async Task<IEnumerable<Campaign>> Handle(GetAllCampaignsByUserIdQuery query)
    {
        return await campaignRepository.FindByUserIdAsync(new UserId(query.UserId));
    }
}