namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Commands;

public record CreateCampaignCommand(string name, DateOnly dateStart, DateOnly dateEnd, string objective);