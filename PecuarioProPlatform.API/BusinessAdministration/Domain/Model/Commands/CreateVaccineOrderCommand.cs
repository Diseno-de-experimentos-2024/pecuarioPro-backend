namespace PecuarioProPlatform.API.BusinessAdministration.Domain.Model.Commands;

public record CreateVaccineOrderCommand(Guid Id, string Name, string Reason, DateTime Date, string Code);
