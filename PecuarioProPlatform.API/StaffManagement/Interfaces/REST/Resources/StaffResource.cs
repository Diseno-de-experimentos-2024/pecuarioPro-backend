namespace PecuarioProPlatform.API.StaffManagement.Interfaces.REST.Resources;

public record StaffResource(int Id, string FirstName, string LastName,string JobDescription, int PhoneNumber, string Email, string city, string status, string PhotoUrl);