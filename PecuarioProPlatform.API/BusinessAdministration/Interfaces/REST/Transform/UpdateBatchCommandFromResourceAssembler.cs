using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Commands;
using PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Transform;

public class UpdateBatchCommandFromResourceAssembler
{
    public static UpdateBatchCommand ToCommandFromResource(int campaignId,int batchId, UpdateBatchResource resource)
    {
        return new UpdateBatchCommand(campaignId, batchId, resource.Name, resource.Area, resource.districtId,
            resource.cityId, resource.departmentId);
    }
}