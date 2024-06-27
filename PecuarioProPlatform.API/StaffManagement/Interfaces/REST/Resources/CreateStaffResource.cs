namespace PecuarioProPlatform.API.StaffManagement.Interfaces.REST.Resources;

public record CreateStaffResource(string FirstName, string LastName,string JobDescription, 
    int PhoneNumber, string Email, string City,string Status, string PhotoUrl);