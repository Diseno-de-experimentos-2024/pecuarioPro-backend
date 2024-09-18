namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Commands;

public record CreateBovineCommand(string Name, double Weight,DateOnly Date, string Observations,int BreedId,int DistrictId,int CityId,int DepartmentId, int BatchId,int UserId,ICollection<String> Urls);