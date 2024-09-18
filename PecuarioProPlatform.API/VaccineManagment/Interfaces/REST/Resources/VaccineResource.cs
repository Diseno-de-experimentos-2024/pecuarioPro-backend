namespace PecuarioProPlatform.API.VaccineManagment.Interfaces.REST.Resources;

public record VaccineResource(
    int Id,
    string Name,
    DateOnly Date, 
    string Code,
    string Reason,
    double Dose,
    int UserId,
    int BovineId
);