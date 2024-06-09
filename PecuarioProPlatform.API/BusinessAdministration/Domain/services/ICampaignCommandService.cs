using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Aggregates;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Commands;

namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Services;

public interface ICampaignCommandService
{
    Task<Campaign?> Handle(CreateCampaignCommand command);
    Task<Campaign?> Handle(AddBatchToCampaignCommand command);
    Task<Campaign?> Handle(ConcludeCampaignCommand command);
    Task<Campaign?> Handle(DeleteBatchToCampaignCommand command);
    Task<Campaign?> Handle(ModifyDurationCampaignCommand command);
    Task<Campaign?> Handle(UpdateConditionCampaignCommand command);
    Task<Batch?> Handle(UpdateStatusBatchCommand command);

    Task<Batch?> Handle(CreateBatchCommand command);

}