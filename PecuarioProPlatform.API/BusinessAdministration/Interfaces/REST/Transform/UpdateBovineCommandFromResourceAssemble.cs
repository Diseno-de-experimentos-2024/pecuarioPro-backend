using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Commands;
using PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Transform;

public class UpdateBovineCommandFromResourceAssemble
{
    public static UpdateBovineCommand ToCommandFromResource(int bovineId,CreateBovineResource resource)
    {
        return new UpdateBovineCommand(bovineId, resource.Name, resource.Weight, resource.Date, resource.Observations,
            resource.BreedId, resource.DistrictId, resource.CityId, resource.DepartmentId, resource.BatchId,
            resource.imgUrls);
    }
}