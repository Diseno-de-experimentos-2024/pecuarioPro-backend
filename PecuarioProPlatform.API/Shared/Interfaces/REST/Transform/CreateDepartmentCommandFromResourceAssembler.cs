using PecuarioProPlatform.API.Shared.Domain.Model.Commands;
using PecuarioProPlatform.API.Shared.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.Shared.Interfaces.REST.Transform;

public static class CreateDepartmentCommandFromResourceAssembler
{
    public static CreateDepartmentCommand ToCommandFromResource(CreateDepartmentResource resource)
    {
        return new CreateDepartmentCommand(resource.Name);
    }
}