namespace PecuarioProPlatform.API.StaffManagement.Interfaces.REST.Resources;

public record CreateStaffResource(string CampaignId, string FirstName, string LastName,string JobDescription, 
    string Email, string Status, string DateStart, string DateEnd);