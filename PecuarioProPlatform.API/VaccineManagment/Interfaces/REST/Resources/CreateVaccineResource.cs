namespace PecuarioProPlatform.API.VaccineManagment.Interfaces.REST.Resources;

public record CreateVaccineResource(
    string Name,
    string Date, // Date as string in format "dd/MM/yyyy"
    string Code,
    string Reason
);