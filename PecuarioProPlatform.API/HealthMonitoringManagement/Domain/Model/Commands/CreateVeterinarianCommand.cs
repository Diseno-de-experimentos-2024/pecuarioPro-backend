namespace PecuarioProPlatform.API.HealthMonitoringManagement.Domain.Model.Commands;

public record CreateVeterinarianCommand(string FirstName, string LastName,string Specialty, int PhoneNumber, 
    string Email, string City,string Status, string PhotoUrl);