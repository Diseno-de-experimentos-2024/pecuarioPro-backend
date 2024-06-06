namespace PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Resources;

public record CreateWeightRecordResource(int BovineId,double Weight, DateTime RecordDate);