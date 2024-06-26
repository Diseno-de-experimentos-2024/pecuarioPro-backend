namespace PecuarioProPlatform.API.VaccineManagment.Domain.Model.Commands;

public record CreateVaccineCommand(String Name, DateTime Date, String Code, String Reason);