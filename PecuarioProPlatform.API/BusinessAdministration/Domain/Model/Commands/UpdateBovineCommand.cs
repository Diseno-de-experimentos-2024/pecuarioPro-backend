namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Commands;

public record UpdateBovineCommand(int bovineId, string name, double weight,DateOnly date, string observations,int breedId,int districtId,int cityId,int departmentId, int batchId,ICollection<String> imgUrls);