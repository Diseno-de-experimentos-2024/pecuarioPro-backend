namespace PecuarioProPlatform.API.VaccineManagment.Interfaces.REST.Resources;

public record VaccineResource(
    int Id,
    string Name,
    string Date, // Date as string in format "dd/MM/yyyy"
    string Code,
    string Reason
);