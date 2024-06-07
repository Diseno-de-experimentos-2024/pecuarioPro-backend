using PecuarioProPlatform.API.Shared.Domain.Model.Entities;
using PecuarioProPlatform.API.Shared.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.Shared.Interfaces.REST.Transform;

public static class DistrictResourceFromEntityAssembler
{
    public static DistrictResource ToResourceFromEntity(District entity)
    {
        return new DistrictResource(entity.Id, entity.Name);
    }
}