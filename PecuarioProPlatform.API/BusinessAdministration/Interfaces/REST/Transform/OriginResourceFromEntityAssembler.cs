using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.ValueObjects;
using PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Transform;

public class OriginResourceFromEntityAssembler
{
    public static OriginResource ToResourceFromEntity(Origin entity)
    {
        return new OriginResource(entity.District.Name, entity.City.Name, entity.Department.Name);
    }
}