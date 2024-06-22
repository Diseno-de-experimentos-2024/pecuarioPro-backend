using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Commands;
using PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Resources;

namespace PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Transform;

public static class DeleteBatchCommandFromResourceAssembler
{
    public static DeleteBatchToCampaignCommand ToCommandFromResource(int campaignId,DeleteBatchResource resource)
    {
        return new DeleteBatchToCampaignCommand(campaignId,resource.batchId);
    }
}