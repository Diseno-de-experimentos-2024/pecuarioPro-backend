namespace PecuarioProPlatform.API.HealthMonitoringManagment.Domain.Model.Commands;

public record CreateVeterinarianCommand(int Id, string FirstName, string LastName, int VetPermit, int ContactNumber, bool Status, string Specialty);