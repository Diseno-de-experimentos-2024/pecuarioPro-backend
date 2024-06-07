using PecuarioProPlatform.API.Shared.Domain.Model.Entities;
using PecuarioProPlatform.API.Shared.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.Shared.Interfaces.REST.Transform;

public static class CityResourceFromEntityAssembler
{
    public static CityResource ToResourceFromEntity(City entity)
    {
        return new CityResource(entity.Id, entity.Name);
    }
}