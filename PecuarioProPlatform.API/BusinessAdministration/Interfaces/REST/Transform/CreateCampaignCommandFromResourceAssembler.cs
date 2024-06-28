using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Commands;
using PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Transform;

public static class CreateCampaignCommandFromResourceAssembler
{
    public static CreateCampaignCommand ToCommandFromResource(CreateCampaignResource resource)
    {
        return new CreateCampaignCommand(resource.Name, resource.DateStart, resource.DateEnd, resource.Objective, resource.userId);
        
    }
}