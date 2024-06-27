namespace PecuarioProPlatform.API.StaffManagement.Domain.Model.Commands;

public record CreateStaffCommand(string FirstName, string LastName,string JobDescription, int PhoneNumber, 
    string Email, string City,string Status, string PhotoUrl);