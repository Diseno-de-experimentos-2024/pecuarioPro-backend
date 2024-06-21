namespace PecuarioProPlatform.API.HealthMonitoringManagment.Domain.Model.Commands;

public record CreateVeterinarianCommand(int Id, string FirstName, string LastName,string Specialty, int PhoneNumber, long Email, string PhotoUrl);