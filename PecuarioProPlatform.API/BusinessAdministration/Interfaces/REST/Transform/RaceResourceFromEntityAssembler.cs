using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Entities;
using PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Transform;

public class RaceResourceFromEntityAssembler
{
    public static RaceResource ToResourceFromEntity(Race entity)
    {
        return new RaceResource(entity.Id,entity.Name);
    }
}