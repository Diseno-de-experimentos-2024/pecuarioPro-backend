using PecuarioProPlatform.API.BusinessAdministration.Domain.Model.ValueObjects;

namespace PecuarioProPlatform.API.BusinessAdministration.Interfaces.REST.Resources;

public record CreateCampaignResource(string Name, DateOnly DateStart, DateOnly DateEnd, string Objective, UserId UserId);