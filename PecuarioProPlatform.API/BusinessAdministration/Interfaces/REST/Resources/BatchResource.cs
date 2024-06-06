using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.ValueObjects;

namespace PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Resources;

public record BatchResource(int Id,string Name, double Area, OriginResource origin, string Status, int CampaignId);