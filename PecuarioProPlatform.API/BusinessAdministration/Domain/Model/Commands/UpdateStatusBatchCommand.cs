using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.ValueObjects;

namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Commands;

public record UpdateStatusBatchCommand(int batchId,int campaignId, string status);