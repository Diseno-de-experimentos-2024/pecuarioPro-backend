namespace PecuarioProPlatform.API.VaccineManagment.Interfaces.REST.Resources;

public record CreateVaccineResource(int Id,string Name, 
    string Reason, string Code, string Description);