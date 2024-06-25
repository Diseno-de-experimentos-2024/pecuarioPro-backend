namespace PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Resources;

public record UpdateBatchResource(string Name, double Area , int districtId,int cityId, int departmentId);