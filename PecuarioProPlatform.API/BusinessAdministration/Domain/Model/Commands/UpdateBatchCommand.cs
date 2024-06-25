namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Commands;

public record UpdateBatchCommand(int campaignId, int batchId, string name, double area, int districtId,int cityId,int departmentId);