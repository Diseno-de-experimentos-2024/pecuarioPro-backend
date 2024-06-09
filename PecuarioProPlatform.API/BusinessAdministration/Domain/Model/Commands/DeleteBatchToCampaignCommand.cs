namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Commands;

public record DeleteBatchToCampaignCommand(int campaignId, int batchId);