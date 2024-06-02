using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.ValueObjects;

namespace PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Resources;

public record BatchResource(int Id,string Name, double Area, string District, string Status);