using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Commands;
using PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Transform;

public class UpdateCampaignCommandFromResourceAssembler
{
    public static UpdateCampaignCommand ToCommandFromResource(int campaignId, CreateCampaignResource resource)
    {
        return new UpdateCampaignCommand(campaignId, resource.Name, resource.DateStart, resource.DateEnd,
            resource.Objective);
    }
}