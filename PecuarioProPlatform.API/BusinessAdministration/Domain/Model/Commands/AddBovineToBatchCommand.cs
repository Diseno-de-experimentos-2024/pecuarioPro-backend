namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Commands;

public record AddBovineToBatchCommand(int batchId, int bovineId);