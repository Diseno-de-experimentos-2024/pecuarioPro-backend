namespace PecuarioProPlatform.API.StaffManagement.Domain.Model.Commands;

public record CreateStaffCommand(string CampaignId, string FirstName, string LastName,string JobDescription, 
    string Email, string Status, string DateStart, string DateEnd);