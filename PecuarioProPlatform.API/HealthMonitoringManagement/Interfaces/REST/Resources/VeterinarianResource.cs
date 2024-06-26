namespace PecuarioProPlatform.API.HealthMonitoringManagment.Interfaces.REST.Resources;

public record VeterinarianResource(int Id, string FirstName, string LastName,string Specialty, int PhoneNumber, string Email, string city, string status, string PhotoUrl);