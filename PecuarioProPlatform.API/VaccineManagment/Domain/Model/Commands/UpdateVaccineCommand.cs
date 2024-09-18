namespace PecuarioProPlatform.API.VaccineManagment.Domain.Model.Commands;

public record UpdateVaccineCommand(int Id,String Name, DateOnly Date, String Code, String Reason,Double Dose);