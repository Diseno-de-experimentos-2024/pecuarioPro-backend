using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Commands;
using PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Transform;

public static class ModifyDurationCampaingFromResourceAssembler
{
    public static ModifyDurationCampaignCommand ToCommandFromResource(ModifyDurationCampaignResource resource,
        int campaignId)
    {
        return new ModifyDurationCampaignCommand(campaignId, resource.duration);
    }
}