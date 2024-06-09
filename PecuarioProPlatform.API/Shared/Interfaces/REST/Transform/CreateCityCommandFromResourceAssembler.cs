using PecuarioProPlatform.API.Shared.Domain.Model.Commands;
using PecuarioProPlatform.API.Shared.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.Shared.Interfaces.REST.Transform;

public static class CreateCityCommandFromResourceAssembler
{
    public static CreateCityCommand ToCommandFromResource(CreateCityResource resource)
    {
        return new CreateCityCommand(resource.Name, resource.DepartmentId);
    }
}