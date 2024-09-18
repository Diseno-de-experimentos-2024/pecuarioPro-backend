using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.ValueObjects;

namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Queries;

public record GetCampaignByIdAndUserIdQuery(int campaignId, UserId userId);