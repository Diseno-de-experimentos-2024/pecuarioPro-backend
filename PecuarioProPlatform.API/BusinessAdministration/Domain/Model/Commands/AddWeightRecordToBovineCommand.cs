namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Commands;

public record AddWeightRecordToBovineCommand(int bovineId, double weight, DateTime DateTime);