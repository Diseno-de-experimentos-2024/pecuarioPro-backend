using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Commands;
using PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Transform;

public static class AddImageToBovineCommandFromResourceAssembler
{
    public static AddImageAssetToBovineCommand ToCommandFromResource(AddImageAssetToBovineResource resource, int BovineId)
    {
        return new AddImageAssetToBovineCommand(resource.imageUrl, BovineId);
    }
}