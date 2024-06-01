using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Aggregates;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Queries;

namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Services;

public interface ICampaignQueryService
{
    Task<IEnumerable<Batch>> Handle(GetAllBatchesByCampaignIdQuery query);
    Task<Batch?> Handle(GetBatchByIdAndCampaignIdQuery query);
    Task<Campaign?> Handle(GetCampaignByIdAndUserIdQuery query);
    Task<IEnumerable<Campaign>> Handle(GetAllCampaignsQuery query);
    Task<IEnumerable<Campaign>> Handle(GetAllCampaignsByUserIdQuery query);
    
}