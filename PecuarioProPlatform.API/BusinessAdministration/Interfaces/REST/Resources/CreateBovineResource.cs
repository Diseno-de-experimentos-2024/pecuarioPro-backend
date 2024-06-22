using PecuarioProPlatform.API.Shared.Domain.Model.Entities;

namespace PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Resources;

public record CreateBovineResource(string Name, double Weight, DateOnly Date, string Observations,int BreedId,int DistrictId,int CityId,int DepartmentId,int BatchId );