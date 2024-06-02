using Microsoft.OpenApi.Extensions;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Aggregates;
using PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Transform;

public static class BatchResourceFromEntityAssembler
{
    public static BatchResource ToResourceFromEntity(Batch entity)
    {
        return new BatchResource(entity.Id, entity.Name, entity.Area, entity.District.Name, entity.Status.GetDisplayName());
    }
}