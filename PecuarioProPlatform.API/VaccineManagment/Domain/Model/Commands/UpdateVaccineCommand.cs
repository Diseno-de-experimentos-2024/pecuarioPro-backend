namespace PecuarioProPlatform.API.VaccineManagment.Domain.Model.Commands;

public record UpdateVaccineCommand(int Id,String Name, DateTime Date, String Code, String Reason);