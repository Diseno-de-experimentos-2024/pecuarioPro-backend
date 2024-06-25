using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Commands;
using PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Transform;

public static class CreateBovineCommandFromResourceAssembler
{
    public static CreateBovineCommand ToCommandFromResource(CreateBovineResource resource)
    {
        return new CreateBovineCommand(resource.Name, resource.Weight, resource.Date, resource.Observations,
            resource.BreedId, resource.DistrictId, resource.CityId,resource.DepartmentId,resource.BatchId,resource.imgUrls);
    }
}