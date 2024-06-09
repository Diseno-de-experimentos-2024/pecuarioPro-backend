namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Commands;

public record DeleteBovineToBatchCommand(int batchId, int bovineId);