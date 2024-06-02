using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Commands;
using PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Transform;

public static class CreateBatchCommandFromResourceAssembler
{
    public static CreateBatchCommand ToCommandFromResource(CreateBatchResource resource)
    {
        return new CreateBatchCommand(resource.Name, resource.Area, resource.campaignId, resource.districtId);
    }
}