using Microsoft.OpenApi.Extensions;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Aggregates;
using PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Transform;

public static class CampaignResourceFromEntityAssembler
{
    public static CampaignResource ToResourceFromEntity(Campaign entity)
    {
        return new CampaignResource(entity.Id, entity.Name, entity.DateStart, entity.DateEnd, entity.Condition.GetDisplayName(),
            entity.Duration,entity.UserId.Identifier,entity.Objective);
    }   
}