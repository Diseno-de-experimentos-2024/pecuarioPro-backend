namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Commands;

public record UpdateCampaignCommand(int campaignId,string name, DateOnly dateStart, DateOnly dateEnd, string objective);