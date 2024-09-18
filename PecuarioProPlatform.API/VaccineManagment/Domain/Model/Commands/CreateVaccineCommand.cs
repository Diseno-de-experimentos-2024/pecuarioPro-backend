
namespace PecuarioProPlatform.API.VaccineManagment.Domain.Model.Commands;

public record CreateVaccineCommand(String Name, DateOnly Date, String Code, String Reason,Double Dose,int UserId,int BovineId);