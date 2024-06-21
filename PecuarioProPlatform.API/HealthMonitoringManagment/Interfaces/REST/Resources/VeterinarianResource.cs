namespace PecuarioProPlatform.API.HealthMonitoringManagment.Interfaces.REST.Resources;

public record VeterinarianResource(int Id, string FirstName, string LastName,string Specialty, int PhoneNumber, long Email, string PhotoUrl);