namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Commands;

public record CreateBovineCommand(string Name, double Weight,DateOnly Date, string Observations,int RaceId,int DistrictId,int CityId,int DepartmentId, int BatchId,ICollection<String> Urls);