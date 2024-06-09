namespace PecuarioProPlatform.API.VaccineManagment.Domain.Model.Commands;

public  record CreateVaccineCommand(int Id,string Name, string Reason, string Code, string Description);
