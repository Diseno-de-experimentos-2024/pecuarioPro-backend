namespace PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Resources;

public record CreateBatchResource(string Name, double Area , int districtId, int campaignId);