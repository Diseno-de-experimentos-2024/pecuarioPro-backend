using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Entities;

namespace PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Resources;

public record BovineResource(int Id, string BovineIdentifier, string Name, double Weight,DateOnly Date,string observations,string District, string Race);