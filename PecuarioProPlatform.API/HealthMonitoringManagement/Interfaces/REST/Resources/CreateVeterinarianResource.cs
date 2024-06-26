namespace PecuarioProPlatform.API.HealthMonitoringManagment.Interfaces.REST.Resources;

public record CreateVeterinarianResource(string FirstName, string LastName,string Specialty, 
    int PhoneNumber, string Email, string City,string Status, string PhotoUrl);