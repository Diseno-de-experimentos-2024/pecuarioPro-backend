using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Entities;
using PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Transform;

public class BreedResourceFromEntityAssembler
{
    public static BreedResource ToResourceFromEntity(Breed entity)
    {
        return new BreedResource(entity.Id,entity.Name);
    }
}