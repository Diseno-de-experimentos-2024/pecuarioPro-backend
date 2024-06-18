namespace PecuarioProPlatform.API.HealthMonitoringManagment.Interfaces.REST.Resources;

public record CreateVeterinarianResource(int Id, string FirstName, string LastName, int VetPermit, int ContactNumber, bool Status, string Specialty);