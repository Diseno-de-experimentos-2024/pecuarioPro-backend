namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Commands;

public record AddBatchToCampaignCommand(int campaignId, int batchId);