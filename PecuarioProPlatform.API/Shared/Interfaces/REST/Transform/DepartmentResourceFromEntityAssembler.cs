using PecuarioProPlatform.API.Shared.Domain.Model.Entities;
using PecuarioProPlatform.API.Shared.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.Shared.Interfaces.REST.Transform;

public static class DepartmentResourceFromEntityAssembler
{
    public static DepartmentResource ToResourceFromEntity(Department entity)
    {
        return new DepartmentResource(entity.Id, entity.Name);
    }
}