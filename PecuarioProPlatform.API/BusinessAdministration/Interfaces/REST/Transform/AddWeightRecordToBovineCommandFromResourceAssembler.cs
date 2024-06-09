using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Commands;
using PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Transform;

public static class AddWeightRecordToBovineCommandFromResourceAssembler
{
    public static AddWeightRecordToBovineCommand ToCommandFromResource(int bovineId,AddNewWeightRecordResource resource)
    {
        return new AddWeightRecordToBovineCommand(bovineId, resource.weight, resource.DateTime);
    }
}