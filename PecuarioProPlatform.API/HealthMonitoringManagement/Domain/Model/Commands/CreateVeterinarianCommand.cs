namespace PecuarioProPlatform.API.HealthMonitoringManagement.Domain.Model.Commands;

public record CreateVeterinarianCommand(int Id, string FirstName, string LastName,string Specialty, int PhoneNumber, long Email, string PhotoUrl);