using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Commands;
using PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Transform;

public static class ModifyWeightBovineFromResourceAssembler
{
    public static ModifyWeightBovineCommand ToCommandFromResource(ModifyWeightBovineResource resource, int bovineId)
    {
        return new ModifyWeightBovineCommand(resource.weight, bovineId);
    }
}