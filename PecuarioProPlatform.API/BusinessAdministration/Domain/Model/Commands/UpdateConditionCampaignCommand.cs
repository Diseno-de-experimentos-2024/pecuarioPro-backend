using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.ValueObjects;

namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Commands;

public record UpdateConditionCampaignCommand(int campaignId, ECampaignCondition condition );