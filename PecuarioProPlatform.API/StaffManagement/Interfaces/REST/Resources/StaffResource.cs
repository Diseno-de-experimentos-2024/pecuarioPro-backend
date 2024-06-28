namespace PecuarioProPlatform.API.StaffManagement.Interfaces.REST.Resources;

public record StaffResource(int Id, string CampaignId, string FirstName, string LastName,string JobDescription, string Email, string status, string DateStart, string DateEnd);