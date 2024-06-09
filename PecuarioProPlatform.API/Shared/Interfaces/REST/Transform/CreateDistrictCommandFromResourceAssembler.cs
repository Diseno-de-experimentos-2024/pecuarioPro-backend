using PecuarioProPlatform.API.Shared.Domain.Model.Commands;
using PecuarioProPlatform.API.Shared.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.Shared.Interfaces.REST.Transform;

public static class CreateDistrictCommandFromResourceAssembler
{
    public static CreateDistrictCommand ToCommandFrontResource(CreateDistrictResource resource)
    {
        return new CreateDistrictCommand(resource.Name, resource.CityId);
    }
}