namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Commands;

public record CreateBatchCommand(string Name, double Area, int campaignId, int districtId);