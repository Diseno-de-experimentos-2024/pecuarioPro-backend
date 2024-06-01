using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Aggregates;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Commands;

namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Services;

public interface ICampaignCommandService
{
    Task<Campaign?> Handle(CreateCampaignCommand command);
    int Handle(AddBatchToCampaignCommand command);
    int Handle(AddBovineToBatchCommand command);
    int Handle(ConcludeCampaignCommand command);
    int Handle(DeleteBatchToCampaignCommand command);
    int Handle(DeleteBovineToBatchCommand command);
    int Handle(ModifyDurationCampaignCommand command);
    int Handle(UpdateConditionCampaignCommand command);
    int Handle(UpdateStatusBatchCommand command);
    
}